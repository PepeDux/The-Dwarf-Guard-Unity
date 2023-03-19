using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PereodicDamageScript : MonoBehaviour
{
    #region Pereodic Damage

    [Header("Эффекты")]
    //Ссылаемся на эффекты из префабов
    public GameObject effectPoison;
    public GameObject effectFire;
    public GameObject effectCurse;
    public GameObject effectFrost;
    public GameObject effectDrunkenness;

    [Header("Активность эффектов")]
    //Статус активности того ил иного статуса
    public bool statusPoison = false;
    public bool statusFire = false;
    public bool statusCurse = false;
    public bool statusFrost = false;
    public bool statusDrunkenness = false;

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



    public void TakeInfo(int timeInfo, int damageInfo, int intervalInfo, string typeInfo)
    {
        if (typeInfo == "Poison")
        {
            if (statusPoison)
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

            if (!statusPoison)
            {
                timePoison = timeInfo;
                pereodicPoisonDamage = damageInfo;
                intervalPoison = intervalInfo;

                statusPoison = true;

                StartCoroutine("Poison");
            }
        }

        ///////////////////////////////////////////////////////////////////
        if (typeInfo == "Fire")
        {
            if (statusFire)
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

            if (!statusFire)
            {
                timeFire = timeInfo;
                pereodicFireDamage = damageInfo;
                intervalFire = intervalInfo;

                statusFire = true;

                StartCoroutine("Fire");
            }
        }

        ///////////////////////////////////////////////////////////////////

        if (typeInfo == "Curse")
        {
            if (statusCurse)
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

            if (!statusCurse)
            {
                timeCurse = timeInfo;
                pereodiCcurseDamage = damageInfo;
                intervalCurse = intervalInfo;

                statusCurse = true;

                StartCoroutine("Curse");
            }
        }

        ///////////////////////////////////////////////////////////////////

        if (typeInfo == "Frost")
        {
            if (statusFrost)
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

            if (!statusFrost)
            {
                timeFrost = timeInfo;
                pereodicFrostDamage = damageInfo;
                intervalFrost = intervalInfo;

                statusFrost = true;

                StartCoroutine("Frost");
            }
        }

        ///////////////////////////////////////////////////////////////////

        if (typeInfo == "Drunkenness")

        {
            if (statusDrunkenness)
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

            if (!statusDrunkenness)
            {
                timeDrunkenness = timeInfo;
                pereodicDrunkennessDamage = damageInfo;
                intervalDrunkenness = intervalInfo;

                statusDrunkenness = true;

                StartCoroutine("Drunkenness");
            }
        }
    }
    IEnumerator Poison()
    {
        GetComponent<MainObject>().speed -= 1f;

        for (int i = 0; i < (timePoison / intervalPoison); timePoison -= intervalPoison)
        {
            yield return new WaitForSeconds(intervalPoison);

            Instantiate(effectPoison, this.transform.position, transform.rotation);

            GetComponent<TakeDamageScript>().TakeDamage(poisonDamage: pereodicPoisonDamage);
        }

        GetComponent<MainObject>().speed += 1f;

        statusPoison = false;
        Debug.Log("Я закончил");
    }

    IEnumerator Fire()
    {
        for (int i = 0; i < (timeFire / intervalFire); timeFire -= intervalFire)
        {
            yield return new WaitForSeconds(intervalFire);

            Instantiate(effectFire, this.transform.position, transform.rotation);

            GetComponent<TakeDamageScript>().TakeDamage(fireDamage: pereodicFireDamage);
        }

        statusFire = false;
        Debug.Log("Я закончил");
    }

    IEnumerator Curse()
    {
        for (int i = 0; i < (timeCurse / intervalCurse); timeCurse -= intervalCurse)
        {
            yield return new WaitForSeconds(intervalCurse);

            Instantiate(effectCurse, this.transform.position, transform.rotation);

            GetComponent<TakeDamageScript>().TakeDamage(curseDamage: pereodiCcurseDamage);
        }

        statusCurse = false;
        Debug.Log("Я закончил");
    }

    IEnumerator Frost()
    {
        for (int i = 0; i < (timeFrost / intervalFrost); timeFrost -= intervalFrost)
        {
            yield return new WaitForSeconds(intervalFrost);

            Instantiate(effectFrost, this.transform.position, transform.rotation);

            GetComponent<TakeDamageScript>().TakeDamage(frostDamage: pereodicFrostDamage);
        }

        statusFrost = false;
        Debug.Log("Я закончил");
    }

    IEnumerator Drunkenness()
    {
        for (int i = 0; i < (timeDrunkenness / intervalDrunkenness); timeFire -= intervalDrunkenness)
        {
            yield return new WaitForSeconds(intervalDrunkenness);

            Instantiate(effectDrunkenness, this.transform.position, transform.rotation);

            GetComponent<TakeDamageScript>().TakeDamage(drunkennessDamage: pereodicDrunkennessDamage);
        }

        statusDrunkenness = false;
        Debug.Log("Я закончил");
    }

    #endregion
}
