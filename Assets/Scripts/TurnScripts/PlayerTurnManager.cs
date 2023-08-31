using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnManager : MonoBehaviour
{
    public static Action playerTurnFinished;

    private Player player;



    private void OnEnable()
    {
        Player.playerSpawned += AddPlayer;
    }
    private void OnDisable()
    {
        Player.playerSpawned -= AddPlayer;
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && player != null)
        {
            playerTurnFinished?.Invoke();

            Debug.Log("End Turn: " + TurnManager.turnCount);

            TurnManager.turnCount += 1;  
        }
    }

    private void AddPlayer(Player player)
    {
        this.player = player;
    }
}
