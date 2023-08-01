using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon", order = 51)]
public class WeaponData : EquipmentData
{
    [Header("Тип оружия")]
    //Указывает на то какое это тип оружия(одноручное, двуручное, древковое и тд)
    [SerializeField] public string weaponType;
    public string WeaponType { get => weaponType; }



    [Header("Уроны")]
    //Урон колющем📌
    [SerializeField, Range(0, 100f)] public float prickDamageWeapon = 0;
    public float PrickDamageWeapon { get => prickDamageWeapon; }

    //Урон режущем🔪
    [SerializeField, Range(0, 100f)] public float slashDamageWeapon = 0;
    public float SlashDamageWeapon { get => slashDamageWeapon; }

    //Урон дробящем🔨
    [SerializeField, Range(0, 100f)] public float crushDamageWeapon = 0;
    public float CrushDamageWeapon { get => crushDamageWeapon; }

    //Урон ядом🍄
    [SerializeField, Range(0, 100f)] public float poisonDamageWeapon = 0;
    public float PoisonDamageWeapon { get => poisonDamageWeapon; }

    //Урон огнем🔥
    [SerializeField, Range(0, 100f)] public float fireDamageWeapon = 0;
    public float FireDamageWeapon { get => fireDamageWeapon; }

    //Урон морозом❄ 
    [SerializeField, Range(0, 100f)] public float frostDamageWeapon = 0;
    public float FrostDamageWeapon { get => frostDamageWeapon; }

    //Урон проклятием☠
    [SerializeField, Range(0, 100f)] public float curseDamageWeapon = 0;
    public float CurseDamageWeapon { get => curseDamageWeapon; }

    //Урон электричеством⛈
    [SerializeField, Range(0, 100f)] public float electricalDamageWeapon = 0;
    public float ElectricalDamageWeapon { get => electricalDamageWeapon; }

    //Урон АлКоГоЛеМ🍺
    [SerializeField, Range(0, 100f)] public float drunkennessDamageWeapon = 0;
    public float DrunkennessDamageWeapon { get => drunkennessDamageWeapon; }



    [Header("Модификатор урона")]
    //Модификатор урона
    //Он показывает разброс урона выраженный в процентах
    //Например: дамаг = 100, модификатор = 5%, значит вилка урона будет 95-105
    [SerializeField, Range(0, 100f)] public float damageMod = 0;
    public float DamageMod { get => damageMod; }
}
