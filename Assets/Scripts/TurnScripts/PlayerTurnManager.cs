using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnManager : MonoBehaviour
{
    public static Action playerTurnFinished;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            playerTurnFinished?.Invoke();

            TurnManager.turnCount += 1;

            Debug.Log("End Turn");
        }
    }
}
