using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : Spawner
{
    [Header("Спавнящиеся объекты")]
    public GameObject[] player;


    public void SpawnPlayer()
    {
        for (int i = 0; i < 1; i++)
        {
            Spawn(player);
        }
    }
}
