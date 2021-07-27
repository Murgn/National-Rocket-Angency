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
        private Rocket rocket;
        private SpriteRenderer sprite;

        

        void Awake()
        {
            joystick = GameObject.Find("Joystick").GetComponent<Joystick>();
            rb = GetComponent<Rigidbody2D>();
            rocket = GetComponent<Rocket>();
            sprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        }

        void Update()
        {
            rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -rocket.maxVelocity, rocket.maxVelocity), Mathf.Clamp(rb.velocity.y, -rocket.maxVelocity, rocket.maxVelocity));
            rb.angularVelocity = Mathf.Clamp(rb.angularVelocity, -rocket.maxVelocity * 50, rocket.maxVelocity * 50);
            Animate();
        }

        void FixedUpdate()
        {
            Movement();
        }

        void Animate()
        {
            if(!rocket.canMove) return;

            if(joystick.state != JoystickStates.Idle) rocket.state = RocketStates.Active;
            else rocket.state = RocketStates.Idle;

            switch(rocket.state)
            {
                case RocketStates.Idle:
                sprite.sprite = rocket.rocketSprites[0];
                return;

                case RocketStates.Active:
                sprite.sprite = rocket.rocketSprites[1];
                return;
            }
        }

        void Movement()
        {
            if(!rocket.canMove) return;

            switch(joystick.state)
            {
                case JoystickStates.Idle:
                rb.velocity = rb.velocity * 0.95f;
                rb.angularVelocity = rb.angularVelocity * 0.95f;
                return;

                case JoystickStates.Up:
                rb.AddRelativeForce(Vector3.up * rocket.speed);
                rb.angularVelocity = rb.angularVelocity * 0.95f;
                return;
                
                case JoystickStates.Down:
                rb.AddRelativeForce(Vector3.down * rocket.speed);
                rb.angularVelocity = rb.angularVelocity * 0.95f;
                return;

                case JoystickStates.Left:
                rb.AddTorque(rocket.rotationSpeed);
                rb.velocity = rb.velocity * 0.95f;
                rb.angularVelocity = rb.angularVelocity * 0.95f;
                return;

                case JoystickStates.Right:
                rb.AddTorque(-rocket.rotationSpeed);
                rb.velocity = rb.velocity * 0.95f;
                rb.angularVelocity = rb.angularVelocity * 0.95f;
                return;
            }
        }
    }   
}
