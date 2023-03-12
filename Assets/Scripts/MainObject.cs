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

    //Энергия
    public float energy = 30;
    public float maxEnergy = 30;
    public float energyWaste = 10;

    //Скорость востановления энергии
    private float energyRegeneration = 0;
    private float maxEnergyRegeneration = 30;

    //Физическая броня
    private float physicalArmor;
    private float maxPhysicalArmor;

    //Магическая броня
    private float magicArmor;
    private float maxMagicArmor;

    //Урон наносимый объектом
    public float prickDamage = 0;
    public float slashDamage = 0;
    public float crushDamage = 0;
    public float poisonDamage = 0;
    public float fireDamage = 0;
    public float frostDamage = 0;
    public float electricalDamage = 0;
    public float runeDamage = 0;
    public float holyDamage = 0;
    public float curseDamage = 0;
    public float drunkennessDamage = 0;

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

    //Переносимый вес
    private int carryingCapacity = 0;
    private int maxCarryingCapacity = 10;

    //Скорость
    public float speed = 2f;
    private float maxSpeed = 10f;

    //Скорость атаки
    private float attackSpeed = 0;
    private float maxAttackSpeed = 10;

    //Критический урон
    private float criticalDamage = 0;
    private float maxCriticalDamage = 10;

    //Точность
    private float precision = 0;
    private float maxPrecisionDamage = 10;





    //Сытость
    private int satiety = 0;
    private int maxSatiety = 100;

    //Опьянение
    private int drunkenness = 0;
    private int maxDrunkenness = 100;



    //Сопротивление колющему📌
    private float prickResist = 0;
    private int maxPrickResist = 100;
    private int minPrickResist = 100;

    //Сопротивление режущему🔪
    private float slashResist = 0;
    private int maxSlashResist = 100;
    private int minSlashResist = 100;

    //Сопротивление дробящему🔨
    private float crushResist = 0;
    private int maxCrushResist = 100;
    private int minCrushResist = 100;

    //Сопротивление ударному👊
    private float impactResist = 0;
    private int maxImpactResist = 100;
    private int minImpactResist = 100;

    //Сопротивление святому⛪
    private float holyResist = 0;
    private int maxHolyResist = 100;
    private int minHolyResist = -100;

    //Сопротивление ядам🍄
    private float poisonResist = 0;
    private int maxPoisonResist = 100;
    private int minPoisonResist = -100;

    //Сопротивление огню🔥
    private float fireResist = 0;
    private int maxFireResist = 100;
    private int minFireResist = -100;

    //Сопростивление морозу❄ 
    private float frostResist = 0;
    private int maxFrostResist = 100;
    private int minFrostResist = -100;

    //Сопротивление проклятию☠
    private float curseResist = 0;
    private int maxCurseResist = 100;
    private int minCurseResist = 100;

    //Сопротивление рунной магии🈶
    private float runesResist = 0;
    private int maxRunesResist = 100;
    private int minRunesResist = -100;

    //Сопротивление электричеству⛈
    private float electricalResist = 0;
    private int maxElectricalResist = 100;
    private int minElectricalResist = -100;

    //Сопротивление АлКоГоЛю🍺
    private float drunkennessResist = 0;
    private int maxDrunkennessResist = 100;
    private int minDrunkennessResist = -100;

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
        float poisonDamage = 0, 
        float fireDamage = 0, 
        float frostDamage = 0,        
        float electricalDamage = 0,
        float runeDamage = 0,
        float holyDamage = 0,
        float curseDamage = 0,
        float drunkennessDamage = 0
        )
    {
        HP -= prickDamage * (1 - prickResist / 100);
        HP -= slashDamage * (1 - slashResist / 100);
        HP -= crushDamage * (1 - crushResist / 100);
        HP -= poisonDamage * (1 - poisonResist / 100);
        HP -= fireDamage * (1 - fireResist / 100);
        HP -= frostDamage * (1 - frostResist / 100);
        HP -= electricalDamage * (1 - electricalResist / 100);
        HP -= holyDamage * (1 - holyResist / 100);
        HP -= curseDamage * (1 - curseResist / 100);
        HP -= drunkennessDamage * (1 - curseResist / 100);

        //physicalArmor -= 

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

    //Ссылаемся на эффекты из префабов

    public GameObject effectPoison;
    public GameObject effectFire;
    public GameObject effectCurse;
    public GameObject effectFrost;
    public GameObject effectDrunkenness;

    //Статус активности того ил иного статуса

    public bool statusPoison = false;
    public bool statusFire = false;
    public bool statusCurse = false;
    public bool statusFrost = false;
    public bool statusDrunkenness = false;

    //Структура кода ниже:
    //Время длительности эффекта
    //Урон от эффекта срабатываемый от интервала
    //Время ожидания получения урона

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
        Player.speed -= 1f;

        for (int i = 0; i < (timePoison / intervalPoison); timePoison -= intervalPoison)
        {
            yield return new WaitForSeconds(intervalPoison);

            Instantiate(effectPoison, this.transform.position, transform.rotation);

            TakeDamage(poisonDamage: pereodicPoisonDamage);
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
                
            TakeDamage(fireDamage: pereodicFireDamage);
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

            TakeDamage(curseDamage: pereodiCcurseDamage);
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

            TakeDamage(frostDamage: pereodicFrostDamage);
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

            TakeDamage(drunkennessDamage: pereodicDrunkennessDamage);
        }

        statusDrunkenness = false;
        Debug.Log("Я закончил");
    }



    #endregion
}







