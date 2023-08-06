using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInfo : MonoBehaviour
{
    //Колличество юнитов которые нужно заспавнить при старте уровня
    public static int melee = 1; //Ближники 
    public static int range = 1; //Дальники
    public static int captain = 1; //Капитаны
    public static int wizard = 0; //Колдуны

    //Колличество статичных объектов которые нужно заспавнить при старте уровня
    public static int wall = 5; //Стены
    public static int trap = 2; //Ловушки
    public static int pit = 30; //Ямы

    //Колличество поднимаемых объектов которые нужно заспавнить при старте уровня
    public static int food = 3; //Еда
    public static int money = 0; //Монеты
    public static int crystal = 0; //Кристаллы
}
