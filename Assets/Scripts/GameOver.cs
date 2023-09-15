using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public static Action gameOvered;

    private void OnEnable()
    {
        TakeDamageScript.playerDead += ShowEnd;
    }
    private void OnDisable()
    {
        TakeDamageScript.playerDead -= ShowEnd;
    }



    private void Update()
    {
        CheckLevel();
    }


    private void ShowEnd()
    {
        Debug.Log("GAMEOVER");
        gameOvered?.Invoke();
    }

    private void CheckLevel()
    {
        if (TurnManager.turnCount == 20)
        {
            TurnManager.turnCount = 1;
            GameOver.gameOvered?.Invoke();
        }
    }
}
