using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainObject : MonoBehaviour
{
    public Animator anim;

    public GameObject[] loot;
    public static int randomEnemy;


    #region Characteristic

    private int freeCharacteristicLevel = 0;
    public int CharacteristicLevel = 0;
    public int maxCharacteristicLevel = 10;

    //Здоровье
    public float HP;
    public float maxHP = 100;
    public int HPCharac = 1;
    public int maxHPCharac = 10;

    //Энергия
    public float energy = 0;
    public float maxEnergy = 30;
    public float energyWaste = 10;
    public int energyCharac = 1;
    public int maxEnergyCharac = 10;

    //Скорость востановления энергии
    public float energyRegeneration = 0;
    public float maxEnergyRegeneration = 30;
    public int energyCharacRegeneration = 1;
    public int maxEnergyCharacRegeneration = 10;

    //Броня
    public float armor = 0;
    public float maxArmor = 100;
    public int armorCharac = 1;
    public int maxArmorCharac = 10;

    //Урон
    public int damage = 0;
    public int maxDamage = 100;

    //Опыт
    public float XP = 0;
    public float maxXP = 100;

    //Уровень
    public int level = 0;
    public int maxLevel = 10;

    //Деньги
    public int money = 0;






    //Сила
    public int strength = 0;
    public int maxStrength = 10;
    public int strengthCharac = 0;
    public int maxStrengthCharac = 10;

    //Ловкость
    public int agility = 0;
    public int maxAgility = 10;
    public int agilityCharac = 0;
    public int maxAgilityhCharac = 10;

    //Интеллект
    public int intel = 0;
    public int maxIntel = 10;
    public int intelCharac = 0;
    public int maxIntelCharac = 10;

    //Телосложение
    public int constitution = 0;
    public int maxConstitution = 10;
    public int constitutionCharac = 0;
    public int maxConstitutionCharac = 10;

    //Мудрость
    public int wisdom = 0;
    public int maxWisdom = 10;
    public int wisdomCharac = 0;
    public int maxWisdomCharac = 10;





    //Уклонение
    public int dodge = 0;
    public int maxDodge = 10;
    public int dodgeCharac = 0;
    public int maxDodgeCharac = 10;

    //Переносимый вес
    public int carryingCapacity = 0;
    public int maxCarryingCapacity = 10;
    public int carryingCapacityCharac = 1;
    public int maxCarryingCapacityCharac = 10;

    //Скорость
    public float speed = 2f;
    public float maxSpeed = 10f;
    public int speedCharac = 1;
    public int maxSpeecCharac = 10;

    //Скорость атаки
    public float attackSpeed = 0;
    public float maxAttackSpeed = 10;
    public float attackSpeedCharac = 0;
    public float maxAttackSpeedCharac = 10;

    //Критический урон
    public float criticalDamage = 0;
    public float maxCriticalDamage = 10;
    public float criticalDamageCharac = 0;
    public float maxCriticalDamageCharac = 10;

    //Точность
    public float precision = 0;
    public float maxPrecisionDamage = 10;
    public float precisionCharac = 0;
    public float maxPrecisionDamageCharac = 10;





    //Сытость
    public int satiety = 0;
    public int maxSatiety = 10;

    //Опьянение
    public int drunkenness = 0;
    public int maxDrunkenness = 10;




    //Сопротивление огню
    public float fireResist = 0;
    public int maxFireResist = 10;
    public int fireResistCharac = 0;
    public int maxFireResistCharac = 10;

    //Сопротивление ядам
    public float poisonResist = 0;
    public int maxPoisonResist = 100;
    public int poisonResistCharac = 0;
    public int maxPoisonResistCharac = 10;

    //Сопростивление морозу
    public float frostResist = 0;
    public int maxFrostResist = 10;
    public int frostResistCharac = 0;
    public int maxFrostResistCharac = 10;

    //Сопротивление проклятию
    public float curseResist = 0;
    public int maxCurseResist = 10;
    public int curseResistCharac = 0;
    public int maxCurseResistCharac = 10;

    //Сопротивление рунной магии
    public float runesResist = 0;
    public int maxRunesResist = 10;
    public int runesResistCharac = 0;
    public int maxRunesResistCharac = 10;

    #endregion


    #region Talents




    #endregion

    public bool statusPoison = false;
    public bool statusFire = false;
    public bool statusCurse = false;
    public bool statusFrost = false;
    public bool statusDrunkenness = false;




    public void TakeDamage(float damage)
    {
        HP -= damage;

        if (damage > 0)
        {
            HP -= damage;
            anim.SetTrigger("TakeDamage");
        }

        if (HP <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("I die");

        //loot = UnityEngine.Random.Range(0, loot.Length);



        Instantiate(loot[randomEnemy], transform.position, transform.rotation);

        this.enabled = false;
    }
}