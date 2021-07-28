using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Murgn;
using UnityEngine.Experimental.Rendering.Universal;

namespace Murgn
{
    public class MonitorTurnOn : MonoBehaviour
    {
        public Light2D light2D;
        bool turnedOn;

        void Update()
        {
            if(!turnedOn && light2D.GetComponent<LightExpander>().increment >= light2D.GetComponent<LightExpander>().max)
            {
                GetComponent<Animator>().SetTrigger("TurnOn");
                turnedOn = true;
            }
        }
    }   
}
