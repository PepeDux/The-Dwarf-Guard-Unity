using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SocialPlatforms;

public class Player : MainObject
{
    //public static new float HP = 100;
    //public static new float maxHP = 100;
    public static new int HPCharac = 1;
    public static new int maxHPCharac = 10;


    //Энергия
    //public static new float energy = 0;
    //public static new float maxEnergy = 30;
    public static new float energyWaste = 10;
    public static new int energyCharac = 1;
    public static new int maxEnergyCharac = 10;

    public static new float speed = 2f;

    public static new int money;

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

