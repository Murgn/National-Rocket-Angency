using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Murgn;
using UnityEngine.UI;

namespace Murgn
{
    public class HandController : MonoBehaviour
    {
        

        void Update()
        {
            transform.position = Input.mousePosition;
        }
    }   
}
