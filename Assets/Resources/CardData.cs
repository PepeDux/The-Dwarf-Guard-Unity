using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card", order = 51)]
public class CardData : ScriptableObject
{
    [Header("Описание")]
    //Описание карты
    [SerializeField] public string cardDescription;
    public string CardDescription { get => cardDescription; }



    [Header("Модификатор")]
    //Модификатор
    [SerializeField] public ScriptableObject modifier;
    public ScriptableObject Modifier { get => modifier; }


    [Header("Тип карты")]
    //Тип карты
    public Type type;
    public enum Type { positive, negative };

    [Header("Предзначен для")]
    //Тип карты
    public Accessory accessory;
    public enum Accessory { player, enemy, global };
}
