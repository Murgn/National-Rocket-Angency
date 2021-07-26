using UnityEngine;

namespace Murgn
{
    public enum JoystickStates {Forward, Back, Left, Right}

    public class Joystick : MonoBehaviour
    {
        public JoystickStates states;
    }   
}
