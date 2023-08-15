using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PermanentCalculation : MonoBehaviour
{
    public void Ñalculation(FunctionalObjectData functionalObject)
    {
        GetComponent<MainObject>().HP += functionalObject.HP;

        GetComponent<TakeDamageScript>().TakeDamage(physicalDamage: functionalObject.physicalDamage);

        GetComponent<MainObject>().movePoint += functionalObject.movePoint;
        GetComponent<MainObject>().actionPoints += functionalObject.actionPoint;
        GetComponent<MainObject>().beerPoint += functionalObject.beerPoint;

        GetComponent<MainObject>().strengthBonus += functionalObject.strength;
        GetComponent<MainObject>().dexterityBonus += functionalObject.agility;
        GetComponent<MainObject>().inteligenceBonus += functionalObject.intel;
        GetComponent<MainObject>().constitutionBonus += functionalObject.constitution;
        GetComponent<MainObject>().wisdomBonus += functionalObject.wisdom;

        GetComponent<MainObject>().criticalDamageBonus += functionalObject.criticalDamage;
        GetComponent<MainObject>().criticalDamageChanceBonus += functionalObject.CriticalDamageChance;
        GetComponent<MainObject>().precisionBonus += functionalObject.Precision;
        GetComponent<MainObject>().drunkennessBonus += functionalObject.drunkenness;

        GetComponent<MainObject>().poisonResistBonus += functionalObject.poisonResist;
        GetComponent<MainObject>().fireResistBonus += functionalObject.fireResist;
        GetComponent<MainObject>().frostResistBonus += functionalObject.frostResist;
        GetComponent<MainObject>().drunkennessResistBonus += functionalObject.drunkennessResist;


    }
}
