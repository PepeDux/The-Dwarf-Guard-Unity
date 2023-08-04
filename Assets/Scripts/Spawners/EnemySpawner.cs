using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    public GameObject[] melee;
    public GameObject[] range;
    public GameObject[] captain;
    public GameObject[] wizard;

   
    public void SpawnEnemy()
    {
        for (int i = 0; i < LevelInfo.melee; i++) 
        {
            Spawn(melee);
        }

        for (int i = 0; i < LevelInfo.range; i++)
        {
            Spawn(range);
        }

        for (int i = 0; i < LevelInfo.captain; i++)
        {
            Spawn(captain);
        }

        for (int i = 0; i < LevelInfo.wizard; i++)
        {
            Spawn(wizard);
        }
    }


}
