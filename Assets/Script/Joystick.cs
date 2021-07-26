using UnityEngine;

namespace Murgn
{
    public enum JoystickStates {Idle, Forward, Back, Left, Right}

    public class Joystick : MonoBehaviour
    {
        public JoystickStates state;
        public Sprite[] joystickSprites;
    }   
}
