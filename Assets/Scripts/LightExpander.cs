using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Murgn;
using UnityEngine.Experimental.Rendering.Universal;

namespace Murgn
{
    public class LightExpander : MonoBehaviour
    {
        public Light2D light2D;
        public float increment;
        public float max;

        public bool turnOnTheLights = true;

        private void Update()
        {
            if(turnOnTheLights)
            {
                if(increment > max) return;
                light2D.pointLightInnerRadius += increment * Time.deltaTime;
                light2D.pointLightOuterRadius += increment * Time.deltaTime;
                increment += increment * Time.deltaTime;
            }
            
        }
    }   
}
