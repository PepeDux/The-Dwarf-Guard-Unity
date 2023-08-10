using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainUIUpdate : MonoBehaviour
{
    [SerializeField] private GameObject player;



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

    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if(player != null)
        {
            turn.text = "TURN: " + TurnManager.turnCount.ToString();

            HPText.text = "HP: " + player.GetComponent<Player>().HP.ToString();
            ArmorText.text = "ARMOR: " + player.GetComponent<Player>().armor.ToString();

            MovePointText.text = "MOVE: " + player.GetComponent<Player>().movePoint.ToString();
            ActionPointText.text = "ACT: " + player.GetComponent<Player>().actionPoints.ToString();

            PhysicalDamageText.text = "DMG: " + player.GetComponent<Player>().physicalDamage.ToString();
        }
        else if (player == null)
        {
            HPText.enabled = false;
            ArmorText.enabled = false;

            MovePointText.enabled = false;
            ActionPointText.enabled = false;

            PhysicalDamageText.enabled = false;
        }

    }



}
