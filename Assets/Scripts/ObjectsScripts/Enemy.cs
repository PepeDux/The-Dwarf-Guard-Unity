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

    public GameObject tileManager;


    private void OnEnable()
    {
        //������������� �� ������� ����� ���� ������ 
        LevelManager.LevelEnded += Destroy;
        PlayerTurnManager.playerTurnFinished += Turn;
    }

    private void OnDisable()
    {
        //������������ �� ������� ����� ���� ������ 
        LevelManager.LevelEnded -= Destroy;
        PlayerTurnManager.playerTurnFinished -= Turn;
    }

    public void FixedUpdate() 
    {
        Updater();
        MoveOrientation();
    }

    private void Start()
    {
        Starter();
        player = GameObject.Find("Dwarf Guard(Clone)");
        tileManager = GameObject.Find("TileManager");
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



    public void EnemyMove()
    {
        List<Vector3Int> pathToTarget = GetComponent<EnemyTileManager>().pathToTarget;

        if (movePoint >= moveCost && player != null)
        {
            pathToTarget.Clear();
            pathToTarget = GetComponent<EnemyTileManager>().GetPath(player.GetComponent<Player>().coordinate);

            if (pathToTarget.Count > 1)
            {
                pathToTarget.RemoveAt(0);
                coordinate = pathToTarget[pathToTarget.Count - 1];
                UpdateCoordinate();
                movePoint -= moveCost;
            }
        }
    }

    public void Turn()
    {
        while(movePoint >= moveCost)
        {
            tileManager.GetComponent<TileManager>().TileGameObjectUpdatePosition();

            int startPoints = movePoint;

            EnemyMove();

            if(startPoints == movePoint)
            {
                break;
            }
        }

        while (actionPoints >= meleeAttackCost || actionPoints >= rangeAttackCost && player != null)
        {
            int startPoints = actionPoints;

            GetComponent<AttackScript>().CalculationAttack(player.GetComponent<MainObject>());

            if (startPoints == actionPoints)
            {
                break;
            }
        }
    }
}
