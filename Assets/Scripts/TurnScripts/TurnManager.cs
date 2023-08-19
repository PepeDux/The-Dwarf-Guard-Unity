using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class TurnManager : MonoBehaviour
{
    public static int turnCount = 1; //Счеткич ходов

    public GameObject player;
    public GameObject tileManager;



    private void OnEnable()
    {
        //Подписываемся на событие конца хода игрока 
        PlayerTurnManager.playerTurnFinished += EndPlayerTurn;
    }

    private void OnDisable()
    {
        //Отписываемся на событие конца хода игрока 
        PlayerTurnManager.playerTurnFinished -= EndPlayerTurn;
    }



    public void UpdatePoints()
    {
        foreach (var obj in TileManager.enemyList)
        {
            obj.GetComponent<Enemy>().movePoint = obj.GetComponent<Enemy>().maxMovePoint;
            obj.GetComponent<Enemy>().actionPoints = obj.GetComponent<Enemy>().maxActionPoint;
            obj.GetComponent<Enemy>().beerPoint = obj.GetComponent<Enemy>().maxBeerPoint;
        }

        if(player != null)
        {
            player.GetComponent<Player>().movePoint = player.GetComponent<Player>().maxMovePoint;
            player.GetComponent<Player>().actionPoints = player.GetComponent<Player>().maxActionPoint;
            player.GetComponent<Player>().beerPoint = player.GetComponent<Player>().maxBeerPoint;
        }
    }

    private void EndPlayerTurn()
    {        
        UpdatePoints();
    }
}
