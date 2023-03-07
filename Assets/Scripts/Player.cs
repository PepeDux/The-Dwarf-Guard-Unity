using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SocialPlatforms;

public class Player : MainObject
{
    public static new float HP = 100;
    public static new float maxHP = 100;
    public static new int HPCharac = 1;
    public static new int maxHPCharac = 10;


    //Энергия
    public static new float energy = 0;
    public static new float maxEnergy = 30;
    public static new float energyWaste = 10;
    public static new int energyCharac = 1;
    public static new int maxEnergyCharac = 10;

    public static new float speed = 2f;

    public static new int money;








    //Сопротивление огню
    public static new float fireResist = 0;
    public static new int maxFireResist = 10;
    public static new int fireResistCharac = 0;
    public static new int maxFireResistCharac = 10;

    //Сопротивление ядам
    public static new float poisonResist = 0;
    public static new int maxPoisonResist = 100;
    public static new int poisonResistCharac = 0;
    public static new int maxPoisonResistCharac = 10;

    //Сопростивление морозу
    public static new float frostResist = 0;
    public static new int maxFrostResist = 10;
    public static new int frostResistCharac = 0;
    public static new int maxFrostResistCharac = 10;

    //Сопротивление проклятию
    public static new float curseResist = 0;
    public static new int maxCurseResist = 10;
    public static new int curseResistCharac = 0;
    public static new int maxCurseResistCharac = 10;

    //Сопротивление рунной магии
    public static new float runesResist = 0;
    public static new int maxRunesResist = 10;
    public static new int runesResistCharac = 0;
    public static new int maxRunesResistCharac = 10;






    #region Skills
    //Параметры опыта и уровня
    public static int freeSkillsLevel = 0;
    public static int skillLevel = 0;
    public static int maxSkillLevel = 10;


    //Торговля
    public static int trade = 0;
    public static int maxTradeResist = 10;
    public static int tradeCharac = 0;
    public static int maxTradeCharac = 10;

    //Благосклонность духа
    public static int spiritFavor = 0;
    public static int maxSpiritFavor = 10;
    public static int spiritFavorCharac = 0;
    public static int maxSpiritFavorCharac = 10;

    //Вера в духа
    public static int spiritFaith = 0;
    public static int maxSpiritFaith = 10;
    public static int spiritFaithCharac = 0;
    public static int maxSpiritFaithCharac = 10;

    //Удача
    public static int luck = 0;
    public static int maxLuck = 10;
    public static int luckCharac = 0;
    public static int maxLuckCharac = 10;

    //Медицина
    public static int medicine = 0;
    public static int maxMedicine = 10;
    public static int medicineCharac = 0;
    public static int maxMedicineCharac = 10;

    //Ремесленничество
    public static int handicraft = 0;
    public static int maxHandicraft = 10;
    public static int handicraftCharac = 0;
    public static int maxHandicraftCharac = 10;

    #endregion

 

    public Rigidbody2D rb;   
    private Vector2 moveVolecity;

   
    private bool isFacingRight = true;
    private Animator anim;


    void Start()
    {
        HP = maxHP;
        energy = maxEnergy;

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        MoveOrientation(); //Отвечает за передвижение персонажа и его направление
       // Check();           //Отвечает за обновление всех характеристик персонажа

       // Debug.Log(Player.maxHP + "   " + Player.HP);
    }

    

    public void TakeDamage(int damage)
    {
        HP -= damage;

        if (damage > 0)
        {
            
        }
              
        if (HP <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("I die");

        this.anim.enabled = false;
        this.enabled = false;
    }

    private void Update()
    {
        if(HP >= maxHP)
        {
            HP = maxHP;
        }

        if(energy >= maxEnergy)
        {
            energy = maxEnergy;
        }

        if(energy <= 0)
        {
            print("Енергии нема");
            energy = 0;
        }

    }

    void MoveOrientation()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVolecity = moveInput.normalized * speed;
        rb.MovePosition(rb.position + moveVolecity * Time.fixedDeltaTime);


        float movex = Input.GetAxis("Horizontal");
        anim.SetFloat("SpeedX", Mathf.Abs(movex));

        float movey = Input.GetAxis("Vertical");
        anim.SetFloat("SpeedY", Mathf.Abs(movey));

        if (movex > 0 && !isFacingRight)
        {
            Flip();
        }

        else if (movex < 0 && isFacingRight)
        {
            Flip();
        }

        if (Input.mousePosition.x < 900f && isFacingRight)
        {
            Flip();
        }

        else if (Input.mousePosition.x > 950 && !isFacingRight)
        {
            Flip();
        }

        //////

       




    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        //получаем размеры персонажа
        Vector3 theScale = transform.localScale;
        //зеркально отражаем персонажа по оси Х
        theScale.x *= -1;
        //задаем новый размер персонажа, равный старому, но зеркально отраженный
        transform.localScale = theScale;
    }

}

