using EZCameraShake;
using Newtonsoft.Json.Bson;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Threading;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class AttackScript : MonoBehaviour
{
    public Animator anim;

    private bool canAttack = true;

    private Vector3Int attackCell;
    private MainObject target;
    private int attackCost;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }


    public void CalculationAttack(MainObject target)
    {
        this.target = target;

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

        this.attackCost = attackCost;

        if (GetComponent<MainObject>().lineAttack == true)
        {
            //Напрво от атакующего
            for (int i = 0; i <= distanceAttack; i++)
            {
                attackCell = new Vector3Int(GetComponent<MainObject>().coordinate.x + i, GetComponent<MainObject>().coordinate.y, 0);

                Attack(attackCell, target, attackCost, "HorizontalAttack");
            }

            //Налево от атакующего
            for (int i = 0; i <= distanceAttack; i++)
            {
                attackCell = new Vector3Int(GetComponent<MainObject>().coordinate.x - i, GetComponent<MainObject>().coordinate.y, 0);

                Attack(attackCell, target, attackCost, "HorizontalAttack");
            }

            //Вверх от атакующего
            for (int i = 0; i <= distanceAttack; i++)
            {
                attackCell = new Vector3Int(GetComponent<MainObject>().coordinate.x, GetComponent<MainObject>().coordinate.y + i, 0);

                Attack(attackCell, target, attackCost, "UpAttack");
            }

            //Вниз от атакующего
            for (int i = 0; i <= distanceAttack; i++)
            {
                attackCell = new Vector3Int(GetComponent<MainObject>().coordinate.x, GetComponent<MainObject>().coordinate.y - i, 0);

                Attack(attackCell, target, attackCost, "DownAttack");
            }
        }

        if (GetComponent<MainObject>().diagonalAttack == true)
        {
            //Вверх-налево
            for (int i = 0; i <= distanceAttack; i++)
            {
                attackCell = new Vector3Int(GetComponent<MainObject>().coordinate.x - i, GetComponent<MainObject>().coordinate.y + i, 0);

                //Attack(attackCell, target, attackCost);
            }

            //Вверх-направо
            for (int i = 0; i <= distanceAttack; i++)
            {
                attackCell = new Vector3Int(GetComponent<MainObject>().coordinate.x + i, GetComponent<MainObject>().coordinate.y + i, 0);

                //Attack(attackCell, target, attackCost);
            }

            //Вниз-налево
            for (int i = 0; i <= distanceAttack; i++)
            {
                attackCell = new Vector3Int(GetComponent<MainObject>().coordinate.x - i, GetComponent<MainObject>().coordinate.y - i, 0);

                //Attack(attackCell, target, attackCost);
            }

            //Вниз-направо
            for (int i = 0; i <= distanceAttack; i++)
            {
                attackCell = new Vector3Int(GetComponent<MainObject>().coordinate.x + i, GetComponent<MainObject>().coordinate.y - i, 0);

                //Attack(attackCell, target, attackCost);
            }
        }
    }

    public void Attack(Vector3Int attackCell, MainObject target, int attackCost, string sideAttack)
    { 
        if (canAttack == true && attackCell == target.coordinate && target != null && GetComponent<MainObject>().actionPoints > 0)
        {
            canAttack = false;



            if(sideAttack == "HorizontalAttack")
            {
                anim.SetTrigger("HorizontalAttack");
            }
            else if(sideAttack == "UpAttack")
            {
                anim.SetTrigger("UpAttack");
            }
            else if (sideAttack == "DownAttack")
            {
                anim.SetTrigger("DownAttack");
            }

            Invoke("AttackReload", 1);
        }
    }


    private void AttackReload()
    {
        canAttack = true;
    }

    private void GiveAttack()
    {

        if (UnityEngine.Random.Range(0, 100) <= this.target.GetComponent<MainObject>().dodge)
        {
            Debug.Log($"Я {this.target.name} уклонился");
        }
        else
        {
            this.target.GetComponent<TakeDamageScript>().TakeDamage(
            physicalDamage: GetComponent<MainObject>().physicalDamage,
            poisonDamage: GetComponent<MainObject>().poisonDamage,
            fireDamage: GetComponent<MainObject>().fireDamage,
            frostDamage: GetComponent<MainObject>().frostDamage,
            drunkennessDamage: GetComponent<MainObject>().drunkennessDamage
            );
        }

        GetComponent<MainObject>().actionPoints -= this.attackCost;
    }
}

