using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class EquipmentData : StatusData
{
    [Header("Цена")]
    //Цена      ///Неожиданно? Да я сам в ахуе
    [SerializeField, Range(0, 1000)] public int cost;
    public int Cost { get => cost; }

    [Header("Вес")]
    //Вес
    [SerializeField, Range(0, 100)] public int weight;
    public int Weight { get => weight; }



    [Header("Уровень предмета")]
    //Прочность
    [SerializeField, Range(0, 100)] public int itemLevel;
    public int ItemLevel { get => itemLevel; }



    [Header("Требования к характеристикам")]
    //Сила
    [SerializeField, Range(0, 100)] public int requestStrength = 0;
    public int RequestStrength { get => requestStrength; }

    //Ловкость
    [SerializeField, Range(0, 100)] public int requestAgility = 0;
    public int RequestAgility { get => requestAgility; }

    //Интеллект
    [SerializeField, Range(0, 100)] public int requesIntel = 0;
    public int RequestIntel { get => requesIntel; }

    //Телосложение
    [SerializeField, Range(0, 100)] public int requesConstitution = 0;
    public int RequestConstitution { get => requesConstitution; }

    //Мудрость
    [SerializeField, Range(0, 100)] public int requestwisdom = 0;
    public int RequestWisdom { get => requestwisdom; }
}
