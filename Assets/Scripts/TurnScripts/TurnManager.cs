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

    public static bool playerTurn = true; //При завершении хода игрока - true, при начале хода игрока - true
    public static bool totalTurn = false; //При завершении всех действий на этот ход

    public GameObject player;
    public GameObject tileManager;



    private void OnEnable()
    {
        PlayerTurnManager.playerTurnFinished += OtherObjectsTurn;
    }

    private void OnDisable()
    {
        PlayerTurnManager.playerTurnFinished -= OtherObjectsTurn;
    }



    public void UpdatePoints()
    {
        foreach (var obj in TileManager.enemyList)
        {
            obj.GetComponent<Enemy>().movePoint = obj.GetComponent<Enemy>().maxMovePoint;
            obj.GetComponent<Enemy>().actionPoints = obj.GetComponent<Enemy>().maxActionPoint;
            obj.GetComponent<Enemy>().beerPoint = obj.GetComponent<Enemy>().maxBeerPoint;
        }

        player.GetComponent<Player>().movePoint = player.GetComponent<Player>().maxMovePoint;
        player.GetComponent<Player>().actionPoints = player.GetComponent<Player>().maxActionPoint;
        player.GetComponent<Player>().beerPoint = player.GetComponent<Player>().maxBeerPoint;

        playerTurn = true;

    }

    private void OtherObjectsTurn()
    {
        EnemyTurn();
        UpdatePoints();
    }

    private void EnemyTurn()
    {
        for (int i = 0; i < TileManager.enemyList.Count; i++)
        {
            tileManager.GetComponent<TileManager>().TileGameObjectUpdatePosition();

            MainObject enemy = TileManager.enemyList[i];
            enemy.GetComponent<EnemyTileManager>().Turn();
        }
    }
}
