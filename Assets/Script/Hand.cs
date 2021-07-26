using UnityEngine;
namespace Murgn.Player
{
    public enum State {Idle, Interactable, Grab}

    public class Hand : MonoBehaviour
    {
        public State state;
        public Sprite[] handSprites;
    }   
}
