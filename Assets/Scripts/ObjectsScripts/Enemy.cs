using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MainObject
{
    public void FixedUpdate() 
    {
        Updater();
    }  
}
