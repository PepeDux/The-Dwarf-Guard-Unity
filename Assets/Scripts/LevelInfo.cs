using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInfo : MonoBehaviour
{
    [Header("Юниты на уровне")]
    //Колличество юнитов которые нужно заспавнить при старте уровня
    public int melee; //Ближники 
    public int range; //Дальники
    public int captain; //Капитаны
    public int wizard; //Колдуны

    [Header("Статичные объекты")]
    //Колличество статичных объектов которые нужно заспавнить при старте уровня
    public int wall; //Стены
    public int pit; //Ямы

    [Header("Функциональные объекты")]
    public int trap; //Ловушки
    public int food; //Еда
    public int money; //Монеты
    public int crystal; //Кристаллы
}
