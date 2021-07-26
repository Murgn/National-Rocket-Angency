using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Murgn;

namespace Murgn
{
    public class JoystickController : MonoBehaviour
    {
        private Joystick joystick;
        private SpriteRenderer sprite;

        void Awake()
        {
            joystick = GetComponent<Joystick>();
            sprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        }

        void Update()
        {
            joystickStates();
        }

        void joystickStates()
        {
            switch(joystick.state)
            {
                case JoystickStates.Idle:
                sprite.sprite = joystick.joystickSprites[0];
                return;

                case JoystickStates.Forward:
                sprite.sprite = joystick.joystickSprites[1];
                return;
                
                case JoystickStates.Back:
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
