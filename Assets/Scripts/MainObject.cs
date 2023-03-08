using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainObject : MonoBehaviour
{
    public Animator anim;

    public GameObject[] loot;
    public static int randomEnemy;


    #region Characteristic

    private int freeCharacteristicLevel = 0;
    private int CharacteristicLevel = 0;
    private int maxCharacteristicLevel = 10;

    //Здоровье
    public float HP = 100;
    public float maxHP = 100;
    private int HPCharac = 1;
    public int maxHPCharac = 10;

    //Энергия
    public float energy = 30;
    public float maxEnergy = 30;
    public float energyWaste = 10;
    private int energyCharac = 1;
    private int maxEnergyCharac = 10;

    //Скорость востановления энергии
    private float energyRegeneration = 0;
    private float maxEnergyRegeneration = 30;
    private int energyCharacRegeneration = 1;
    private int maxEnergyCharacRegeneration = 10;

    //Броня
    private float armor = 0;
    private float maxArmor = 100;
    private int armorCharac = 1;
    private int maxArmorCharac = 10;

    //Урон
    private int damage = 0;
    private int maxDamage = 100;

    //Опыт
    private float XP = 0;
    private float maxXP = 100;

    //Уровень
    private int level = 0;
    private int maxLevel = 10;

    //Деньги
    public int money = 0;






    //Сила
    private int strength = 0;
    private int maxStrength = 10;
    private int strengthCharac = 0;
    private int maxStrengthCharac = 10;

    //Ловкость
    private int agility = 0;
    private int maxAgility = 10;
    private int agilityCharac = 0;
    private int maxAgilityhCharac = 10;

    //Интеллект
    private int intel = 0;
    private int maxIntel = 10;
    private int intelCharac = 0;
    private int maxIntelCharac = 10;

    //Телосложение
    private int constitution = 0;
    private int maxConstitution = 10;
    private int constitutionCharac = 0;
    private int maxConstitutionCharac = 10;

    //Мудрость
    private int wisdom = 0;
    private int maxWisdom = 10;
    private int wisdomCharac = 0;
    private int maxWisdomCharac = 10;





    //Уклонение
    private int dodge = 0;
    private int maxDodge = 10;
    private int dodgeCharac = 0;
    private int maxDodgeCharac = 10;

    //Переносимый вес
    private int carryingCapacity = 0;
    private int maxCarryingCapacity = 10;
    private int carryingCapacityCharac = 1;
    private int maxCarryingCapacityCharac = 10;

    //Скорость
    public float speed = 2f;
    private float maxSpeed = 10f;
    private int speedCharac = 1;
    private int maxSpeecCharac = 10;

    //Скорость атаки
    private float attackSpeed = 0;
    private float maxAttackSpeed = 10;
    private float attackSpeedCharac = 0;
    private float maxAttackSpeedCharac = 10;

    //Критический урон
    private float criticalDamage = 0;
    private float maxCriticalDamage = 10;
    private float criticalDamageCharac = 0;
    private float maxCriticalDamageCharac = 10;

    //Точность
    private float precision = 0;
    private float maxPrecisionDamage = 10;
    private float precisionCharac = 0;
    private float maxPrecisionDamageCharac = 10;





    //Сытость
    private int satiety = 0;
    private int maxSatiety = 10;

    //Опьянение
    private int drunkenness = 0;
    private int maxDrunkenness = 10;




    //Сопротивление огню
    private float fireResist = 0;
    private int maxFireResist = 10;
    private int fireResistCharac = 0;
    private int maxFireResistCharac = 10;

    //Сопротивление ядам
    private float poisonResist = 0;
    private int maxPoisonResist = 100;
    private int poisonResistCharac = 0;
    private int maxPoisonResistCharac = 10;

    //Сопростивление морозу
    private float frostResist = 0;
    private int maxFrostResist = 10;
    private int frostResistCharac = 0;
    private int maxFrostResistCharac = 10;

    //Сопротивление проклятию
    private float curseResist = 0;
    private int maxCurseResist = 10;
    private int curseResistCharac = 0;
    private int maxCurseResistCharac = 10;

    //Сопротивление рунной магии
    private float runesResist = 0;
    private int maxRunesResist = 10;
    private int runesResistCharac = 0;
    private int maxRunesResistCharac = 10;

    #endregion


    #region Talents




    #endregion




    //Скрипт TakeDamage обрабатывает типы урона поступаемые объектам
    //Он учитывает сопроивления к урону в объекте и выдает  итоге дамаг после вычислений
    //
    //
    //
    //К скрипту можно обратиться так - TakeDamage(Damage:15, Damage:43); минуя не нужные типы урона

    public void TakeDamage
        (
        float prickDamage = 0, 
        float slashDamage = 0, 
        float crushDamage = 0, 
        float impactDamage = 0,
        float poisonDamage = 0, 
        float fireDamage = 0, 
        float frostDamage = 0,        
        float electricalDamage = 0,
        float runeDamage = 0,
        float holyDamage = 0,
        float curseDamage = 0
        )
    {
        if (damage > 0)
        {
            HP -= damage;
            anim.SetTrigger("TakeDamage");
        }

        if (HP <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("I die");

        //loot = UnityEngine.Random.Range(0, loot.Length);

        //Instantiate(loot[randomEnemy], transform.position, transform.rotation);

        gameObject.SetActive(false);
    }

    #region Pereodic Damage

    public GameObject effectPoison;
    public GameObject effectFire;
    public GameObject effectCurse;
    public GameObject effectFrost;
    public GameObject effectDrunkenness;

    public bool statusPoison = false;
    public bool statusFire = false;
    public bool statusCurse = false;
    public bool statusFrost = false;
    public bool statusDrunkenness = false;

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



    public void takeInfo(int timeInfo, int damageInfo, int intervalInfo, string typeInfo)
    {
        if (typeInfo == "Poison")
        {
            if (statusPoison)
            {
                if (timePoison < timeInfo)
                {
                    timePoison = timeInfo;
                }

                if (damagePoison < timePoison)
                {
                    damagePoison = damageInfo;
                }

                if (intervalPoison > intervalInfo)
                {
                    intervalPoison = intervalInfo;
                }
            }

            if (!statusPoison)
            {
                timePoison = timeInfo;
                damagePoison = damageInfo;
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

                if (damageFire < timeFire)
                {
                    damageFire = damageInfo;
                }

                if (intervalFire > intervalInfo)
                {
                    intervalFire = intervalInfo;
                }
            }

            if (!statusFire)
            {
                timeFire = timeInfo;
                damageFire = damageInfo;
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

                if (damageCurse < timeCurse)
                {
                    damageCurse = damageInfo;
                }

                if (intervalCurse > intervalInfo)
                {
                    intervalCurse = intervalInfo;
                }
            }

            if (!statusCurse)
            {
                timeCurse = timeInfo;
                damageCurse = damageInfo;
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

                if (damageFrost < timeFire)
                {
                    damageFrost = damageInfo;
                }

                if (intervalFrost > intervalInfo)
                {
                    intervalFrost = intervalInfo;
                }
            }

            if (!statusFrost)
            {
                timeFrost = timeInfo;
                damageFrost = damageInfo;
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

                if (damageDrunkenness < timeFire)
                {
                    damageDrunkenness = damageInfo;
                }

                if (intervalDrunkenness > intervalInfo)
                {
                    intervalDrunkenness = intervalInfo;
                }
            }

            if (!statusDrunkenness)
            {
                timeDrunkenness = timeInfo;
                damageDrunkenness = damageInfo;
                intervalDrunkenness = intervalInfo;

                statusDrunkenness = true;

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

            Instantiate(effectPoison, this.transform.position, transform.rotation);

            //TakeDamage(damagePoison * (1 - Player.poisonResist / 100));
        }

        Player.speed += 1f;

        statusPoison = false;
        Debug.Log("Я закончил");
    }

    IEnumerator Fire()
    {
        for (int i = 0; i < (timeFire / intervalFire); timeFire -= intervalFire)
        {
            yield return new WaitForSeconds(intervalFire);

            Instantiate(effectFire, this.transform.position, transform.rotation);
                
            //TakeDamage(damageFire * (1 - Player.fireResist / 100));
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

            //TakeDamage(damageCurse * (1 - Player.curseResist / 100));
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

            //TakeDamage(damageFrost * (1 - Player.frostResist / 100));
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

            //player.GetComponent<Player>().TakeDamage(damageDrunkenness * (1 - Player.drunkennessResist / 100));
        }

        statusDrunkenness = false;
        Debug.Log("Я закончил");
    }



    #endregion
}







