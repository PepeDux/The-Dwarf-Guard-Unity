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
        //����
        if (GetComponent<MainObject>().XP >= GetComponent<MainObject>().maxXP)
        {
            GetComponent<MainObject>().XP = GetComponent<MainObject>().maxXP - GetComponent<MainObject>().XP;
            GetComponent<MainObject>().HP = GetComponent<MainObject>().maxHP;
            GetComponent<MainObject>().level++;
            //������� �� ��������� ���
        }

        //�����
        if (GetComponent<MainObject>().level >= GetComponent<MainObject>().maxLevel)
        {
            GetComponent<MainObject>().level = GetComponent<MainObject>().maxLevel;
        }

    }
}
