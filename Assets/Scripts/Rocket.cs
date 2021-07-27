using UnityEngine;
namespace Murgn
{
    public enum RocketStates {Idle, Active}
    public class Rocket : MonoBehaviour
    {
        public RocketStates state;
        public Sprite[] rocketSprites;
        public float speed;
        public float rotationSpeed;
        public float maxVelocity;

        public bool canMove = true;
    }   
}
