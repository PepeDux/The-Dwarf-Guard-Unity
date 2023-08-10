using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using MinAttribute = UnityEngine.MinAttribute;

[CreateAssetMenu(fileName = "New Status", menuName = "Status", order = 51)]
public class StatusData : ScriptableObject
{
    [Header("Плюшки")]
    //Написание типа эффекта
    [SerializeField] public string type;
    public string Type { get => type; }

    //Префаб еффекта(необязательно)
    [SerializeField] public GameObject prefab;
    public GameObject Prefab { get => prefab; }





    [Header("Основнык характеристики")]
    //Сила
    [SerializeField, Range(-100, 100)] public int strength = 0;
    public int Strength { get => strength; }

    //Ловкость
    [SerializeField, Range(-100, 100)] public int agility = 0;
    public int Agility { get => agility; }

    //Интеллект
    [SerializeField, Range(-100, 100)] public int intel = 0;
    public int Intel { get => intel; }

    //Телосложение
    [SerializeField, Range(-100, 100)] public int constitution = 0;
    public int Constitution { get => constitution; }

    //Мудрость
    [SerializeField, Range(-100, 100)] public int wisdom = 0;
    public int Wisdom { get => wisdom; }





    [Header("Вторичные характеристики")]
    //Уклонение
    [SerializeField, Range(-100, 100)] public int dodge = 0;
    public int Dodge { get => dodge; }

    //Переносимый вес
    [SerializeField, Range(-100, 100)] public int carryingCapacity = 0;
    public int CarryingCapacity { get => carryingCapacity; }

    //Скорость
    [SerializeField, Range(-100, 100)] public int speed = 0;
    public int Speed { get => speed; }

    //Скорость атаки
    [SerializeField, Range(-100, 100)] public int attackSpeed = 0;
    public int AttackSpeed { get => attackSpeed; }

    //Критический урон
    [SerializeField, Range(-100, 100)] public int criticalDamage = 0;
    public int CriticalDamage { get => criticalDamage; }

    //Шанс критануть
    [SerializeField, Range(-100, 100)] public int criticalDamageChance = 0;
    public int CriticalDamageChance { get => criticalDamageChance; }

    //Точность
    [SerializeField, Range(-100, 100)] public int precision = 0;
    public int Precision { get => precision; }

    //Опьянение
    [SerializeField, Range(-100, 100)] public int drunkenness = 0;
    public int Drunkenness { get => drunkenness; }





    [Header("Сопротивления к урону")]
    //Сопротивление колющему📌
    [SerializeField, Range(-100, 100)] public int prickResist = 0;
    public int PrickResist { get => prickResist; }

    //Сопротивление режущему🔪
    [SerializeField, Range(-100, 100)] public int slashResist = 0;
    public int SlashResist { get => slashResist; }

    //Сопротивление дробящему🔨
    [SerializeField, Range(-100, 100)] public int crushResist = 0;
    public int CrushResist { get => crushResist; }

    //Сопротивление ядам🍄
    [SerializeField, Range(-100, 100)] public int poisonResist = 0;
    public int PoisonResist { get => poisonResist; }

    //Сопротивление огню🔥
    [SerializeField, Range(-100, 100)] public int fireResist = 0;
    public int FireResist { get => fireResist; }

    //Сопростивление морозу❄ 
    [SerializeField, Range(-100, 100)] public int frostResist = 0;
    public int FrostResist { get => frostResist; }

    //Сопротивление проклятию☠
    [SerializeField, Range(-100, 100)] public int curseResist = 0;
    public int CurseResist { get => curseResist; }

    //Сопротивление электричеству⛈
    [SerializeField, Range(-100, 100)] public int electricalResist = 0;
    public int ElectricalResist { get => electricalResist; }

    //Сопротивление АлКоГоЛю🍺
    [SerializeField, Range(-100, 100)] public int drunkennessResist = 0;
    public int DrunkennessResist { get => drunkennessResist; }



    [Header("Сопротивления к урону")]
    //Сопротивление АлКоГоЛю🍺
    [SerializeField, Range(-100, 100)] public int hammerWay = 0;
    public int HammerWay { get => hammerWay; }

    //Сопротивление АлКоГоЛю🍺
    [SerializeField, Range(-100, 100)] public int gearWay = 0;
    public int GearWay { get => gearWay; }

    //Сопротивление АлКоГоЛю🍺
    [SerializeField, Range(-100, 100)] public int anvilWay = 0;
    public int AnvilWay { get => anvilWay; }

    //Сопротивление АлКоГоЛю🍺
    [SerializeField, Range(-100, 100)] public int beerWay = 0;
    public int BeerWay { get => beerWay; }

    //Сопротивление АлКоГоЛю🍺
    [SerializeField, Range(-100, 100)] public int runeWay = 0;
    public int RuneWay { get => runeWay; }
}
