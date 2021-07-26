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
                hand.state = HandStates.Idle;
                return;
            }
            
            if(!Input.GetMouseButton(0))
            {
                hand.state = HandStates.Interactable;
            }

            if(Input.GetMouseButton(0))
            {
                hand.state = HandStates.Grab;
                startAction.Invoke();
            }

            if(Input.GetMouseButtonUp(0))
            {
                hand.state = HandStates.Idle;
                endAction.Invoke();
            }

        }

        void handStates()
        {
            switch(hand.state)
            {
                case HandStates.Idle:
                sprite.sprite = hand.handSprites[0];
                return;
                
                case HandStates.Interactable:
                sprite.sprite = hand.handSprites[1];
                return;

                case HandStates.Grab:
                sprite.sprite = hand.handSprites[2];
                return;
            }
        }

        public void changeInteractable(GameObject gameObject, UnityAction StartAction, UnityAction EndAction)
        {
            if(hand.state != HandStates.Grab)
            interactable = gameObject;
            startAction = StartAction;
            endAction = EndAction;
        }
    }   
}
