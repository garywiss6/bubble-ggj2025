using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AllIn1SpriteShader
{
    [ExecuteInEditMode]
    public class SetGlobalTime : MonoBehaviour
    {
        int globalTime;

        void OnApplicationQuit()
        {
            Shader.SetGlobalFloat(globalTime, 0);
        }

        void Start()
        {
            globalTime = Shader.PropertyToID("globalUnscaledTime");
        }

        void Update()
        {
            Shader.SetGlobalFloat(globalTime, Time.unscaledTime / 20f);
        }
    }
}