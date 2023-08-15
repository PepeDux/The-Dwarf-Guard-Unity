using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class StaticTileObjectSpawner : Spawner
{
    [Header("����������� �������")]
    public GameObject[] wall; //�����
    public GameObject[] pit; //���



    public void SpawnStaticTileObject()
    {
        for (int i = 0; i < levelInfo.wall; i++)
        {
            Spawn(wall);
        }

        for (int i = 0; i < levelInfo.pit; i++)
        {
            Spawn(pit);
        }
    }
}
