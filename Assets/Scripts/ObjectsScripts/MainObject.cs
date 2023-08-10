﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Security.Cryptography;
using UnityEngine.Rendering.PostProcessing;
using System;
using Random = UnityEngine.Random;
using UnityEngine.Tilemaps;
using JetBrains.Annotations;

public class MainObject : BaseObject
{
    [Header("Очки перемещения, очки действия, очки пива")]
    //Очки перемещения
    public int movePoint;
    public int maxMovePoint;

    //Очки действий
    public int actionPoints;
    public int maxActionPoint;

    //Очки пива
    public int beerPoint;
    public int maxBeerPoint;



    [Header("Цена действий")]
    public int moveCost;
    public int meleeAttackCost;
    public int rangeAttackCost;



    [Header("Тип передвиженя")]
    public bool lineMove = false;
    public bool diagonalMove = false;



    [Header("Тип атаки")]
    public bool lineAttack = false;
    public bool diagonalAttack = false;



    [Header("Тип атаки")]
    public bool melee = false; //Ближняя атака
    public bool range = false; //Дальняя атака



    [Header("Дальность атаки")]
    public int rangeAttackDistance; //Дальность дальней атаки
    public const int meleeAttackDistance = 1;


    [Header("Плюшки")]
    public Animator anim;

    public static int random;

    #region Characteristic

    private int freeCharacteristicLevel = 0;
    private int CharacteristicLevel = 0;
    private int maxCharacteristicLevel = 10;

    [Header("Здоровье")]
    //Здоровье
    public float HP;
    public float maxHP = 10;

    [Header("Броня")]
    //Броня
    public int armor;
    public int maxArmor = 0;

    [Header("Монетки")]
    //Монетки
    public int money = 0;



    [Header("Уроны")]
    //Урон наносимый объектом
    //1 переменная - итоговый урон
    //2 переменная - урон от оружия
    //3 переменная - бонусный урон, отрицательный или положительный

    //Физический урон
    public int physicalDamage = 0;
    [HideInInspector] public int physicalDamageBonus = 0;

    //Ядовитый урон
    public int poisonDamage = 0;
    [HideInInspector] public int poisonDamageBonus = 0;

    //Огненный урон
    public int fireDamage = 0;
    [HideInInspector] public int fireDamageBonus = 0;

    //Морозный урон
    public int frostDamage = 0;
    [HideInInspector] public int frostDamageBonus = 0;

    //Алкогольный урон
    public int drunkennessDamage = 0;
    [HideInInspector] public int drunkennessDamageBonus = 0;



    [Header("Уровень и опыт")]
    //Опыт
    public int XP = 0;
    [HideInInspector] public int maxXP = 100;

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
    [HideInInspector] private int strengthCharac = 7;
    [HideInInspector] private const int maxStrengthCharac = 100;
    [HideInInspector] public int strengthBonus = 0;

    //Ловкость
    public int dexterity = 0;
    [HideInInspector] private int dexterityCharac = 1;
    [HideInInspector] private const int maxDexterityCharac = 100;
    [HideInInspector] public int dexterityBonus = 0;

    //Интеллект
    public int inteligence = 0;
    [HideInInspector] private int inteligenceCharac = 1;
    [HideInInspector] private const int maxInteligenceCharac = 100;
    [HideInInspector] public int inteligenceBonus = 0;

    //Телосложение
    public int constitution = 0;
    [HideInInspector] private int constitutionCharac = 1;
    [HideInInspector] private const int maxConstitutionCharac = 100;
    [HideInInspector] public int constitutionBonus = 0;

    //Мудрость
    public int wisdom = 0;
    [HideInInspector] private int wisdomCharac = 1;
    [HideInInspector] private const int maxWisdomCharac = 100;
    [HideInInspector] public int wisdomBonus = 0;




    [Header("Вторичные характеристики")]
    //1 переменная - итоговове значение характеристики
    //2 переменная - бонус к значению характеристики
    //3 переменная - максимальное допустимое значение характеристики

    //Уклонение
    public int dodge = 0;
    [HideInInspector] public int dodgeBonus = 0;
    private const int maxDodge = 100;

    //Критический урон
    public int criticalDamage = 0;
    [HideInInspector] public int criticalDamageBonus = 0;
    private const int maxCriticalDamage = 200;

    //Шанс критануть
    public int criticalDamageChance = 0;
    [HideInInspector] public int criticalDamageChanceBonus = 0;
    private const int minCriticalChanceDamage = -100;
    private const int maxCriticalChanceDamage = 100;

    //Точность
    public int precision = 0;
    [HideInInspector] public int precisionBonus = 0;
    private const int maxPrecision = 100;

    //Опьянение
    public int drunkenness = 0;
    [HideInInspector] public int drunkennessBonus = 0;
    private const int maxDrunkenness = 100;



    [Header("Сопротивления к урону")]
    //Сопротивление физическому🔪
    public int physicalResist = 0;
    [HideInInspector] public int physicalResistBonus = 20;
    private const int maxPhysicalResist = 100;
    private const int minPhysicalResist = -100;

    //Сопротивление ядам🍄
    public int poisonResist = 0;
    [HideInInspector] public int poisonResistBonus = 0;
    private const int maxPoisonResist = 100;
    private const int minPoisonResist = -100;

    //Сопротивление огню🔥
    public int fireResist = 0;
    [HideInInspector] public int fireResistBonus = 0;
    private const int maxFireResist = 100;
    private const int minFireResist = -100;

    //Сопростивление морозу❄ 
    public int frostResist = 0;
    [HideInInspector] public int frostResistBonus = 0;
    private const int maxFrostResist = 100;
    private const int minFrostResist = -100;

    //Сопротивление АлКоГоЛю🍺
    public int drunkennessResist = 0;
    [HideInInspector] public int drunkennessResistBonus = 0;
    private const int maxDrunkennessResist = 100;
    private const int minDrunkennessResist = -100;



    [Header("Пути")]
    //Путь молота
    public int hammerWay = 0;
    [HideInInspector] private int hammerWayCharac = 0;
    [HideInInspector] private const int maxHammerWayCharac = 20;
    [HideInInspector] public int hammerWayBonus = 0;

    //Путь шестеренки
    public int gearWay = 0;
    [HideInInspector] private int gearWayCharac = 0;
    [HideInInspector] private const int maxGearWayCharac = 20;
    [HideInInspector] public int gearWayBonus = 0;

    //Путь наковальни
    public int anvilWay = 0;
    [HideInInspector] private int anvilWayCharac = 0;
    [HideInInspector] private const int maxAnvilWayCharac = 20;
    [HideInInspector] public int anvilWayBonus = 0;

    //Путь пива
    public int beerWay = 0;
    [HideInInspector] private int beerWayCharac = 0;
    [HideInInspector] private const int maxBeerWayCharac = 20;
    [HideInInspector] public int beerWayBonus = 0;

    //Путь рун
    public int runeWay = 0;
    [HideInInspector] private int runeWayCharac = 0;
    [HideInInspector] private const int maxRuneWayCharac = 20;
    [HideInInspector] public int runeWayBonus = 0;

    public void CheckCharac()
    {
        //Хепешки
        if (HP >= maxHP)
        {
            HP = maxHP;
        }

        if (armor >= maxArmor)
        {
            armor = maxArmor;
        }
        else if (armor < 0)
        {
            armor = 0;
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
        if (dexterityCharac >= maxDexterityCharac)
        {
            dexterityCharac = maxDexterityCharac;
        }
        else if (dexterityCharac <= 0)
        {
            dexterityCharac = 0;
        }

        //Интеллект
        if (inteligenceCharac >= maxInteligenceCharac)
        {
            inteligenceCharac = maxInteligenceCharac;
        }
        else if (inteligenceCharac <= 0)
        {
            inteligenceCharac = 0;
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

        //Сопротивление Физическому урону
        if (physicalResist >= maxPhysicalResist)
        {
            physicalResist = maxPhysicalResist;
        }
        else if (physicalResist <= minPhysicalResist)
        {
            physicalResist = minPhysicalResist;
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
        dexterity = dexterityCharac * 1 + dexterityBonus;
        constitution = constitutionCharac * 1 + constitutionBonus;
        inteligence = inteligenceCharac * 1 + inteligenceBonus;
        wisdom = wisdomCharac * 1 + wisdomBonus;

        ///Дамаги
        //Физический урон
        physicalDamage = strength * 5 + physicalDamageBonus;

        //Ядовитый урон
        poisonDamage = wisdom * 3 + poisonDamageBonus;

        //Огненный урон
        fireDamage = wisdom * 3 + fireDamageBonus;

        //Морозный урон
        frostDamage = wisdom * 3 + frostDamageBonus;

        //Алкогольный урон
        drunkennessDamage = wisdom * 3 + drunkennessBonus;




        //Сопротивляшки
        physicalResist = (constitution * 2) + (dexterity * 2) + physicalResistBonus;

        poisonResist = (wisdom * 2) + poisonResistBonus;
        fireResist = (wisdom * 2) + fireResistBonus;
        frostResist = (wisdom * 2) + frostResistBonus;



        //Вторичные характеристики
        dodge = dexterity * 2 + dodgeBonus;
        criticalDamage = dexterity * 1 + criticalDamageBonus;
        precision = dexterity * 1 + precisionBonus;



        //Пути
        hammerWay = hammerWayCharac * 1 + hammerWayBonus;
        gearWay = gearWayCharac * 1 + gearWayBonus;
        anvilWay = anvilWay * 1 + anvilWayBonus;
        beerWay = beerWayCharac * 1 + beerWayCharac;
        runeWay = runeWayCharac * 1 + runeWayBonus;
    }//Обновляет характеристики исходя из других переменных и бонусов к ним


    #endregion


    public override void Updater()
    {
        UpdateCharac();
        CheckCharac();
        UpdateCoordinate();
    }

    public void Starter()
    {
        FindTileMap();

        movePoint = maxMovePoint;
        actionPoints = maxActionPoint;
        beerPoint = maxBeerPoint;

        HP = maxHP;
        armor = maxArmor;

        anim = GetComponent<Animator>();
    }
}