using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class StaticTileObjectSpawner : Spawner
{
    public GameObject[] wall; //�����
    public GameObject[] trap; //�������
    public GameObject[] pit; //���



    public void SpawnStaticTileObject()
    {
        for (int i = 0; i < LevelInfo.wall; i++)
        {
            Spawn(wall);
        }

        for (int i = 0; i < LevelInfo.trap; i++)
        {
            Spawn(trap);
        }

        for (int i = 0; i < LevelInfo.pit; i++)
        {
            Spawn(pit);
        }
    }
}
