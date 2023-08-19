using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class StaticTileObjectSpawner : Spawner
{
    [Header("Спавнящиеся объекты")]
    public GameObject[] wall; //Стена
    public GameObject[] pit; //Яма



    public void SpawnStaticTileObject()
    {
        for (int i = 0; i < generateLevelInfo.wall; i++)
        {
            Spawn(wall);
        }

        for (int i = 0; i < generateLevelInfo.pit; i++)
        {
            Spawn(pit);
        }
    }
}
