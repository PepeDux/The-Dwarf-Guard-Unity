using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEditor.Experimental.SceneManagement;
using UnityEngine;

public class StatusCalculation : MonoBehaviour
{
    [SerializeField] public List<StatusData> activeStatuses = new List<StatusData>();



    private void Start()
    {
        foreach (StatusData status in activeStatuses)
        {
            Ñalculation(status, 1);
        }
    }


    public void AddStatus(StatusData status)
    {
        if (status != null)
        {
            if (!activeStatuses.Contains(status))
            {
                Ñalculation(status, 1);
                activeStatuses.Add(status);
            }
        }

    }

    public void RemoveStatus(StatusData status)
    {
        if (status != null)
        {
            if (activeStatuses.Contains(status))
            {
                Ñalculation(status, -1);
                activeStatuses.Remove(status);
            }
        }
    }



    public void Ñalculation(StatusData status, int mod)
    {
        GetComponent<MainObject>().strengthBonus += mod * status.strength;
        GetComponent<MainObject>().dexterityBonus += mod * status.agility;
        GetComponent<MainObject>().inteligenceBonus += mod * status.intel;
        GetComponent<MainObject>().constitutionBonus += mod * status.constitution;
        GetComponent<MainObject>().wisdomBonus += mod * status.wisdom;

        GetComponent<MainObject>().criticalDamageBonus += mod * status.criticalDamage;
        GetComponent<MainObject>().criticalDamageChanceBonus += mod * status.CriticalDamageChance;
        GetComponent<MainObject>().precisionBonus += mod * status.Precision;
        GetComponent<MainObject>().drunkennessBonus += mod * status.drunkenness;

        GetComponent<MainObject>().poisonResistBonus += mod * status.poisonResist;
        GetComponent<MainObject>().fireResistBonus += mod * status.fireResist;
        GetComponent<MainObject>().frostResistBonus += mod * status.frostResist;
        GetComponent<MainObject>().drunkennessResistBonus += mod * status.drunkennessResist;
    }
}
