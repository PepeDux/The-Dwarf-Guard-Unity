using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Security.Cryptography;
using UnityEngine.Rendering.PostProcessing;
using System;
using Random = UnityEngine.Random;

public class MainObject : MonoBehaviour
{
    [Header("Плюшки")]
    public Rigidbody2D rb;
    public Animator anim;

    public static int random;


    #region Characteristic

    private int freeCharacteristicLevel = 0;
    private int CharacteristicLevel = 0;
    private int maxCharacteristicLevel = 10;

    [Header("Первичные характеристики")]
    //Здоровье
    public float HP = 100;
    public float maxHP = 100;

    //Энергия
    public float energy = 30;
    public float maxEnergy = 100;
    public float energyWaste = 10;

    //Скорость востановления энергии
    private float energyRegeneration = 0;
    private float maxEnergyRegeneration = 30;

    //Монетки
    public int money = 0;

    //Физическая броня
    private float physicalArmor;
    private float maxPhysicalArmor;

    //Магическая броня
    private float magicArmor;
    private float maxMagicArmor;



    [Header("Уроны")]
    //Урон наносимый объектом
    //1 переменная - итоговый урон
    //2 переменная - урон от оружия
    //3 переменная - бонусный урон, отрицательный или положительный

    //Колющий урон
    public float prickDamage = 0;
    public float prickDamageWeapon = 6f;
    [HideInInspector] public float prickDamageBonus = 0;

    //Режущий урон
    public float slashDamage = 0;
    [HideInInspector] public float slashDamageWeapon = 1f;
    [HideInInspector] public float slashDamageBonus = 0;

    //Дробящий урон
    public float crushDamage = 0;
    [HideInInspector] public float crushDamageWeapon = 0f;
    [HideInInspector] public float crushDamageBonus = 0;

    //Ядовитый урон
    public float poisonDamage = 0;
    [HideInInspector] public float poisonDamageWeapon = 0f;
    [HideInInspector] public float poisonDamageBonus = 0;

    //Огненный урон
    public float fireDamage = 0;
    [HideInInspector] public float fireDamageWeapon = 0f;
    [HideInInspector] public float fireDamageBonus = 0;

    //Морозный урон
    public float frostDamage = 0;
    [HideInInspector] public float frostDamageWeapon = 0f;
    [HideInInspector] public float frostDamageBonus = 0;

    //Электрический урон
    public float electricalDamage = 0;
    [HideInInspector] public float electricalDamageWeapon = 0f;
    [HideInInspector] public float electricalDamageBonus = 0;

    //Проклятый урон
    public float curseDamage = 0;
    [HideInInspector] public float curseDamageWeapon = 0f;
    [HideInInspector] public float curseDamageBonus = 0;

    //Алкогольный урон
    public float drunkennessDamage = 0;
    [HideInInspector] public float drunkennessDamageWeapon = 0f;
    [HideInInspector] public float drunkennessDamageBonus = 0;



    [Header("Уровень и опыт")]
    //Опыт
    public float XP = 0;
    [HideInInspector] public float maxXP = 100;

    //Уровень
    public int level = 0;
    [HideInInspector] public int maxLevel = 10;



    [Header("Основнык характеристики")]
    //1 переменная - итоговове значение характеристики
    //2 переменная - текущее значение характеристики(в прокачке, независимо от бонусов)
    //3 переменная - максимальное допустимое значение характеристики(в прокачке, независимо от бонусов)
    //4 переменная - бонус к значению характеристики

    //Сила
    public int strength = 0;
    [HideInInspector] public int strengthCharac = 10;
    [HideInInspector] private int maxStrengthCharac = 100;
    [HideInInspector] public int strengthBonus = 0 ;

    //Ловкость
    public int agility = 0;
    [HideInInspector] public int agilityCharac = 10;
    [HideInInspector] private int maxAgilityCharac = 100;
    [HideInInspector] public int agilityBonus = 0;

    //Интеллект
    public int intel = 0;
    [HideInInspector] public int intelCharac = 10;
    [HideInInspector] private int maxIntelCharac = 100;
    [HideInInspector] public int intelBonus = 0;

    //Телосложение
    public int constitution = 0;
    [HideInInspector] public int constitutionCharac = 10;
    [HideInInspector] private int maxConstitutionCharac = 100;
    [HideInInspector] public int constitutionBonus = 0;

    //Мудрость
    public int wisdom = 0;
    [HideInInspector] public int wisdomCharac = 10;
    [HideInInspector] private int maxWisdomCharac = 100;
    [HideInInspector] public int wisdomBonus = 0;




    [Header("Вторичные характеристики")]
    //1 переменная - итоговове значение характеристики
    //2 переменная - бонус к значению характеристики
    //3 переменная - максимальное допустимое значение характеристики

    //Уклонение
    public int dodge = 0;
    [HideInInspector] public int dodgeBonus = 0;
    private const int maxDodge = 100;

    //Переносимый вес
    public int carryingCapacity = 0;
    [HideInInspector] public int carryingCapacityBonus = 0;
    private const int maxCarryingCapacity = 10;

    //Скорость
    public float speed = 0;
    [HideInInspector] public float speedBonus = 2f;
    private const float maxSpeed = 10f;

    //Скорость атаки
    public float attackSpeed = 0;
    [HideInInspector] public float attackSpeedBonus = 0;
    private const float maxAttackSpeed = 10;

    //Критический урон
    public float criticalDamage = 0;
    [HideInInspector] public float criticalDamageBonus = 0;
    private const float maxCriticalDamage = 200;

    //Шанс критануть
    public float criticalDamageChance = 0;
    [HideInInspector] public float criticalDamageChanceBonus = 0;
    private const float minCriticalChanceDamage = -100;
    private const float maxCriticalChanceDamage = 100;

    //Точность
    public float precision = 0;
    [HideInInspector] public float precisionBonus = 0;
    private const float maxPrecision = 100;

    //Опьянение
    public int drunkenness = 0;
    [HideInInspector] public int drunkennessBonus = 0;
    private const int maxDrunkenness = 100;



    [Header("Сопротивления к урону")]
    //Сопротивление колющему📌
    public float prickResist = 20;
    [HideInInspector] public float prickResistBonus = 20;
    private const int maxPrickResist = 100;
    private const int minPrickResist = -100;

    //Сопротивление режущему🔪
    public float slashResist = 0;
    [HideInInspector] public float slashResistBonus = 0;
    private const int maxSlashResist = 100;
    private const int minSlashResist = -100;

    //Сопротивление дробящему🔨
    public float crushResist = 0;
    [HideInInspector] public float crushResistBonus = 0;
    private const int maxCrushResist = 100;
    private const int minCrushResist = -100;

    //Сопротивление ядам🍄
    public float poisonResist = 0;
    [HideInInspector] public float poisonResistBonus = 0;
    private const int maxPoisonResist = 100;
    private const int minPoisonResist = -100;

    //Сопротивление огню🔥
    public float fireResist = 0;
    [HideInInspector] public float fireResistBonus = 0;
    private const int maxFireResist = 100;
    private const int minFireResist = -100;

    //Сопростивление морозу❄ 
    public float frostResist = 0;
    [HideInInspector] public float frostResistBonus = 0;
    private const int maxFrostResist = 100;
    private const int minFrostResist = -100;

    //Сопротивление проклятию☠
    public float curseResist = 0;
    [HideInInspector] public float curseResistBonus = 0;
    private const int maxCurseResist = 100;
    private const int minCurseResist = -100;

    //Сопротивление электричеству⛈
    public float electricalResist = 0;
    [HideInInspector] public float electricalResistBonus = 0;
    private const int maxElectricalResist = 100;
    private const int minElectricalResist = -100;

    //Сопротивление АлКоГоЛю🍺
    public float drunkennessResist = 0;
    [HideInInspector] public float drunkennessResistBonus = 0;
    private const int maxDrunkennessResist = 100;
    private const int minDrunkennessResist = -100;



    public void CheckCharac()
    {
        //Хепешки
        if (HP >= maxHP)
        {
            HP = maxHP;
        }

        //Энергия
        if (energy >= maxEnergy)
        {
            energy = maxEnergy;
        }

        //Сила
        if (strengthCharac >= maxStrengthCharac)
        {
            strengthCharac = maxStrengthCharac;
        }
        else if (strengthCharac <= 0)
        {
            strengthCharac = 0;
        }

        //Ловкость
        if (agilityCharac >= maxAgilityCharac) 
        {
            agilityCharac = maxAgilityCharac;
        }
        else if (agilityCharac <= 0)
        {
            agilityCharac = 0;
        }

        //Интеллект
        if (intelCharac >= maxIntelCharac) 
        {
            intelCharac = maxIntelCharac;
        }
        else if (intelCharac <= 0)
        {
            intelCharac = 0;
        }

        //Телосложение
        if (constitutionCharac >= maxConstitutionCharac) 
        {
            constitutionCharac = maxConstitutionCharac; 
        }
        else if (constitutionCharac <= 0)
        {
            constitutionCharac = 0;
        }

        //Мудрость
        if (wisdomCharac >= maxWisdomCharac) 
        {
            wisdomCharac = maxWisdomCharac;
        }
        else if (wisdomCharac <= 0)
        {
            wisdomCharac = 0;
        }

        //Уклонение
        if (dodge >= maxDodge) 
        {
            dodge = maxDodge;
        }
        else if (dodge <= 0)
        {
            dodge = 0;
        }

        //Переносимый вес
        if (carryingCapacity >= maxCarryingCapacity) 
        {
            carryingCapacity = maxCarryingCapacity;
        }
        else if (carryingCapacity <= 0)
        {
            carryingCapacity = 0;
        }

        //Скорость
        if (speed >= maxSpeed) 
        { 
            speed = maxSpeed; 
        }
        else if (speed <= 0)
        {
            speed = 0;
        }

        //Скорость атаки
        if (attackSpeed >= maxAttackSpeed) 
        {
            attackSpeed = maxAttackSpeed;
        }
        else if (attackSpeed <= 0)
        {
            attackSpeed = 0;
        }

        //Крит урон
        if (criticalDamage >= maxCriticalDamage)
        {
            criticalDamage = maxCriticalDamage;
        }
        else if (criticalDamage <= 0)
        {
            criticalDamage = 0;
        }

        //Шанс критануть
        if (criticalDamageChance >= maxCriticalChanceDamage)
        {
            criticalDamageChance = maxCriticalChanceDamage;
        }
        else if (criticalDamageChance <= 0)
        {
            criticalDamageChance = 0;
        }

        //Точность
        if (precision >= maxPrecision) 
        {
            precision = maxPrecision;
        }
        else if (precision <= 0)
        {
            precision = 0;
        }

        //Опьянение
        if (drunkenness >= maxDrunkenness)
        {
            drunkenness = maxDrunkenness;
        }
        else if (drunkenness <= 0)
        {
            drunkenness = 0;
        }

        //Сопротивление колющему урону
        if (prickResist >= maxPrickResist) 
        {
            prickResist = maxPrickResist;
        }
        else if (prickResist <= minPrickResist)
        {
            prickResist = minPrickResist;
        }

        //Сопротивление режущему
        if (slashResist >= maxSlashResist) 
        {
            slashResist = maxSlashResist;
        }
        else if (slashResist <= minSlashResist)
        {
            slashResist = minSlashResist;
        }

        //Сопротивление дробящему
        if (crushResist >= maxCrushResist) 
        {
            crushResist = maxCrushResist;
        }
        else if (crushResist <= minCrushResist)
        {
            crushResist = minCrushResist;
        }

        //Сопротивление ядам
        if (poisonResist >= maxPoisonResist) 
        {
            poisonResist = maxPoisonResist;
        }
        else if (poisonResist <= minPoisonResist)
        {
            poisonResist = minPoisonResist;
        }

        //Сопротивление огню
        if (fireResist >= maxFireResist)
        {
            fireResist = maxFireResist;
        }
        else if (fireResist <= minFireResist) 
        {
            fireResist = minFireResist;
        }

        //Сопротивление морозу
        if (frostResist >= maxFrostResist)
        {
            frostResist = maxFrostResist;
        }
        else if (frostResist <= minFrostResist)
        {
            frostResist = minFrostResist;
        }

        //Сопротивление проклятию
        if (curseResist >= maxCurseResist)
        {
            curseResist = maxCurseResist;
        }
        else if (curseResist <= minCurseResist)
        {
            curseResist = minCurseResist;
        }

        //Сопротивление электтричеству
        if (electricalResist >= maxElectricalResist)
        {
            electricalResist = maxElectricalResist;
        }
        else if (electricalResist <= minElectricalResist)
        {
            electricalResist = minElectricalResist;
        }

        //Сопротивление опьянению
        if (drunkennessResist >= maxDrunkennessResist)
        {
            drunkennessResist = maxDrunkennessResist;
        }
        else if (drunkennessResist <= minDrunkennessResist)
        {
            drunkenness = minDrunkennessResist;
        }

    }//Проверяет переменные на то чтобы они совпадали своему диапазону

    public void UpdateCharac()
    {
        //Первичные характеристики
        strength = strengthCharac * 1 + strengthBonus;
        agility = agilityCharac * 1 + agilityBonus;
        constitution = constitutionCharac * 1 + constitutionBonus;
        intel = intelCharac * 1 + intelBonus;
        wisdom = wisdomCharac * 1 + wisdomBonus;

        //Дамаги

        //Колющий урон
        if (prickDamageWeapon > 0)
        {
            prickDamage = strength * 5 + prickDamageBonus + prickDamageWeapon;
        }
        else if (prickDamageWeapon <= 0) 
        {
            prickDamage = 0;
        }

        //Рубящий урон
        if (slashDamageWeapon > 0)
        {
            slashDamage = strength * 5 + slashDamageBonus + slashDamageWeapon;
        }
        else if(slashDamageWeapon <= 0)
        {
            slashDamage = 0;
        }

        //Дробящий урон
        if (crushDamageWeapon > 0)
        {
            crushDamage = strength * 5 + crushDamageBonus + crushDamageWeapon;
        }
        else if (crushDamageWeapon <= 0)
        {
            crushDamage = 0;
        }

        //Ядовитый урон
        if (poisonDamageWeapon > 0)
        {
            poisonDamage = wisdom * 3 + poisonDamageBonus + poisonDamageWeapon;
        }
        else if (poisonDamageWeapon <= 0)
        {
            poisonDamage = 0;
        }

        //Огненный урон
        if (fireDamageWeapon > 0) 
        {
            fireDamage = wisdom * 3 + fireDamageBonus + fireDamageWeapon;
        }
        else if (fireDamageWeapon <= 0)
        {
            fireDamage = 0;
        }

        //Морозный урон
        if (frostDamageWeapon > 0) 
        {
            frostDamage = wisdom * 3 + frostDamageBonus + fireDamageWeapon;
        }
        else if (frostDamageWeapon <= 0)
        {
            frostDamage = 0;
        }

        //Проклятый урон
        if (curseDamageWeapon > 0)
        {
            curseDamage = wisdom * 3 + curseDamageBonus + curseDamageWeapon;
        }
        else if (curseDamageWeapon <= 0)
        {
            curseDamage = 0;
        }

        //Эллекстрический урон
        if (electricalDamageWeapon > 0)
        {
            electricalDamage = wisdom * 3 + electricalDamageBonus + electricalDamageWeapon;
        }
        else if (electricalDamageWeapon <= 0)
        {
            electricalDamage = 0;
        }

        //Алкогольный урон
        if (drunkennessDamageWeapon > 0)
        {
            drunkennessDamage = wisdom * 3 + drunkennessBonus + drunkennessDamageWeapon;
        }
        else if (drunkennessDamageWeapon <= 0)
        {
            drunkennessDamage = 0;
        }



        //Сопротивляшки
        prickResist = (constitution * 2) + (agility * 2) + prickResistBonus;
        slashResist = (constitution * 2) + (strength * 1) + (agility * 1) + slashResistBonus;
        crushResist = (constitution * 2) + (agility * 2) + crushResistBonus;

        poisonResist = (wisdom * 2) + poisonResistBonus;
        fireResist = (wisdom * 2) + fireResistBonus;
        frostResist = (wisdom * 2) + frostResistBonus;
        curseResist = (wisdom * 2) + curseResistBonus;
        electricalResist = (wisdom * 2) + electricalResistBonus;



        //Вторичные характеристики
        carryingCapacity = strength * 5 + carryingCapacityBonus;
        dodge = agility * 2 + dodgeBonus;
        speed = agility * 0.05f + speedBonus;
        attackSpeed = agility * 0.05f + attackSpeedBonus;
        criticalDamage = agility * 1 + criticalDamageBonus;
        precision = agility * 1 + precisionBonus;
    }//Обновляет характеристики исходя из других переменных и бонусов к ним


    #endregion

    #region Таланты/Перки

    //1 переменная отвечает за активность статуса
    //2 переменная отвечает за свободность статуса
    //Чтобы при запуске метода повторно не сработал кусок кода свзанный с этим эффектом и нужна 2 переменные
    //Типо буфер

    private bool wound = false;
    private bool checkWound = true;
    

    public void RandomWound()
    {
        int random = Random.Range(10, 50);        
    }
    public void CheckTalents()
    {
        if(wound && checkWound)
        {
            maxHP -= 10;

            checkWound = false;
        }
        else if(!wound && !checkWound)
        {
            maxHP += 10;

            checkWound = true;
        }       
    }






    #endregion  

  

    public void Updater()
    {
        CheckCharac();
        CheckTalents();
        UpdateCharac();

        rb.WakeUp();
    }

}