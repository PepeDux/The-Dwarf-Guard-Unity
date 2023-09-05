using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private GameObject enemies;
    private GameObject staticTileObjects;
    private GameObject functionalObjects;

    public static int currentLevel = 1;

    public static Action LevelEnded;

    private void OnEnable()
    {
        CardMaker.endSelectCard += LevelGenerate;
    }
    private void OnDisable()
    {
        CardMaker.endSelectCard -= LevelGenerate;
    }
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
        player.GetComponent<PlayerSpawner>().SpawnPlayer();
    }

    private void CheckLevel()
    {
        ///Добавить условие очистки поля
        if(TurnManager.turnCount == 20)
        {
            TurnManager.turnCount = 1;
            LevelEnded?.Invoke();
            
            //LevelGenerate();
            //TurnManager.turnCount = 1;
        }
    }
}
