using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCalculation : MonoBehaviour
{
    public string currentWeapon;
    public string lastWeapon;
    private int mod = 1;

    [SerializeField] private WeaponData[] weapons;

    void Start()
    {
        weapons = Resources.LoadAll<WeaponData>("Weapons");
    }
    void FixedUpdate()
    {
        ChangeWeapon();
    }

    private void ChangeWeapon()
    {
        if (currentWeapon != null && currentWeapon != "")
        {
            Calculation();
            currentWeapon = null;                 
        }
    }

    private void Calculation()
    {
        foreach (WeaponData weapon in weapons)
        {
            if (weapon.name == currentWeapon || weapon.name == lastWeapon)
            {
                if (weapon.name == currentWeapon)
                {
                    mod = 1;
                }
                else if (weapon.name == lastWeapon)
                {
                    mod = -1;
                }

                GetComponent<MainObject>().strengthBonus += mod * weapon.strength;
                GetComponent<MainObject>().agilityBonus += mod * weapon.agility;
                GetComponent<MainObject>().intelBonus += mod * weapon.intel;
                GetComponent<MainObject>().constitutionBonus += mod * weapon.constitution;
                GetComponent<MainObject>().wisdomBonus += mod * weapon.wisdom;

                GetComponent<MainObject>().carryingCapacityBonus += mod * weapon.carryingCapacity;
                GetComponent<MainObject>().speedBonus += mod * weapon.speed;
                GetComponent<MainObject>().attackSpeedBonus += mod * weapon.attackSpeed;
                GetComponent<MainObject>().criticalDamageBonus += mod * weapon.criticalDamage;
                GetComponent<MainObject>().criticalDamageChanceBonus += mod * weapon.CriticalDamageChance;
                GetComponent<MainObject>().precisionBonus += mod * weapon.Precision;
                GetComponent<MainObject>().drunkennessBonus += mod * weapon.drunkenness;

                GetComponent<MainObject>().prickResistBonus += mod * weapon.prickResist;
                GetComponent<MainObject>().slashResistBonus += mod * weapon.slashResist;
                GetComponent<MainObject>().crushResistBonus += mod * weapon.CrushResist;
                GetComponent<MainObject>().poisonResistBonus += mod * weapon.poisonResist;
                GetComponent<MainObject>().fireResistBonus += mod * weapon.fireResist;
                GetComponent<MainObject>().frostResistBonus += mod * weapon.frostResist;
                GetComponent<MainObject>().curseResistBonus += mod * weapon.curseResist;
                GetComponent<MainObject>().electricalResistBonus += mod * weapon.electricalResist;
                GetComponent<MainObject>().drunkennessResistBonus += mod * weapon.drunkennessResist;

                GetComponent<MainObject>().hammerWayBonus += mod * weapon.hammerWay;
                GetComponent<MainObject>().gearWayBonus += mod * weapon.gearWay;
                GetComponent<MainObject>().anvilWayBonus += mod * weapon.anvilWay;
                GetComponent<MainObject>().beerWayBonus += mod * weapon.beerWay;
                GetComponent<MainObject>().runeWayBonus += mod * weapon.runeWay;

                GetComponent<MainObject>().prickDamageWeapon += mod * weapon.prickDamageWeapon;
                GetComponent<MainObject>().slashDamageWeapon += mod * weapon.slashDamageWeapon;
                GetComponent<MainObject>().crushDamageWeapon += mod * weapon.crushDamageWeapon;
                GetComponent<MainObject>().poisonDamageWeapon += mod * weapon.poisonDamageWeapon;
                GetComponent<MainObject>().fireDamageWeapon += mod * weapon.fireDamageWeapon;
                GetComponent<MainObject>().frostDamageWeapon += mod * weapon.frostDamageWeapon;
                GetComponent<MainObject>().curseDamageWeapon += mod * weapon.curseDamageWeapon;
                GetComponent<MainObject>().electricalDamageWeapon += mod * weapon.electricalDamageWeapon;
                GetComponent<MainObject>().drunkennessDamageWeapon += mod * weapon.drunkennessDamageWeapon;


            }
        }
    }
}
