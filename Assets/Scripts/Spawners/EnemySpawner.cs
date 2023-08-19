using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    [Header("Спавнящиеся объекты")]
    public GameObject[] melee;
    public GameObject[] range;
    public GameObject[] captain;
    public GameObject[] wizard;

   
    public void SpawnEnemy()
    {
        for (int i = 0; i < generateLevelInfo.melee; i++) 
        {
            Spawn(melee);
        }

        for (int i = 0; i < generateLevelInfo.range; i++)
        {
            Spawn(range);
        }

        for (int i = 0; i < generateLevelInfo.captain; i++)
        {
            Spawn(captain);
        }

        for (int i = 0; i < generateLevelInfo.wizard; i++)
        {
            Spawn(wizard);
        }
    }


}
