using EZCameraShake;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Tilemaps;
using static Cinemachine.DocumentationSortingAttribute;

public class Test : MonoBehaviour
{
    [SerializeField] public List<GameObject> enemies;
    [SerializeField] public List<StatusData> statuses;

    

    public void Start()
    {
        UpdateStatuses();
    }

    public void UpdateStatuses()
    {
        foreach(GameObject enemy in enemies)
        {
            enemy.GetComponent<StatusCalculation>().activeStatuses = statuses;
        }
    }
}
