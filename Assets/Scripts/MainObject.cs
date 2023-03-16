using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Security.Cryptography;
using UnityEngine.Rendering.PostProcessing;
using NaughtyAttributes;
using System;

public class MainObject : MonoBehaviour
{
    [Header("Плюшки")]
    public Rigidbody2D rb;
    public Animator anim;

    public static int random;

    public GameObject corpse;
    public GameObject[] loot;

    #region Characteristic

    private int freeCharacteristicLevel = 0;
    private int CharacteristicLevel = 0;
    private int maxCharacteristicLevel = 10;

    [Header("Первичные характеристики")]
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

    //Монетки
    public int money = 0;

    //Физическая броня
    private float physicalArmor;
    private float maxPhysicalArmor;

    //Магическая броня
    private float magicArmor;
    private float maxMagicArmor;



    [Header("Уроны")]
    //Урон наносимый объектом
    public float prickDamage = 0;
    public float slashDamage = 0;
    public float crushDamage = 0;
    public float poisonDamage = 0;
    public float fireDamage = 0;
    public float frostDamage = 0;
    public float electricalDamage = 0;
    public float curseDamage = 0;
    public float drunkennessDamage = 0;


    [Header("Уровень и опыт")]
    //Опыт
    public float XP = 0;
    private float maxXP = 100;

    //Уровень
    public int level = 0;
    private int maxLevel = 10;







    [Header("Основнык характеристики")]
    //Сила
    public int strength = 10;
    private int maxStrength = 100;

    //Ловкость
    public int agility = 10;
    private int maxAgility = 100;

    //Интеллект
    public int intel = 10;
    private int maxIntel = 100;

    //Телосложение
    public int constitution = 10;
    private int maxConstitution = 100;

    //Мудрость
    public int wisdom = 10;
    private int maxWisdom = 100;




    [Header("Вторичные характеристики")]
    //Уклонение
    public int dodge = 0;
    private const int maxDodge = 100;

    //Переносимый вес
    public int carryingCapacity = 0;
    private const int maxCarryingCapacity = 10;

    //Скорость
    public float speed = 2f;
    private const float maxSpeed = 10f;

    //Скорость атаки
    public float attackSpeed = 0;
    private const float maxAttackSpeed = 10;

    //Критический урон
    public float criticalDamage = 0;
    private const float maxCriticalDamage = 100;

    //Точность
    public float precision = 0;
    private const float maxPrecision = 100;

    //Опьянение
    public int drunkenness = 0;
    private const int maxDrunkenness = 100;



    //[Header("Сопротивления к урону")]
    //Сопротивление колющему📌
    public float prickResist = 20;
    private const int maxPrickResist = 100;
    private const int minPrickResist = -100;

    //Сопротивление режущему🔪
    public float slashResist = 0;
    private const int maxSlashResist = 100;
    private const int minSlashResist = -100;

    //Сопротивление дробящему🔨
    public float crushResist = 0;
    private const int maxCrushResist = 100;
    private const int minCrushResist = -100;

    //Сопротивление ударному👊
    public float impactResist = 0;
    private const int maxImpactResist = 100;
    private const int minImpactResist = -100;

    //Сопротивление ядам🍄
    public float poisonResist = 0;
    private const int maxPoisonResist = 100;
    private const int minPoisonResist = -100;

    //Сопротивление огню🔥
    public float fireResist = 0;
    private const int maxFireResist = 100;
    private const int minFireResist = -100;

    //Сопростивление морозу❄ 
    public float frostResist = 0;
    private const int maxFrostResist = 100;
    private const int minFrostResist = -100;

    //Сопротивление проклятию☠
    public float curseResist = 0;
    private const int maxCurseResist = 100;
    private const int minCurseResist = -100;

    //Сопротивление электричеству⛈
    public float electricalResist = 0;
    private const int maxElectricalResist = 100;
    private const int minElectricalResist = -100;

    //Сопротивление АлКоГоЛю🍺
    public float drunkennessResist = 0;
    private const int maxDrunkennessResist = 100;
    private const int minDrunkennessResist = -100;



    public void CheckCharac()
    {
        //Хепешки
        if (HP >= maxHP)
        {
            HP = maxHP;
        }

        //Энергия
        if (energy >= maxEnergy)
        {
            energy = maxEnergy;
        }

        //Опыт
        if (XP >= maxXP) 
        {
            XP = 0;
            //переход на следующий лвл
        }

        //Левел
        if (level >= maxLevel) 
        {
            level = maxLevel;
        }

        //Сила
        if (strength >= maxStrength) 
        {
            strength = maxStrength;
        }

        //Ловкость
        if (agility >= maxAgility) 
        {
            agility = maxAgility;
        }

        //Интеллект
        if (intel >= maxIntel) 
        {
            intel = maxIntel;
        }

        //Телосложение
        if (constitution >= maxConstitution) 
        { 
            constitution = maxConstitution; 
        }

        //Мудрость
        if (wisdom >= maxWisdom) 
        {
            wisdom = maxWisdom;
        }

        //Уклонение
        if (dodge >= maxDodge) 
        {
            dodge = maxDodge;
        }

        //Переносимый вес
        if (carryingCapacity >= maxCarryingCapacity) 
        {
            carryingCapacity = maxCarryingCapacity;
        }

        //Скорость
        if (speed >= maxSpeed) 
        { 
            speed = maxSpeed; 
        }

        //Скорость атаки
        if (attackSpeed >= maxAttackSpeed) 
        {
            attackSpeed = maxAttackSpeed;
        }

        //Крит урон
        if (criticalDamage >= maxCriticalDamage)
        {
            criticalDamage = maxCriticalDamage;
        }

        //Точность
        if (precision >= maxPrecision) 
        {
            precision = maxPrecision;
        }

        //Опьянение
        if (drunkenness >= maxDrunkenness)
        {
            drunkenness = maxDrunkenness;
        }

        //Сопротивление колющему урону
        if (prickResist >= maxPrickResist) 
        {
            prickResist = maxPrickResist;
        }
        else if (prickResist <= minPrickResist)
        {
            prickResist = minPrickResist;
        }

        //Сопротивление режущему
        if (slashResist >= maxSlashResist) 
        {
            slashResist = maxSlashResist;
        }
        else if (slashResist <= minSlashResist)
        {
            slashResist = minSlashResist;
        }

        //Сопротивление дробящему
        if (crushResist >= maxCrushResist) 
        {
            crushResist = maxCrushResist;
        }
        else if (crushResist <= minCrushResist)
        {
            crushResist = minCrushResist;
        }

        //Сопротивление ядам
        if (poisonResist >= maxPoisonResist) 
        {
            poisonResist = maxPoisonResist;
        }
        else if (poisonResist <= minPoisonResist)
        {
            poisonResist = minPoisonResist;
        }

        //Сопротивление огню
        if (fireResist >= maxFireResist)
        {
            fireResist = maxFireResist;
        }
        else if (fireResist <= minFireResist) 
        {
            fireResist = minFireResist;
        }

        //Сопротивление морозу
        if (frostResist >= maxFrostResist)
        {
            frostResist = maxFrostResist;
        }
        else if (frostResist <= minFrostResist)
        {
            frostResist = minFrostResist;
        }

        //Сопротивление проклятию
        if (curseResist >= maxCurseResist)
        {
            curseResist = maxCurseResist;
        }
        else if (curseResist <= minCurseResist)
        {
            curseResist = minCurseResist;
        }

        //Сопротивление электтричеству
        if (electricalResist >= maxElectricalResist)
        {
            electricalResist = maxElectricalResist;
        }
        else if (electricalResist <= minElectricalResist)
        {
            electricalResist = minElectricalResist;
        }

        //Сопротивление опьянению
        if (drunkennessResist >= maxDrunkennessResist)
        {
            drunkennessResist = maxDrunkennessResist;
        }
        if (drunkennessResist <= minDrunkennessResist)
        {
            drunkenness = minDrunkennessResist;
        }

    }


    #endregion

    #region Таланты/Перки

    //1 переменная отвечает за активность статуса
    //2 переменная отвечает за свободность статуса
    //Чтобы при запуске метода повторно не сработал кусок кода свзанный с этим эффектом и нужна 2 переменные
    //Типо буфер

    private bool wound = false;
    private bool checkWound = true;
    

    public void RandomWound()
    {
        int random = Random.Range(10, 50);        
    }
    public void CheckTalents()
    {
        if(wound && checkWound)
        {
            maxHP -= 10;

            checkWound = false;
        }
        else if(!wound && !checkWound)
        {
            maxHP += 10;

            checkWound = true;
        }       
    }






    #endregion

    #region Смэрт и получение урона

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
        HP -= curseDamage * (1 - curseResist / 100);
        HP -= drunkennessDamage * (1 - curseResist / 100);

        anim.SetTrigger("TakeDamage");

        wound = true;

        if (HP <= 0)
        {
            Die();
        }
    }


    

    public void Die()
    {
        Debug.Log($"Я {this.name} умер");

        //loot = UnityEngine.Random.Range(0, loot.Length);

        //Instantiate(loot[random], transform.position, transform.rotation);

        //Instantiate(corpse, transform.position, transform.rotation);

        anim.SetTrigger("Die");

        gameObject.SetActive(false);
    }

    public void Kill()
    {
        HP = -1000;
    }//Метод для отладки

    #endregion

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
        speed -= 1f;

        for (int i = 0; i < (timePoison / intervalPoison); timePoison -= intervalPoison)
        {
            yield return new WaitForSeconds(intervalPoison);

            Instantiate(effectPoison, this.transform.position, transform.rotation);

            TakeDamage(poisonDamage: pereodicPoisonDamage);
        }

        speed += 1f;

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

    public void Updater()
    {
        CheckCharac();
        CheckTalents();

        rb.WakeUp();
    }

}