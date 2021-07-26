using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Murgn;
using UnityEngine.UI;

namespace Murgn.Player
{
    public class HandController : MonoBehaviour
    {
        private Hand hand;
        private Image sprite;
        
        void Awake()
        {
            hand = GetComponent<Hand>();
            sprite = transform.GetChild(0).GetComponent<Image>();
        }

        void Update()
        {
            transform.position = Input.mousePosition;
            handStates();
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
    }   
}
