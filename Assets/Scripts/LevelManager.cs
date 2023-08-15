using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private GameObject enemies;
    private GameObject staticTileObjects;
    private GameObject pickUpObjects;
    private GameObject functionalObjects;
    void Start()
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
    }
}
