using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevel : MonoBehaviour
{
    private GameObject enemies;
    private GameObject staticTileObjects;
    private GameObject pickUpObjects;
    void Start()
    {
        enemies = GameObject.Find("Enemies");
        staticTileObjects = GameObject.Find("StaticTileObjects");
        pickUpObjects = GameObject.Find("PickUpObjects");
        Level();
    }


    public void Level()
    {
        enemies.GetComponent<EnemySpawner>().SpawnEnemy();
        staticTileObjects.GetComponent<StaticTileObjectSpawner>().SpawnStaticTileObject();
        pickUpObjects.GetComponent<PickUpObjectSpawner>().SpawnPickUpObject(); 

    }
}
