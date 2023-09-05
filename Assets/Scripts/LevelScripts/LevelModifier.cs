using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelModifier : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemies;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject spawner;

    [SerializeField] public List<StatusData> enemyStatuses;
    [SerializeField] public List<StatusData> playerStatuses;
    [SerializeField] public List<SpawnData> spawnStatuses;



    private void Start()
    {
        UpdateStatuses();
    }

    private void UpdateStatuses()
    {
        //Добавляем статусы врагу
        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<StatusCalculation>().activeStatuses = enemyStatuses;
        }

        spawner.GetComponent<SpawnCalculation>().activeSpawners = spawnStatuses;

        //Добавляем статусы игроку
        player.GetComponent<StatusCalculation>().activeStatuses = playerStatuses;
    }
}
