using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionalObjectSpawner : Spawner
{
    [Header("Спавнящиеся объекты")]
    public GameObject[] trap; //Ловушки
    public GameObject[] food; //Еда
    public GameObject[] money; //Монеты
    public GameObject[] crystal; //Кристаллы



    public void SpawnFunctionalObject()
    {
        for (int i = 0; i < generateLevelInfo.trap; i++)
        {
            Spawn(trap);
        }

        for (int i = 0; i < generateLevelInfo.food; i++)
        {
            Spawn(food);
        }

        for (int i = 0; i < generateLevelInfo.money; i++)
        {
            Spawn(money);
        }

        for (int i = 0; i < generateLevelInfo.crystal; i++)
        {
            Spawn(crystal);
        }
    }
}
