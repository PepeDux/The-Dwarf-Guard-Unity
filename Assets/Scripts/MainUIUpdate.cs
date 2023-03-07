using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIUpdate : MonoBehaviour
{
    public Image HPBar;
    public Image EnergyBar;
    public Text Money;
   
    void Start()
    {
        CheckStatus();
    }


    void Update()
    {
        CheckStatus();
    }

    public void CheckStatus()
    {
        HPBar.fillAmount = Player.HP / Player.maxHP * 1f;
        EnergyBar.fillAmount = Player.energy / Player.maxEnergy * 1f;
        Money.text = Player.money.ToString();

    }

    public void MinusHPE()
    {
        Player.HP--;
        Player.energy--;
    }

    public void PlusHPE()
    {
        Player.HP++;
        Player.energy++;
    }


}
