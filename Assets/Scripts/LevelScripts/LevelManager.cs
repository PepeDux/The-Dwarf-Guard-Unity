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

    public static Action levelEnded;

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

    public void LevelGenerate()
    {
        enemies.GetComponent<EnemySpawner>().SpawnEnemy();
        staticTileObjects.GetComponent<StaticTileObjectSpawner>().SpawnStaticTileObject();
        functionalObjects.GetComponent<FunctionalObjectSpawner>().SpawnFunctionalObject();
        player.GetComponent<PlayerSpawner>().SpawnPlayer();
    }
}
