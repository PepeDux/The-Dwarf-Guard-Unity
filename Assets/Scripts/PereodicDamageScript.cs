using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PereodicDamageScript : MonoBehaviour
{
    #region Pereodic Damage

    [SerializeField] private StatusData[] statuses;

    [Header("Активность эффектов")]
    //Статус активности того ил иного статуса
    public bool poisonStatus = false;
    public bool fireStatus = false;
    public bool curseStatus = false;
    public bool frostStatus = false;
    public bool drunkennessStatus = false;

    //Структура переменных кода ниже:
    //time - Время длительности эффекта
    //pereodic - Урон от эффекта срабатываемый от интервала
    //interval - Время ожидания получения урона

    private int timePoison;
    private int pereodicPoisonDamage;
    private int intervalPoison = 5;

    private int timeFire;
    private int pereodicFireDamage;
    private int intervalFire = 3;

    private int timeCurse;
    private int pereodiCcurseDamage;
    private int intervalCurse = 20;

    private int timeFrost;
    private int pereodicFrostDamage;
    private int intervalFrost = 7;

    private int timeDrunkenness;
    private int pereodicDrunkennessDamage;
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

                //GetComponent<StatusCalculation>().statusAdd = poisonEffect.name;

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

                //GetComponent<StatusCalculation>().statusAdd = fireEffect.name;

                StartCoroutine("Fire");
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

                //GetComponent<StatusCalculation>().statusAdd = frostEffect.name;

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

                //GetComponent<StatusCalculation>().statusAdd = drunkennessEffect.name;

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

        //GetComponent<StatusCalculation>().statusRemove = poisonEffect.name;
        poisonStatus = false;
        Debug.Log("Я закончил");
    }

    IEnumerator Fire()
    {
        for (int i = 0; i < (timeFire / intervalFire); timeFire -= intervalFire)
        {
            yield return new WaitForSeconds(intervalFire);

            Instantiate(fireEffect, this.transform.position, transform.rotation);

            GetComponent<TakeDamageScript>().TakeDamage(fireDamage: pereodicFireDamage);
        }

        //GetComponent<StatusCalculation>().statusRemove = fireEffect.name;
        fireStatus = false;
        Debug.Log("Я закончил");
    }

    IEnumerator Frost()
    {
        for (int i = 0; i < (timeFrost / intervalFrost); timeFrost -= intervalFrost)
        {
            yield return new WaitForSeconds(intervalFrost);

            Instantiate(frostEffect, this.transform.position, transform.rotation);

            GetComponent<TakeDamageScript>().TakeDamage(frostDamage: pereodicFrostDamage);
        }

        //GetComponent<StatusCalculation>().statusRemove = frostEffect.name;
        frostStatus = false;
        Debug.Log("Я закончил");
    }

    IEnumerator Drunkenness()
    {
        for (int i = 0; i < (timeDrunkenness / intervalDrunkenness); timeDrunkenness -= intervalDrunkenness)
        {
            yield return new WaitForSeconds(intervalDrunkenness);

            Instantiate(drunkennessEffect, this.transform.position, transform.rotation);

            GetComponent<TakeDamageScript>().TakeDamage(drunkennessDamage: pereodicDrunkennessDamage);
        }

        //GetComponent<StatusCalculation>().statusRemove = drunkennessEffect.name;
        drunkennessStatus = false;
        Debug.Log("Я закончил");
    }

    #endregion
}
