using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PereodicDamage : MonoBehaviour
{
    private PoolOfBlood poolOfBlood;
    [SerializeField] public GameObject gam;
    public GameObject player;

    MainObject mainObject = new MainObject();

    public GameObject effectPoison;
    public GameObject effectFire;
    public GameObject effectCurse;
    public GameObject effectFrost;
    public GameObject effectDrunkenness;

    private int timePoison;
    private float damagePoison;
    private int intervalPoison;

    private int timeFire;
    private float damageFire;
    private int intervalFire;  

    private int timeCurse;
    private float damageCurse;
    private int intervalCurse;

    private int timeFrost;
    private float damageFrost;
    private int intervalFrost;

    private int timeDrunkenness;
    private float damageDrunkenness;
    private int intervalDrunkenness;



    void Start()
    {

        mainObject = GetComponent<MainObject>();
    }
    public void takeInfo(int timeInfo, int damageInfo, int intervalInfo, string typeInfo)
    {


        poolOfBlood = gam.GetComponent<PoolOfBlood>();

        if (typeInfo == "Poison")
        {
            if(mainObject.statusPoison)
            {
                if(timePoison < timeInfo)
                {
                    timePoison = timeInfo;
                }

                if(damagePoison < timePoison)
                {
                    damagePoison = damageInfo;
                }

                if(intervalPoison > intervalInfo)
                {
                    intervalPoison = intervalInfo;
                }                        
            }
            
            if(!mainObject.statusPoison)
            {
                timePoison = timeInfo;
                damagePoison = damageInfo;
                intervalPoison = intervalInfo;

                mainObject.statusPoison = true;

                StartCoroutine("Poison");
            }
        }

        ///////////////////////////////////////////////////////////////////

        if (typeInfo == "Fire")
        {
            if (mainObject.statusFire)
            {
                if (timeFire < timeInfo)
                {
                    timeFire = timeInfo;
                }

                if (damageFire < timeFire)
                {
                    damageFire = damageInfo;
                }

                if (intervalFire > intervalInfo)
                {
                    intervalFire = intervalInfo;
                }
            }

            if (!mainObject.statusFire)
            {
                timeFire = timeInfo;
                damageFire = damageInfo;
                intervalFire = intervalInfo;

                mainObject.statusFire = true;

                StartCoroutine("Fire");
            }
        }

        ///////////////////////////////////////////////////////////////////

        if (typeInfo == "Curse")
        {
            if (mainObject.statusCurse)
            {
                if (timeCurse < timeInfo)
                {
                    timeCurse = timeInfo;
                }

                if (damageCurse < timeCurse)
                {
                    damageCurse = damageInfo;
                }

                if (intervalCurse > intervalInfo)
                {
                    intervalCurse = intervalInfo;
                }
            }

            if (!mainObject.statusCurse)
            {
                timeCurse = timeInfo;
                damageCurse = damageInfo;
                intervalCurse = intervalInfo;

                mainObject.statusCurse = true;

                StartCoroutine("Curse");
            }
        }

        ///////////////////////////////////////////////////////////////////

        if (typeInfo == "Frost")
        {
            if (mainObject.statusFrost)
            {
                if (timeFrost < timeInfo)
                {
                    timeFrost = timeInfo;
                }

                if (damageFrost < timeFire)
                {
                    damageFrost = damageInfo;
                }

                if (intervalFrost > intervalInfo)
                {
                    intervalFrost = intervalInfo;
                }
            }

            if (!mainObject.statusFrost)
            {
                timeFrost = timeInfo;
                damageFrost = damageInfo;
                intervalFrost = intervalInfo;

                mainObject.statusFrost = true;

                StartCoroutine("Frost");
            }
        }

        ///////////////////////////////////////////////////////////////////

        if (typeInfo == "Drunkenness")
        {
            if (mainObject.statusDrunkenness)
            {
                if (timeDrunkenness < timeInfo)
                {
                    timeDrunkenness = timeInfo;
                }

                if (damageDrunkenness < timeFire)
                {
                    damageDrunkenness = damageInfo;
                }

                if (intervalDrunkenness > intervalInfo)
                {
                    intervalDrunkenness = intervalInfo;
                }
            }

            if (!mainObject.statusDrunkenness)
            {
                timeDrunkenness = timeInfo;
                damageDrunkenness = damageInfo;
                intervalDrunkenness = intervalInfo;

                mainObject.statusDrunkenness = true;

                StartCoroutine("Drunkenness");
            }
        }

    }
    IEnumerator Poison()
    {
        Player.speed -= 1f;

        for (int i = 0; i < (timePoison / intervalPoison); timePoison -= intervalPoison)
        {
            yield return new WaitForSeconds(intervalPoison);

            Instantiate(effectPoison, player.transform.position, transform.rotation);
           
            player.GetComponent<Player>().TakeDamage(damagePoison * (1 - Player.poisonResist / 100));             
        }

        Player.speed += 1f;

        mainObject.statusPoison = false;
        Debug.Log("Я закончил");
    }

    IEnumerator Fire()
    {
        for (int i = 0; i < (timeFire / intervalFire); timeFire -= intervalFire)
        {
            yield return new WaitForSeconds(intervalFire);

            Instantiate(effectFire, player.transform.position, transform.rotation);

            player.GetComponent<Player>().TakeDamage(damageFire * (1 - Player.fireResist / 100));
        }

        mainObject.statusFire = false;
        Debug.Log("Я закончил");
    }

    IEnumerator Curse()
    {
        for (int i = 0; i < (timeCurse / intervalCurse); timeCurse -= intervalCurse)
        {
            yield return new WaitForSeconds(intervalCurse);

            Instantiate(effectCurse, player.transform.position, transform.rotation);

            player.GetComponent<Player>().TakeDamage(damageCurse * (1 - Player.curseResist / 100));
        }

        mainObject.statusCurse = false;
        Debug.Log("Я закончил");
    }

    IEnumerator Frost()
    {
        for (int i = 0; i < (timeFrost / intervalFrost); timeFrost -= intervalFrost)
        {
            yield return new WaitForSeconds(intervalFrost);

            Instantiate(effectFrost, player.transform.position, transform.rotation);

            player.GetComponent<Player>().TakeDamage(damageFrost * (1 - Player.frostResist / 100));
        }

        mainObject.statusFrost = false;
        Debug.Log("Я закончил");
    }

    IEnumerator Drunkenness()
    {
        for (int i = 0; i < (timeDrunkenness / intervalDrunkenness); timeFire -= intervalDrunkenness)
        {
            yield return new WaitForSeconds(intervalDrunkenness);

            Instantiate(effectDrunkenness, player.transform.position, transform.rotation);

            //player.GetComponent<Player>().TakeDamage(damageDrunkenness * (1 - Player.drunkennessResist / 100));
        }

        mainObject.statusDrunkenness = false;
        Debug.Log("Я закончил");
    }

}
