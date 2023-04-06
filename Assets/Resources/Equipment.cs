using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : StatusData
{
    [Header("Цена")]
    //Цена      ///Неожиданно? Да я сам в ахуе
    [SerializeField, Range(0, 1000f)] public float cost;
    public float Cost { get => cost; }

    [Header("Вес")]
    //Вес
    [SerializeField, Range(0, 100f)] public float weight;
    public float Weight { get => weight; }





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
