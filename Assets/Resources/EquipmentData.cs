using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class EquipmentData : StatusData
{
    [Header("Цена")]
    //Цена      ///Неожиданно? Да я сам в ахуе
    [SerializeField, Range(0, 1000f)] public float cost;
    public float Cost { get => cost; }

    [Header("Вес")]
    //Вес
    [SerializeField, Range(0, 100f)] public float weight;
    public float Weight { get => weight; }



    [Header("Уровень предмета")]
    //Прочность
    [SerializeField, Range(0, 100)] public int itemLevel;
    public int ItemLevel { get => itemLevel; }



    [Header("Требования к характеристикам")]
    //Сила
    [SerializeField, Range(0, 100f)] public float requestStrength = 0;
    public float RequestStrength { get => requestStrength; }

    //Ловкость
    [SerializeField, Range(0, 100f)] public float requestAgility = 0;
    public float RequestAgility { get => requestAgility; }

    //Интеллект
    [SerializeField, Range(0, 100f)] public float requesIntel = 0;
    public float RequestIntel { get => requesIntel; }

    //Телосложение
    [SerializeField, Range(0, 100f)] public float requesConstitution = 0;
    public float RequestConstitution { get => requesConstitution; }

    //Мудрость
    [SerializeField, Range(0, 100f)] public float requestwisdom = 0;
    public float RequestWisdom { get => requestwisdom; }
}
