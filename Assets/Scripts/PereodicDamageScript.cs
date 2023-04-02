using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PereodicDamageScript : MonoBehaviour
{
    #region Pereodic Damage

    [SerializeField] private EffectData[] effects;

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
    private float pereodicPoisonDamage;
    private int intervalPoison;

    private int timeFire;
    private float pereodicFireDamage;
    private int intervalFire;

    private int timeCurse;
    private float pereodiCcurseDamage;
    private int intervalCurse;

    private int timeFrost;
    private float pereodicFrostDamage;
    private int intervalFrost;

    private int timeDrunkenness;
    private float pereodicDrunkennessDamage;
    private int intervalDrunkenness;



    private GameObject poisonEffect;
    private GameObject fireEffect;
    private GameObject frostEffect;
    private GameObject curseEffect;
    private GameObject drunkennessEffect;
    
    
    private void Start()
    {
        effects = Resources.LoadAll<EffectData>("PereodicEffects");

        foreach(EffectData effect in effects)
        {
            if(effect.type == "Poison")
            {
                poisonEffect = effect.prefab;
            }

            if(effect.type == "Fire")
            {
                fireEffect = effect.prefab;
            }

            if(effect.type == "Frost")
            {
                frostEffect = effect.prefab;
            }

            if (effect.type == "Curse")
            {
                curseEffect = effect.prefab;
            }

            if (effect.type == "Drunkenness")
            {
                drunkennessEffect = effect.prefab;
            }
        }
    }

    public void TakeInfo(int timeInfo, int damageInfo, int intervalInfo, string typeInfo)
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

                if (intervalPoison > intervalInfo)
                {
                    intervalPoison = intervalInfo;
                }
            }

            if (!poisonStatus)
            {
                timePoison = timeInfo;
                pereodicPoisonDamage = damageInfo;
                intervalPoison = intervalInfo;

                poisonStatus = true;

                GetComponent<StatusData>().statusAdd = "Poison";

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

                if (intervalFire > intervalInfo)
                {
                    intervalFire = intervalInfo;
                }
            }

            if (!fireStatus)
            {
                timeFire = timeInfo;
                pereodicFireDamage = damageInfo;
                intervalFire = intervalInfo;

                fireStatus = true;

                GetComponent<StatusData>().statusAdd = "Fire";

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

                if (intervalCurse > intervalInfo)
                {
                    intervalCurse = intervalInfo;
                }
            }

            if (!curseStatus)
            {
                timeCurse = timeInfo;
                pereodiCcurseDamage = damageInfo;
                intervalCurse = intervalInfo;

                curseStatus = true;

                GetComponent<StatusData>().statusAdd = "Curse";

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

                if (intervalFrost > intervalInfo)
                {
                    intervalFrost = intervalInfo;
                }
            }

            if (!frostStatus)
            {
                timeFrost = timeInfo;
                pereodicFrostDamage = damageInfo;
                intervalFrost = intervalInfo;

                frostStatus = true;

                GetComponent<StatusData>().statusAdd = "Frost";

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

                if (intervalDrunkenness > intervalInfo)
                {
                    intervalDrunkenness = intervalInfo;
                }
            }

            if (!drunkennessStatus)
            {
                timeDrunkenness = timeInfo;
                pereodicDrunkennessDamage = damageInfo;
                intervalDrunkenness = intervalInfo;

                drunkennessStatus = true;

                GetComponent<StatusData>().statusAdd = "Drunkenness";

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

        GetComponent<StatusData>().statusRemove = "Poison";
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

        GetComponent<StatusData>().statusRemove = "Fire";
        fireStatus = false;
        Debug.Log("Я закончил");
    }

    IEnumerator Curse()
    {
        for (int i = 0; i < (timeCurse / intervalCurse); timeCurse -= intervalCurse)
        {
            yield return new WaitForSeconds(intervalCurse);

            Instantiate(curseEffect, this.transform.position, transform.rotation);

            GetComponent<TakeDamageScript>().TakeDamage(curseDamage: pereodiCcurseDamage);
        }

        GetComponent<StatusData>().statusRemove = "Curse";
        curseStatus = false;
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

        GetComponent<StatusData>().statusRemove = "Frost";
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

        GetComponent<StatusData>().statusRemove = "Drunkenness";
        drunkennessStatus = false;
        Debug.Log("Я закончил");
    }

    #endregion
}
