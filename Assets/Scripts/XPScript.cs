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
            GetComponent<MainObject>().XP = 0;
            GetComponent<MainObject>().HP = GetComponent<MainObject>().maxHP;
            //������� �� ��������� ���
        }

        //�����
        if (GetComponent<MainObject>().level >= GetComponent<MainObject>().maxLevel)
        {
            GetComponent<MainObject>().level = GetComponent<MainObject>().maxLevel;
        }

    }
}
