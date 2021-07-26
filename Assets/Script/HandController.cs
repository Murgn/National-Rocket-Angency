using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Murgn;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Murgn.Player
{
    public class HandController : MonoBehaviour
    {
        private Hand hand;
        private Image sprite;

        public GameObject interactable;
        private UnityAction startAction;
        private UnityAction endAction;
        
        void Awake()
        {
            hand = GetComponent<Hand>();
            sprite = transform.GetChild(0).GetComponent<Image>();

            #if !UNITY_EDITOR
            Cursor.visible = false;
            #endif
        }

        void Update()
        {
            transform.position = Input.mousePosition;
            handStates();

            Interactivity();
        }

        void Interactivity()
        {
            if(interactable == null)
            {
                hand.state = State.Idle;
                return;
            }
            
            if(!Input.GetMouseButton(0))
            {
                hand.state = State.Interactable;
            }

            if(Input.GetMouseButton(0))
            {
                hand.state = State.Grab;
                startAction.Invoke();
            }

            if(Input.GetMouseButtonUp(0))
            {
                hand.state = State.Idle;
                endAction.Invoke();
            }

        }

        void handStates()
        {
            switch(hand.state)
            {
                case State.Idle:
                sprite.sprite = hand.handSprites[0];
                return;
                
                case State.Interactable:
                sprite.sprite = hand.handSprites[1];
                return;

                case State.Grab:
                sprite.sprite = hand.handSprites[2];
                return;
            }
        }

        public void changeInteractable(GameObject gameObject, UnityAction StartAction, UnityAction EndAction)
        {
            if(hand.state != State.Grab)
            interactable = gameObject;
            startAction = StartAction;
            endAction = EndAction;
        }
    }   
}
