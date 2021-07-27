using UnityEngine;
namespace Murgn.Player
{
    public enum HandStates {Idle, Interactable, Grab}

    public class Hand : MonoBehaviour
    {
        public HandStates state;
        public Sprite[] handSprites;
    }   
}
