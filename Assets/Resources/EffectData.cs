using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using MinAttribute = UnityEngine.MinAttribute;

[CreateAssetMenu(fileName = "New EffectData", menuName = "Effect Data", order = 51)]
public class EffectData : ScriptableObject
{
    [Header("Сопротивления к урону")]
    //Написание типа эффекта
    [SerializeField] public string type;
    public string Type { get => type; }

    //Префаб еффекта(необязательно)
    [SerializeField] public GameObject prefab;
    public GameObject Prefab { get => prefab; }



    [Header("Сопротивления к урону")]
    //Сопротивление колющему📌
    [SerializeField, Range(-100f, 100f)] private float prickResist = 0;
    public float PrickResist { get => prickResist; }

    //Сопротивление режущему🔪
    [SerializeField, Range(-100f, 100f)] private float slashResist = 0;
    public float SlashResist { get => slashResist; }

    //Сопротивление дробящему🔨
    [SerializeField, Range(-100f, 100f)] private float crushResist = 0;
    public float CrushResist { get => crushResist; }

    //Сопротивление ядам🍄
    [SerializeField, Range(-100f, 100f)] private float poisonResist = 0;
    public float PoisonResist { get => poisonResist; }

    //Сопротивление огню🔥
    [SerializeField, Range(-100f, 100f)] private float fireResist = 0;
    public float FireResist { get => fireResist; }

    //Сопростивление морозу❄ 
    [SerializeField, Range(-100f, 100f)] private float frostResist = 0;
    public float FrostResist { get => frostResist; }

    //Сопротивление проклятию☠
    [SerializeField, Range(-100f, 100f)] private float curseResist = 0;
    public float CurseResist { get => curseResist; }

    //Сопротивление электричеству⛈
    [SerializeField, Range(-100f, 100f)] private float electricalResist = 0;
    public float ElectricalResist { get => electricalResist; }

    //Сопротивление АлКоГоЛю🍺
    [SerializeField, Range(-100f, 100f)] private float drunkennessResist = 0;
    public float DrunkennessResist { get => drunkennessResist; }





    [Header("Основнык характеристики")]
    //Сила
    [SerializeField, Range(-100f, 100f)] public int strength = 0;
    public float Strength { get => strength; }

    //Ловкость
    [SerializeField, Range(-100f, 100f)] public int agility = 0;
    public float Agility { get => agility; }

    //Интеллект
    [SerializeField, Range(-100f, 100f)] public int intel = 0;
    public float Intel { get => intel; }

    //Телосложение
    [SerializeField, Range(-100f, 100f)] public int constitution = 0;
    public float Constitution { get => constitution; }

    //Мудрость
    [SerializeField, Range(-100f, 100f)] public int wisdom = 0;
    public float Wisdom { get => wisdom; }





    [Header("Вторичные характеристики")]
    //Уклонение
    [SerializeField, Range(-100f, 100f)] public int dodge = 0;
    public float Dodge { get => dodge; }

    //Переносимый вес
    [SerializeField, Range(-100f, 100f)] public int carryingCapacity = 0;
    public float CarryingCapacity { get => carryingCapacity; }

    //Скорость
    [SerializeField, Range(-100f, 100f)] public float speed = 0;
    public float Speed { get => speed; }

    //Скорость атаки
    [SerializeField, Range(-100f, 100f)] public float attackSpeed = 0;
    public float AttackSpeed { get => attackSpeed; }

    //Критический урон
    [SerializeField, Range(-100f, 100f)] public float criticalDamage = 0;
    public float CriticalDamage { get => criticalDamage; }

    //Шанс критануть
    [SerializeField, Range(-100f, 100f)] public float criticalDamageChance = 0;
    public float CriticalDamageChance { get => criticalDamageChance; }

    //Точность
    [SerializeField, Range(-100f, 100f)] public float precision = 0;
    public float Precision { get => precision; }

    //Опьянение
    [SerializeField, Range(-100f, 100f)] public int drunkenness = 0;
    public float Drunkenness { get => drunkenness; }
}
