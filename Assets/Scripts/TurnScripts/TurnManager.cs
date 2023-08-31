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

    public Player player;
    public GameObject tileManager;



    private void OnEnable()
    {
        //Подписываемся на событие конца хода игрока 
        PlayerTurnManager.playerTurnFinished += EndPlayerTurn;
        Player.playerSpawned += AddPlayer;
    }

    private void OnDisable()
    {
        //Отписываемся на событие конца хода игрока 
        PlayerTurnManager.playerTurnFinished -= EndPlayerTurn;
        Player.playerSpawned -= AddPlayer;
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
            player.movePoint = player.maxMovePoint;
            player.actionPoints = player.maxActionPoint;
            player.beerPoint = player.maxBeerPoint;
        }
    }

    private void EndPlayerTurn()
    {        
        UpdatePoints();
    }

    private void AddPlayer(Player player)
    {
        this.player = player;
    }
}
