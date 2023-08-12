using EZCameraShake;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Tilemaps;

public class Test : MonoBehaviour
{
    public static Action action;
    



    void Update()
    {
        if(Input.GetKeyUp(KeyCode.V))
        {
            action?.Invoke();
        }
    }
}
