using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class StatusData : MonoBehaviour
{
    [SerializeField] private EffectData[] statuses;
    [SerializeField] List<string> activeStatusName = new List<string>();

    public string statusAdd; // Переменная принимает значение добавляемого статуса
    public string statusRemove; // Переменная принимает значение удаляемого статуса
    private int mod = 1;


    public void Update()
    {
        Change();
    }
    public void Change()
    {
        statuses = Resources.LoadAll<EffectData>("PereodicEffects");

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
                activeStatusName.Remove(statusRemove);
                Сalculation();
                statusRemove = null;
            }

        }
    }


    public void Сalculation()
    {
        foreach (EffectData effect in statuses)
        {
            if (effect.name == statusAdd || effect.name == statusRemove)
            {
                if(effect.name == statusAdd)
                {
                    mod = 1;
                }
                else if(effect.name == statusRemove)
                {
                    mod = -1;
                }                

                GetComponent<MainObject>().strengthBonus += mod * effect.strength;
                GetComponent<MainObject>().agilityBonus += mod * effect.agility;
                GetComponent<MainObject>().intelBonus += mod * effect.intel;
                GetComponent<MainObject>().constitutionBonus += mod * effect.constitution;
                GetComponent<MainObject>().wisdomBonus += mod * effect.wisdom;

                GetComponent<MainObject>().carryingCapacityBonus += mod * effect.carryingCapacity;
                GetComponent<MainObject>().speedBonus += mod * effect.speed;
                GetComponent<MainObject>().attackSpeedBonus += mod * effect.attackSpeed;
                GetComponent<MainObject>().criticalDamageBonus += mod * effect.criticalDamage;
                GetComponent<MainObject>().criticalDamageChanceBonus += mod * effect.CriticalDamageChance;
                GetComponent<MainObject>().precisionBonus += mod * effect.Precision;
                GetComponent<MainObject>().drunkennessBonus += mod * effect.drunkenness;

                GetComponent<MainObject>().prickResistBonus += mod * effect.prickResist;
                GetComponent<MainObject>().slashResistBonus += mod * effect.slashResist;
                GetComponent<MainObject>().crushResistBonus += mod * effect.CrushResist;
                GetComponent<MainObject>().poisonResistBonus += mod * effect.poisonResist;
                GetComponent<MainObject>().fireResistBonus += mod * effect.fireResist;
                GetComponent<MainObject>().frostResistBonus += mod * effect.frostResist;
                GetComponent<MainObject>().curseResistBonus += mod * effect.curseResist;
                GetComponent<MainObject>().electricalResistBonus += mod * effect.electricalResist;
                GetComponent<MainObject>().drunkennessResistBonus += mod * effect.drunkennessResist;
            }
        }
    }
}
