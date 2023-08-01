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

    private void FixedUpdate()
    {
        CheckStatus();
    }

    public void CheckStatus()
    {
        HPBar.fillAmount = GetComponent<MainObject>().HP / GetComponent<MainObject>().maxHP * 1f;
        EnergyBar.fillAmount = GetComponent<MainObject>().energy / GetComponent<MainObject>().maxEnergy * 1f;
        Money.text = GetComponent<MainObject>().money.ToString();
    }

}
