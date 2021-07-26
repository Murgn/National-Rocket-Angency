using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Murgn.Player;
using UnityEngine.Events;

namespace Murgn.Interactable
{
    public class JoystickController : MonoBehaviour
    {
        private Joystick joystick;
        private SpriteRenderer sprite;
        private Hand hand;

        private UnityAction startGrab;
        private UnityAction endGrab;


        public Vector2 startGrabPos;

        public float offset;

        void Awake()
        {
            hand = GameObject.Find("Canvas/Hands").GetComponent<Hand>();
            joystick = GetComponent<Joystick>();
            sprite = transform.GetChild(0).GetComponent<SpriteRenderer>();

            startGrab += OnGrab;
            endGrab += EndGrab;
        }

        void Update()
        {
            joystickStates();
        }

        void OnMouseOver()
        {
            hand.GetComponent<HandController>().changeInteractable(gameObject, startGrab, endGrab);
        }

        void OnGrab()
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(startGrabPos == Vector2.zero) startGrabPos = mousePos;

            // UP
            if(mousePos.y > startGrabPos.y + offset)
            {
                joystick.state = JoystickStates.Up;
            }
            // RIGHT
            else if(mousePos.x > startGrabPos.x + offset)
            {
                joystick.state = JoystickStates.Right;
            }
            // LEFT
            else if(mousePos.x < startGrabPos.x - offset)
            {
                joystick.state = JoystickStates.Left;
            }
            // DOWN
            else if(mousePos.y < startGrabPos.y - offset)
            {
                joystick.state = JoystickStates.Down;
            }
            // IDLE
            else
            {
                joystick.state = JoystickStates.Idle;
            }

        }

        void EndGrab()
        {
            hand.GetComponent<HandController>().changeInteractable(null, null, null);
            joystick.state = JoystickStates.Idle;
            startGrabPos = Vector2.zero;
            Debug.Log("endgrab");
        }

        void OnMouseExit()
        {
            if(!Input.GetMouseButton(0))
            {
                hand.GetComponent<HandController>().changeInteractable(null, null, null);
            }
        }

        void joystickStates()
        {
            switch(joystick.state)
            {
                case JoystickStates.Idle:
                sprite.sprite = joystick.joystickSprites[0];
                return;

                case JoystickStates.Up:
                sprite.sprite = joystick.joystickSprites[1];
                return;
                
                case JoystickStates.Down:
                sprite.sprite = joystick.joystickSprites[2];
                return;

                case JoystickStates.Left:
                sprite.sprite = joystick.joystickSprites[3];
                return;

                case JoystickStates.Right:
                sprite.sprite = joystick.joystickSprites[4];
                return;
            }
        }
    }   
}
