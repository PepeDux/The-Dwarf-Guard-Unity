using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class StatusCalculation : MonoBehaviour
{
    [SerializeField] private StatusData[] statuses;
    [SerializeField] List<string> activeStatusName = new List<string>();

    public string statusAdd; // Переменная принимает значение добавляемого статуса
    public string statusRemove; // Переменная принимает значение удаляемого статуса
    private int mod = 1; // Модификатор использующийся для расчета добавления и удаления статуса из объекта


    public void Update()
    {
        Change();
    }
    public void Change()
    {
        statuses = Resources.LoadAll<StatusData>("Statuses");

        if(statusAdd != null && statusAdd != "")
        {
            if (!activeStatusName.Contains(statusAdd))
            {
                Сalculation();
                activeStatusName.Add(statusAdd);
                statusAdd = null;
            }
        }

        if (statusRemove != null && statusRemove != "")
        {
            if (activeStatusName.Contains(statusRemove))
            {
                Сalculation();
                activeStatusName.Remove(statusRemove);
                statusRemove = null;
            }

        }
    }


    public void Сalculation()
    {
        foreach (StatusData status in statuses)
        {
            if (status.name == statusAdd || status.name == statusRemove)
            {
                if(status.name == statusAdd)
                {
                    mod = 1;
                }
                else if(status.name == statusRemove)
                {
                    mod = -1;
                }                

                GetComponent<MainObject>().strengthBonus += mod * status.strength;
                GetComponent<MainObject>().agilityBonus += mod * status.agility;
                GetComponent<MainObject>().intelBonus += mod * status.intel;
                GetComponent<MainObject>().constitutionBonus += mod * status.constitution;
                GetComponent<MainObject>().wisdomBonus += mod * status.wisdom;

                GetComponent<MainObject>().carryingCapacityBonus += mod * status.carryingCapacity;
                GetComponent<MainObject>().speedBonus += mod * status.speed;
                GetComponent<MainObject>().attackSpeedBonus += mod * status.attackSpeed;
                GetComponent<MainObject>().criticalDamageBonus += mod * status.criticalDamage;
                GetComponent<MainObject>().criticalDamageChanceBonus += mod * status.CriticalDamageChance;
                GetComponent<MainObject>().precisionBonus += mod * status.Precision;
                GetComponent<MainObject>().drunkennessBonus += mod * status.drunkenness;

                GetComponent<MainObject>().prickResistBonus += mod * status.prickResist;
                GetComponent<MainObject>().slashResistBonus += mod * status.slashResist;
                GetComponent<MainObject>().crushResistBonus += mod * status.CrushResist;
                GetComponent<MainObject>().poisonResistBonus += mod * status.poisonResist;
                GetComponent<MainObject>().fireResistBonus += mod * status.fireResist;
                GetComponent<MainObject>().frostResistBonus += mod * status.frostResist;
                GetComponent<MainObject>().curseResistBonus += mod * status.curseResist;
                GetComponent<MainObject>().electricalResistBonus += mod * status.electricalResist;
                GetComponent<MainObject>().drunkennessResistBonus += mod * status.drunkennessResist;
            }
        }
    }
}
