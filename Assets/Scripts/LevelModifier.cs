using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelModifier : MonoBehaviour
{
    [SerializeField] public List<GameObject> enemies;
    [SerializeField] private GameObject player;

    [SerializeField] public List<StatusData> enemyStatuses;
    [SerializeField] public List<StatusData> playerStatuses;
    [SerializeField] public List<StatusData> GlobalStatuses;



    public void Start()
    {
        UpdateStatuses();
    }

    public void UpdateStatuses()
    {
        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<StatusCalculation>().activeStatuses = enemyStatuses;
        }

        player.GetComponent<StatusCalculation>().activeStatuses = playerStatuses;
    }
}
