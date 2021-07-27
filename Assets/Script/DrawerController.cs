using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Murgn.Player;
using UnityEngine.Events;

namespace Murgn
{
    public class DrawerController : MonoBehaviour
    {
        private Drawer drawer;
        private Hand hand;

        private UnityAction startGrab;
        private UnityAction endGrab;
        public Vector2 startGrabPos;
        public float offset;

        private Vector3 _transform;
        public Vector2 lowPoint;

        void Awake()
        {
            drawer = GetComponent<Drawer>();
            hand = GameObject.Find("Canvas/Hands").GetComponent<Hand>();

            

            _transform = transform.position;

            startGrab += OnGrab;
            endGrab += EndGrab;
        }

        void LateUpdate()
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, _transform.x, _transform.x), Mathf.Clamp(transform.position.y, lowPoint.y, _transform.y), 0);
        }

        void OnMouseOver()
        {
            hand.GetComponent<HandController>().changeInteractable(gameObject, startGrab, endGrab);
        }

        void OnGrab()
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(transform.position.x, mousePos.y);
        }

        void EndGrab()
        {
            hand.GetComponent<HandController>().changeInteractable(null, null, null);
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
    }   
}
