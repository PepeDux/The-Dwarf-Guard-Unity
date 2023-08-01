using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPScript : MonoBehaviour
{
    void Update()
    {
        CheckXP();
    }


    public void CheckXP()
    {
        //Опыт
        if (GetComponent<MainObject>().XP >= GetComponent<MainObject>().maxXP)
        {
            GetComponent<MainObject>().XP = GetComponent<MainObject>().maxXP - GetComponent<MainObject>().XP;
            GetComponent<MainObject>().HP = GetComponent<MainObject>().maxHP;
            GetComponent<MainObject>().level++;
            //переход на следующий лвл
        }

        //Левел
        if (GetComponent<MainObject>().level >= GetComponent<MainObject>().maxLevel)
        {
            GetComponent<MainObject>().level = GetComponent<MainObject>().maxLevel;
        }

    }
}
