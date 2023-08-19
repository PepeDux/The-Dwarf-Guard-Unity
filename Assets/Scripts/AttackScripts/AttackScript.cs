using EZCameraShake;
using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Threading;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class AttackScript : MonoBehaviour
{
    public Animator anim;
    public Animator NextAnimator;

    private bool canAttack = true;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }


    public void Attack(Vector3Int attackCell, MainObject target, int attackCost)
    { 
        if (canAttack == true && attackCell == target.coordinate && target != null && GetComponent<MainObject>().actionPoints > 0)
        {
            canAttack = false;

            anim.SetTrigger("Attack");
            //Enemy.speed = 0;
            //NextAnimator.SetTrigger("OnAnimationEnded");

            if (Random.Range(0, 100) <= target.GetComponent<MainObject>().dodge)
            {
                Debug.Log($"� {target.name} ���������");
            }
            else
            {
                target.GetComponent<TakeDamageScript>().TakeDamage(
                physicalDamage: GetComponent<MainObject>().physicalDamage,
                poisonDamage: GetComponent<MainObject>().poisonDamage,
                fireDamage: GetComponent<MainObject>().fireDamage,
                frostDamage: GetComponent<MainObject>().frostDamage,
                drunkennessDamage: GetComponent<MainObject>().drunkennessDamage
                );
            }

            GetComponent<MainObject>().actionPoints -= attackCost;

            Invoke("AttackReload", 1);
        }
    }

    void AttackReload()
    {
        canAttack = true;
    }

    public void CalculationAttack(MainObject target)
    {
        if (GetComponent<MainObject>().melee == true)
        {
            FindTarget(MainObject.meleeAttackDistance, target, GetComponent<MainObject>().meleeAttackCost);
        }

        if (GetComponent<MainObject>().range == true)
        {
            FindTarget(TileManager.xField, target, GetComponent<MainObject>().rangeAttackCost);
        }
    }

    public void FindTarget(int distanceAttack, MainObject target, int attackCost)
    {
        Vector3Int attackCell = new Vector3Int();

        
        if(GetComponent<MainObject>().lineAttack == true) 
        {
            //������ �� ����������
            for (int i = 0; i <= distanceAttack; i++)
            {
                attackCell = new Vector3Int(GetComponent<MainObject>().coordinate.x + i, GetComponent<MainObject>().coordinate.y, 0);

                Attack(attackCell, target, attackCost);
            }

            //������ �� ����������
            for (int i = 0; i <= distanceAttack; i++)
            {
                attackCell = new Vector3Int(GetComponent<MainObject>().coordinate.x - i, GetComponent<MainObject>().coordinate.y, 0);

                Attack(attackCell, target, attackCost);
            }

            //����� �� ����������
            for (int i = 0; i <= distanceAttack; i++)
            {
                attackCell = new Vector3Int(GetComponent<MainObject>().coordinate.x, GetComponent<MainObject>().coordinate.y + i, 0);

                Attack(attackCell, target, attackCost);
            }

            //���� �� ����������
            for (int i = 0; i <= distanceAttack; i++)
            {
                attackCell = new Vector3Int(GetComponent<MainObject>().coordinate.x, GetComponent<MainObject>().coordinate.y - i, 0);

                Attack(attackCell, target, attackCost);
            }
        }

        if(GetComponent<MainObject>().diagonalAttack == true)
        {
            //�����-������
            for (int i = 0; i <= distanceAttack; i++)
            {
                attackCell = new Vector3Int(GetComponent<MainObject>().coordinate.x - i, GetComponent<MainObject>().coordinate.y + i, 0);

                Attack(attackCell, target, attackCost);
            }

            //�����-�������
            for (int i = 0; i <= distanceAttack; i++)
            {
                attackCell = new Vector3Int(GetComponent<MainObject>().coordinate.x + i, GetComponent<MainObject>().coordinate.y + i, 0);

                Attack(attackCell, target, attackCost);
            }

            //����-������
            for (int i = 0; i <= distanceAttack; i++)
            {
                attackCell = new Vector3Int(GetComponent<MainObject>().coordinate.x - i, GetComponent<MainObject>().coordinate.y - i, 0);

                Attack(attackCell, target, attackCost);
            }

            //����-�������
            for (int i = 0; i <= distanceAttack; i++)
            {
                attackCell = new Vector3Int(GetComponent<MainObject>().coordinate.x + i, GetComponent<MainObject>().coordinate.y - i, 0);

                Attack(attackCell, target, attackCost);
            }
        }
    }
}

