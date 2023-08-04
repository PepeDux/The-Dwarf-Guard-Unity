using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class PickUpObjectSpawner : Spawner
{
    public GameObject[] food; //Еда
    public GameObject[] money; //Монеты
    public GameObject[] crystal; //Кристаллы



    public void SpawnPickUpObject()
    {
        for (int i = 0; i < LevelInfo.food; i++)
        {
            Spawn(food);
        }

        for (int i = 0; i < LevelInfo.money; i++)
        {
            Spawn(money);
        }

        for (int i = 0; i < LevelInfo.crystal; i++)
        {
            Spawn(crystal);
        }
    }
}
