using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainUIUpdate : MonoBehaviour
{
    [SerializeField] private Player player;



    [SerializeField] private TMP_Text turn;

    [SerializeField] private TMP_Text HPText;
    [SerializeField] private TMP_Text ArmorText;

    [SerializeField] private TMP_Text MovePointText;
    [SerializeField] private TMP_Text ActionPointText;
    //private TMP_Text BeerPointText;

    [SerializeField] private TMP_Text PhysicalDamageText;
    //private TMP_Text HPText;
    //private TMP_Text HPText;
    //private TMP_Text HPText;
    //private TMP_Text HPText;


    private void OnEnable()
    {
        Player.playerSpawned += AddPlayer;
    }
    private void OnDisable()
    {
        Player.playerSpawned += AddPlayer;
    }

    private void FixedUpdate()
    {
        turn.text = "TURN: " + TurnManager.turnCount.ToString();

        if (player != null)
        {
            HPText.text = "HP: " + player.HP.ToString();
            ArmorText.text = "ARMOR: " + player.armor.ToString();

            MovePointText.text = "MOVE: " + player.movePoint.ToString();
            ActionPointText.text = "ACT: " + player.actionPoints.ToString();

            PhysicalDamageText.text = "DMG: " + player.physicalDamage.ToString();
        }
       

    }

    private void AddPlayer(Player player)
    {
        this.player = player;
    }
}
