using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCalculation : MonoBehaviour
{
    [SerializeField] public List<SpawnData> activeSpawners = new List<SpawnData>();



    private void Start()
    {
        foreach (SpawnData spawn in activeSpawners)
        {
            Ñalculation(spawn, 1);
        }
    }


    public void AddSpawn(SpawnData spawn)
    {
        if (spawn != null)
        {
            Ñalculation(spawn, 1);
            activeSpawners.Add(spawn);
        }

    }

    public void RemoveSpawn(SpawnData spawn)
    {
        if (spawn != null)
        {
            if (activeSpawners.Contains(spawn))
            {
                Ñalculation(spawn, -1);
                activeSpawners.Remove(spawn);
            }
        }
    }



    public void Ñalculation(SpawnData spawn, int mod)
    {
        GetComponent<LevelInfo>().melee += mod * spawn.melee;
        GetComponent<LevelInfo>().range += mod * spawn.range;
        GetComponent<LevelInfo>().captain += mod * spawn.captain;
        GetComponent<LevelInfo>().wizard += mod * spawn.wizard;

        GetComponent<LevelInfo>().wall += mod * spawn.wall;
        GetComponent<LevelInfo>().pit += mod * spawn.pit;

        GetComponent<LevelInfo>().trap += mod * spawn.trap;
        GetComponent<LevelInfo>().food += mod * spawn.food;
        GetComponent<LevelInfo>().money += mod * spawn.money;
        GetComponent<LevelInfo>().crystal += mod * spawn.crystal;
    }
}
