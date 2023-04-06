using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Weapon", order = 51)]
public class Weapon : Equipment
{
    [Header("Тип оружия")]
    //Указывает на то какое это тип оружия(одноручное, двуручное, древковое и тд)
    [SerializeField] public string weaponType;
    public string WeaponType { get => weaponType; }


    [Header("Уроны")]
    //Урон колющем📌
    [SerializeField, Range(0, 100f)] public float prickDamage = 0;
    public float PrickDamage { get => prickDamage; }

    //Урон режущем🔪
    [SerializeField, Range(0, 100f)] public float slashDamage = 0;
    public float SlashDamage { get => slashDamage; }

    //Урон дробящем🔨
    [SerializeField, Range(0, 100f)] public float crushDamage = 0;
    public float CrushDamage { get => crushDamage; }

    //Урон ядом🍄
    [SerializeField, Range(0, 100f)] public float poisonDamage = 0;
    public float PoisonDamage { get => poisonDamage; }

    //Урон огнем🔥
    [SerializeField, Range(0, 100f)] public float fireDamage = 0;
    public float FireDamage { get => fireDamage; }

    //Урон морозом❄ 
    [SerializeField, Range(0, 100f)] public float frostDamage = 0;
    public float FrostDamage { get => frostDamage; }

    //Урон проклятием☠
    [SerializeField, Range(0, 100f)] public float curseDamage = 0;
    public float CurseDamage { get => curseDamage; }

    //Урон электричеством⛈
    [SerializeField, Range(0, 100f)] public float electricalDamage = 0;
    public float ElectricalDamage { get => electricalDamage; }

    //Урон АлКоГоЛеМ🍺
    [SerializeField, Range(0, 100f)] public float drunkennessDamage = 0;
    public float DrunkennessDamage { get => drunkennessDamage; }
}
