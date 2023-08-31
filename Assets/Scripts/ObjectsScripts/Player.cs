using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SocialPlatforms;

public class Player : MainObject
{
    public static Action<Player> playerSpawned;

    private bool isFacingRight = true;


    private void Start()
    {
        playerSpawned?.Invoke(this);
        Starter();
    }
    private void Update()
    {
        Updater();
        MoveOrientation(); //�������� �� ������������ ��������� � ��� �����������
    }

    void MoveOrientation()
    {
        if (TileManager.WorldPosition.x < GetComponent<Player>().transform.position.x && isFacingRight == true)
        {
            Flip();
        }
        else if (TileManager.WorldPosition.x > GetComponent<Player>().transform.position.x && isFacingRight == false)
        {
            Flip();
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

