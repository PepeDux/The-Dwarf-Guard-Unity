using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevelInfo : MonoBehaviour
{
    [Header("Юниты на уровне")]
    //Колличество юнитов которые нужно заспавнить при старте уровня
    public int melee = 1; //Ближники 
    public int range = 1; //Дальники
    public int captain = 1; //Капитаны
    public int wizard = 0; //Колдуны

    [Header("Статичные объекты")]
    //Колличество статичных объектов которые нужно заспавнить при старте уровня
    public int wall = 5; //Стены
    public int pit = 3; //Ямы

    [Header("Функциональные объекты")]
    public int trap = 2; //Ловушки
    public int food = 3; //Еда
    public int money = 0; //Монеты
    public int crystal = 0; //Кристаллы
}
