using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PereodicDamageScript : MonoBehaviour
{
    #region Pereodic Damage

    [SerializeField] private StatusData[] statuses;

    [Header("���������� ��������")]
    //������ ���������� ���� �� ����� �������
    public bool poisonStatus = false;
    public bool fireStatus = false;
    public bool curseStatus = false;
    public bool frostStatus = false;
    public bool drunkennessStatus = false;

    //��������� ���������� ���� ����:
    //time - ����� ������������ �������
    //pereodic - ���� �� ������� ������������� �� ���������
    //interval - ����� �������� ��������� �����

    private int timePoison;
    private float pereodicPoisonDamage;
    private int intervalPoison = 5;

    private int timeFire;
    private float pereodicFireDamage;
    private int intervalFire = 3;

    private int timeCurse;
    private float pereodiCcurseDamage;
    private int intervalCurse = 20;

    private int timeFrost;
    private float pereodicFrostDamage;
    private int intervalFrost = 7;

    private int timeDrunkenness;
    private float pereodicDrunkennessDamage;
    private int intervalDrunkenness = 10;



    private GameObject poisonEffect;
    private GameObject fireEffect;
    private GameObject frostEffect;
    private GameObject curseEffect;
    private GameObject drunkennessEffect;
    
    
    private void Start()
    {
        statuses = Resources.LoadAll<StatusData>("Statuses");

        foreach(StatusData status in statuses)
        {
            if(status.name == "Poison")
            {
                poisonEffect = status.prefab;
            }

            if(status.name == "Fire")
            {
                fireEffect = status.prefab;
            }

            if(status.name == "Frost")
            {
                frostEffect = status.prefab;
            }

            if (status.name == "Curse")
            {
                curseEffect = status.prefab;
            }

            if (status.name == "Drunkenness")
            {
                drunkennessEffect = status.prefab;
            }
        }
    }

    public void TakeInfo(int timeInfo, int damageInfo, string typeInfo)
    {
        if (typeInfo == "Poison")
        {
            if (poisonStatus)
            {
                if (timePoison < timeInfo)
                {
                    timePoison = timeInfo;
                }

                if (pereodicPoisonDamage < timePoison)
                {
                    pereodicPoisonDamage = damageInfo;
                }
            }

            if (!poisonStatus)
            {
                timePoison = timeInfo;
                pereodicPoisonDamage = damageInfo;

                poisonStatus = true;

                GetComponent<StatusCalculation>().statusAdd = "Poison";

                StartCoroutine("Poison");
            }
        }

        ///////////////////////////////////////////////////////////////////

        if (typeInfo == "Fire")
        {
            if (fireStatus)
            {
                if (timeFire < timeInfo)
                {
                    timeFire = timeInfo;
                }

                if (pereodicFireDamage < timeFire)
                {
                    pereodicFireDamage = damageInfo;
                }
            }

            if (!fireStatus)
            {
                timeFire = timeInfo;
                pereodicFireDamage = damageInfo;

                fireStatus = true;

                GetComponent<StatusCalculation>().statusAdd = "Fire";

                StartCoroutine("Fire");
            }
        }

        ///////////////////////////////////////////////////////////////////

        if (typeInfo == "Curse")
        {
            if (curseStatus)
            {
                if (timeCurse < timeInfo)
                {
                    timeCurse = timeInfo;
                }

                if (pereodiCcurseDamage < timeCurse)
                {
                    pereodiCcurseDamage = damageInfo;
                }
            }

            if (!curseStatus)
            {
                timeCurse = timeInfo;
                pereodiCcurseDamage = damageInfo;

                curseStatus = true;

                GetComponent<StatusCalculation>().statusAdd = "Curse";

                StartCoroutine("Curse");
            }
        }

        ///////////////////////////////////////////////////////////////////

        if (typeInfo == "Frost")
        {
            if (frostStatus)
            {
                if (timeFrost < timeInfo)
                {
                    timeFrost = timeInfo;
                }

                if (pereodicFrostDamage < timeFire)
                {
                    pereodicFrostDamage = damageInfo;
                }
            }

            if (!frostStatus)
            {
                timeFrost = timeInfo;
                pereodicFrostDamage = damageInfo;

                frostStatus = true;

                GetComponent<StatusCalculation>().statusAdd = "Frost";

                StartCoroutine("Frost");
            }
        }

        ///////////////////////////////////////////////////////////////////

        if (typeInfo == "Drunkenness")

        {
            if (drunkennessStatus)
            {
                if (timeDrunkenness < timeInfo)
                {
                    timeDrunkenness = timeInfo;
                }

                if (pereodicDrunkennessDamage < timeFire)
                {
                    pereodicDrunkennessDamage = damageInfo;
                }
            }

            if (!drunkennessStatus)
            {
                timeDrunkenness = timeInfo;
                pereodicDrunkennessDamage = damageInfo;

                drunkennessStatus = true;

                GetComponent<StatusCalculation>().statusAdd = "Drunkenness";

                StartCoroutine("Drunkenness");
            }
        }

    }


    IEnumerator Poison()
    {
        for (int i = 0; i < (timePoison / intervalPoison); timePoison -= intervalPoison)
        {
            yield return new WaitForSeconds(intervalPoison);

            Instantiate(poisonEffect, this.transform.position, transform.rotation);
            
            GetComponent<TakeDamageScript>().TakeDamage(poisonDamage: pereodicPoisonDamage);
        }

        GetComponent<StatusCalculation>().statusRemove = "Poison";
        poisonStatus = false;
        Debug.Log("� ��������");
    }

    IEnumerator Fire()
    {
        for (int i = 0; i < (timeFire / intervalFire); timeFire -= intervalFire)
        {
            yield return new WaitForSeconds(intervalFire);

            Instantiate(fireEffect, this.transform.position, transform.rotation);

            GetComponent<TakeDamageScript>().TakeDamage(fireDamage: pereodicFireDamage);
        }

        GetComponent<StatusCalculation>().statusRemove = "Fire";
        fireStatus = false;
        Debug.Log("� ��������");
    }

    IEnumerator Curse()
    {
        for (int i = 0; i < (timeCurse / intervalCurse); timeCurse -= intervalCurse)
        {
            yield return new WaitForSeconds(intervalCurse);

            Instantiate(curseEffect, this.transform.position, transform.rotation);

            GetComponent<TakeDamageScript>().TakeDamage(curseDamage: pereodiCcurseDamage);
        }

        GetComponent<StatusCalculation>().statusRemove = "Curse";
        curseStatus = false;
        Debug.Log("� ��������");
    }

    IEnumerator Frost()
    {
        for (int i = 0; i < (timeFrost / intervalFrost); timeFrost -= intervalFrost)
        {
            yield return new WaitForSeconds(intervalFrost);

            Instantiate(frostEffect, this.transform.position, transform.rotation);

            GetComponent<TakeDamageScript>().TakeDamage(frostDamage: pereodicFrostDamage);
        }

        GetComponent<StatusCalculation>().statusRemove = "Frost";
        frostStatus = false;
        Debug.Log("� ��������");
    }

    IEnumerator Drunkenness()
    {
        for (int i = 0; i < (timeDrunkenness / intervalDrunkenness); timeDrunkenness -= intervalDrunkenness)
        {
            yield return new WaitForSeconds(intervalDrunkenness);

            Instantiate(drunkennessEffect, this.transform.position, transform.rotation);

            GetComponent<TakeDamageScript>().TakeDamage(drunkennessDamage: pereodicDrunkennessDamage);
        }

        GetComponent<StatusCalculation>().statusRemove = "Drunkenness";
        drunkennessStatus = false;
        Debug.Log("� ��������");
    }

    #endregion
}
