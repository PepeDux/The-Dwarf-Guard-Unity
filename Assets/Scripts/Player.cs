using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SocialPlatforms;

public class Player : MainObject
{    
    private Vector2 moveVolecity;
 
    private bool isFacingRight = true;

    void Start()
    {
        HP = maxHP;
        energy = maxEnergy;

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        Debug.Log(prickDamageWeapon);
    }

    public void FixedUpdate()
    {
        Updater();
        MoveOrientation(); //Отвечает за передвижение персонажа и его направление
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

