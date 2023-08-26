using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private GameObject enemies;
    private GameObject staticTileObjects;
    private GameObject pickUpObjects;
    private GameObject functionalObjects;

    [SerializeField] private GameObject player;

    public static int currentLevel = 1;

    private bool b = true;

    public static Action LevelEnded;
    private void Start()
    {
        enemies = GameObject.Find("Enemies");
        staticTileObjects = GameObject.Find("StaticTileObjects");
        functionalObjects = GameObject.Find("FunctionalObjects");
        LevelGenerate();
    }

    private void Update()
    {
        CheckLevel();
    }


    public void LevelGenerate()
    {
        enemies.GetComponent<EnemySpawner>().SpawnEnemy();
        staticTileObjects.GetComponent<StaticTileObjectSpawner>().SpawnStaticTileObject();
        functionalObjects.GetComponent<FunctionalObjectSpawner>().SpawnFunctionalObject();
    }

    private void CheckLevel()
    {
        ///�������� ������� ������� ����
        if((player == null || TurnManager.turnCount == 20) && b == true)
        {
            b = false;
            LevelEnded?.Invoke();
            
            //LevelGenerate();
            //TurnManager.turnCount = 1;
        }
    }
}