using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class CardMaker : MonoBehaviour
{
    [Header("Карты")]
    //Позитивная и негативная карта
    public CardData cardPositive;
    public CardData cardNegative;

    //Массив карт
    private CardData[] cards;

    public GameObject levelModifier;

    [Header("Позитивная карта")]
    //Имя карты
    [SerializeField] private TMP_Text cardNamePositive;
    [SerializeField] private TMP_Text cardDescriptionPositive;

    [Header("Негативная карта")]
    //Описаник карты
    [SerializeField] private TMP_Text cardNameNegative;
    [SerializeField] private TMP_Text cardDescriptionNegative;




    private void OnEnable()
    {
        LevelManager.LevelEnded += MakeCard;
    }
    private void OnDisable()
    {
        LevelManager.LevelEnded -= MakeCard;
    }



    private void Start()
    {
        cards = Resources.LoadAll<CardData>("Cards");
    }

    public void MakeCard()
    {
        while (true)
        {
            cardPositive = cards[UnityEngine.Random.Range(0, cards.Length)];
            cardNegative = cards[UnityEngine.Random.Range(0, cards.Length)];

            if(cardPositive.type == CardData.Type.positive && cardNegative.type == CardData.Type.negative)
            {
                break;
            }
        }

        
        //cardNamePositive.text = cardPositive.name;
        //cardDescriptionPositive.text = cardPositive.CardDescription;

        //cardNameNegative.text = cardNegative.name;
        //cardDescriptionNegative.text = cardNegative.CardDescription;
    }

    public void OnClick()
    {
        //Враги
        if (cardPositive.modifier is StatusData && cardPositive.accessory == CardData.Accessory.enemy)
        {
            levelModifier.GetComponent<LevelModifier>().enemyStatuses.Add(cardPositive.modifier as StatusData);
        }
        if (cardNegative.modifier is StatusData && cardPositive.accessory == CardData.Accessory.enemy)
        {
            levelModifier.GetComponent<LevelModifier>().enemyStatuses.Add(cardNegative.modifier as StatusData);
        }

        //Игрок
        if (cardPositive.modifier is StatusData && cardPositive.accessory == CardData.Accessory.player)
        {
            levelModifier.GetComponent<LevelModifier>().playerStatuses.Add(cardPositive.modifier as StatusData);
        }
        if (cardNegative.modifier is StatusData && cardPositive.accessory == CardData.Accessory.player)
        {
            levelModifier.GetComponent<LevelModifier>().playerStatuses.Add(cardNegative.modifier as StatusData);
        }
    }
}
