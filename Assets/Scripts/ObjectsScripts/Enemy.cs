using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MainObject
{
    private bool isFacingRight = true;

    [Header("Игрок")]
    public GameObject player;



    public void FixedUpdate() 
    {
        Updater();
        MoveOrientation();
    }

    private void Start()
    {
        Starter();
        player = GameObject.Find("Dwarf Guard");
    }

    void MoveOrientation()
    {
        if(player != null)
        {
            if (player.transform.position.x < transform.position.x && isFacingRight == true)
            {
                Flip();
            }
            else if (player.transform.position.x > transform.position.x && isFacingRight == false)
            {
                Flip();
            }
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
