using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHolder : MonoBehaviour
{
    [SerializeField] private List<GameObject> cards = new List<GameObject>();


    private void OnEnable()
    {
        LevelManager.LevelEnded += ShowCard;
    }
    private void OnDisable()
    {
        LevelManager.LevelEnded -= ShowCard;
    }


    private void ShowCard()
    {
        if (cards.Count > 0)
        {
            foreach (var card in cards)
            {
                card.gameObject.SetActive(true);
            }
        }
    }
}
