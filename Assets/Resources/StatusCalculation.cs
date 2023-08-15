using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class StatusCalculation : MonoBehaviour
{
    [SerializeField] private StatusData[] statuses;
    [SerializeField] List<string> activeStatusName = new List<string>();

    [HideInInspector] public string statusAdd; // ���������� ��������� �������� ������������ �������
    [HideInInspector] public string statusRemove; // ���������� ��������� �������� ���������� �������
    private int mod = 1; // ����������� �������������� ��� ������� ���������� � �������� ������� �� �������

    private void Start()
    {
        statuses = Resources.LoadAll<StatusData>("Statuses");
    }

    private void FixedUpdate()
    {
        Change();
    }
    private void Change()
    {
        if(statusAdd != null && statusAdd != "")
        {
            if (!activeStatusName.Contains(statusAdd))
            {
                �alculation();
                activeStatusName.Add(statusAdd);
                statusAdd = null;
            }
        }

        if (statusRemove != null && statusRemove != "")
        {
            if (activeStatusName.Contains(statusRemove))
            {
                �alculation();
                activeStatusName.Remove(statusRemove);
                statusRemove = null;
            }

        }
    }



    private void �alculation()
    {
        foreach (StatusData status in statuses)
        {
            if (status.name == statusAdd || status.name == statusRemove)
            {
                if(status.name == statusAdd)
                {
                    mod = 1;
                }
                else if(status.name == statusRemove)
                {
                    mod = -1;
                }

                GetComponent<TakeDamageScript>().TakeDamage(physicalDamage: status.physicalDamage);

                GetComponent<MainObject>().strengthBonus += mod * status.strength;
                GetComponent<MainObject>().dexterityBonus += mod * status.agility;
                GetComponent<MainObject>().inteligenceBonus += mod * status.intel;
                GetComponent<MainObject>().constitutionBonus += mod * status.constitution;
                GetComponent<MainObject>().wisdomBonus += mod * status.wisdom;

                GetComponent<MainObject>().criticalDamageBonus += mod * status.criticalDamage;
                GetComponent<MainObject>().criticalDamageChanceBonus += mod * status.CriticalDamageChance;
                GetComponent<MainObject>().precisionBonus += mod * status.Precision;
                GetComponent<MainObject>().drunkennessBonus += mod * status.drunkenness;

                GetComponent<MainObject>().poisonResistBonus += mod * status.poisonResist;
                GetComponent<MainObject>().fireResistBonus += mod * status.fireResist;
                GetComponent<MainObject>().frostResistBonus += mod * status.frostResist;
                GetComponent<MainObject>().drunkennessResistBonus += mod * status.drunkennessResist;
            }
        }
    }
}
