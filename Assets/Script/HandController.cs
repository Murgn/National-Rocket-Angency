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
        private Image handImage;

        public Sprite[] handSprites;
        
        void Awake()
        {
            hand = GetComponent<Hand>();
            handImage = transform.GetChild(0).GetComponent<Image>();
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
                handImage.sprite = handSprites[0];
                return;
                
                case State.Interactable:
                handImage.sprite = handSprites[1];
                return;

                case State.Grab:
                handImage.sprite = handSprites[2];
                return;
            }
        }
    }   
}
