using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MainObject
{
    private bool isFacingRight = true;

    [Header("�����")]
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
        //�������� ������� ���������
        Vector3 theScale = transform.localScale;
        //��������� �������� ��������� �� ��� �
        theScale.x *= -1;
        //������ ����� ������ ���������, ������ �������, �� ��������� ����������
        transform.localScale = theScale;
    }
}
