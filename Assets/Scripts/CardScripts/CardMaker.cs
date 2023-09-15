using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class CardMaker : MonoBehaviour
{
    public static Action endSelectCard;

    [Header("Карты")]
    //Позитивная и негативная карта
    public CardData cardPositive;
    public CardData cardNegative;

    //Массив карт
    private CardData[] cards;

    public GameObject levelModifier;

    [SerializeField] private GameObject spawner;

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
        //CardHolder.cardsShowed += MakeCard;
        endSelectCard += EndSelectCard;
    }
    private void OnDisable()
    {
        //CardHolder.cardsShowed -= MakeCard;
        endSelectCard -= EndSelectCard;
    }



    private void Start()
    {
        cards = Resources.LoadAll<CardData>("Cards");
        MakeCard();
    }


    private void MakeCard()
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

        try
        {
            cardNamePositive.text = cardPositive.name;
            cardDescriptionPositive.text = cardPositive.CardDescription;

            cardNameNegative.text = cardNegative.name;
            cardDescriptionNegative.text = cardNegative.CardDescription;
        }     
        catch
        {
          
        }
    }

    private void OnClick()
    {
        //Враги
        if (cardPositive.modifier is StatusData && cardPositive.accessory == CardData.Accessory.enemy)
        {
            levelModifier.GetComponent<LevelModifier>().enemyStatuses.Add(cardPositive.modifier as StatusData);
        }
        if (cardNegative.modifier is StatusData && cardNegative.accessory == CardData.Accessory.enemy)
        {
            levelModifier.GetComponent<LevelModifier>().enemyStatuses.Add(cardNegative.modifier as StatusData);
        }

        //Игрок
        if (cardPositive.modifier is StatusData && cardPositive.accessory == CardData.Accessory.player)
        {
            levelModifier.GetComponent<LevelModifier>().playerStatuses.Add(cardPositive.modifier as StatusData);
        }
        if (cardNegative.modifier is StatusData && cardNegative.accessory == CardData.Accessory.player)
        {
            levelModifier.GetComponent<LevelModifier>().playerStatuses.Add(cardNegative.modifier as StatusData);
        }

        //Спавн
        if (cardPositive.modifier is SpawnData && cardPositive.accessory == CardData.Accessory.spawn)
        {
            spawner.GetComponent<SpawnCalculation>().AddSpawn(cardPositive.modifier as SpawnData);
        }
        if (cardNegative.modifier is SpawnData && cardNegative.accessory == CardData.Accessory.spawn)
        {
            spawner.GetComponent<SpawnCalculation>().AddSpawn(cardNegative.modifier as SpawnData);
        }



        endSelectCard?.Invoke();   
    }

    private void EndSelectCard()
    {
        MakeCard();
        this.gameObject.SetActive(false);
    }
}
