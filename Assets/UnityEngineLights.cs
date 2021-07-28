#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Murgn;
using UnityEngine.Experimental.Rendering.Universal;

namespace Murgn
{
    [ExecuteInEditMode]
    public class UnityEngineLights : MonoBehaviour
    {
        public bool enable;

        void Update()
        {
            if(Application.isPlaying)
            {
                GetComponent<Light2D>().intensity = 0;
                return;
            }

            if(enable)
            GetComponent<Light2D>().intensity = 1;
        }
        
    }   
}
#endif
