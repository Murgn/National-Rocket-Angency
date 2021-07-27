using UnityEngine;

namespace Murgn
{
    public enum JoystickStates {Idle, Up, Down, Left, Right}

    public class Joystick : MonoBehaviour
    {
        public JoystickStates state;
        public Sprite[] joystickSprites;
    }   
}
