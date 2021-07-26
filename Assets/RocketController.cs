using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Murgn;

namespace Murgn
{
    public class RocketController : MonoBehaviour
    {
        private Joystick joystick;
        private Rigidbody2D rb;

        void Awake()
        {
            joystick = GameObject.Find("Joystick").GetComponent<Joystick>();
            rb = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            switch(joystick.state)
            {
                case JoystickStates.Idle:
                rb.velocity = Vector3.zero;
                return;

                case JoystickStates.Up:
                rb.AddRelativeForce(Vector3.up);
                return;
                
                case JoystickStates.Down:
                rb.AddRelativeForce(Vector3.down);
                return;

                case JoystickStates.Left:
                rb.AddTorque(.1f);
                return;

                case JoystickStates.Right:
                rb.AddTorque(-.1f);
                return;
            }
        }
    }   
}
