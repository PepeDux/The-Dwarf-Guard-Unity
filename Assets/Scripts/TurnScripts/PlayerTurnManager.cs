using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(TurnManager.playerTurn == true && Input.GetKeyDown(KeyCode.Space))
        {
            TurnManager.playerTurn = false;
            TurnManager.totalTurn = false;

            Debug.Log("End Turn");
        }
    }
}
