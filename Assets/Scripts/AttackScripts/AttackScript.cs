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
        if (canAttack == true && attackCell == target.coordinate && GetComponent<MainObject>().actionPoints > 0)
        {
            canAttack = false;

            Debug.Log(attackCell);
            Debug.Log(target.coordinate);

            anim.SetTrigger("Attack");
            //Enemy.speed = 0;
            //NextAnimator.SetTrigger("OnAnimationEnded");

            if (Random.Range(0, 100) <= target.GetComponent<MainObject>().dodge)
            {
                Debug.Log($"Я {target.name} уклонился");
            }
            else
            {
                target.GetComponent<TakeDamageScript>().TakeDamage(
                prickDamage: GetComponent<MainObject>().prickDamage,
                slashDamage: GetComponent<MainObject>().slashDamage,
                crushDamage: GetComponent<MainObject>().crushDamage,
                poisonDamage: GetComponent<MainObject>().poisonDamage,
                fireDamage: GetComponent<MainObject>().fireDamage,
                frostDamage: GetComponent<MainObject>().frostDamage,
                electricalDamage: GetComponent<MainObject>().electricalDamage,
                curseDamage: GetComponent<MainObject>().curseDamage,
                drunkennessDamage: GetComponent<MainObject>().drunkennessDamage
                );

                CameraShaker.Instance.ShakeOnce(0.7f, 12f, 0.3f, 0.3f);
            }

            GetComponent<MainObject>().actionPoints -= attackCost;

            //Invoke("AttackReload", 1);

            canAttack = true;
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

        //Напрво от атакующего
        if(GetComponent<MainObject>().lineAttack == true) 
        {
            for (int i = 0; i <= distanceAttack; i++)
            {
                attackCell = new Vector3Int(GetComponent<MainObject>().coordinate.x + i, GetComponent<MainObject>().coordinate.y, 0);

                Attack(attackCell, target, attackCost);
            }

            //Налево от атакующего
            for (int i = 0; i <= distanceAttack; i++)
            {
                attackCell = new Vector3Int(GetComponent<MainObject>().coordinate.x - i, GetComponent<MainObject>().coordinate.y, 0);

                Attack(attackCell, target, attackCost);
            }

            //Вверх от атакующего
            for (int i = 0; i <= distanceAttack; i++)
            {
                attackCell = new Vector3Int(GetComponent<MainObject>().coordinate.x, GetComponent<MainObject>().coordinate.y + i, 0);

                Attack(attackCell, target, attackCost);
            }

            //Вниз от атакующего
            for (int i = 0; i <= distanceAttack; i++)
            {
                attackCell = new Vector3Int(GetComponent<MainObject>().coordinate.x, GetComponent<MainObject>().coordinate.y - i, 0);

                Attack(attackCell, target, attackCost);
            }
        }

        if(GetComponent<MainObject>().diagonalAttack == true)
        {
            //Вверх-налево
            for (int i = 0; i <= distanceAttack; i++)
            {
                attackCell = new Vector3Int(GetComponent<MainObject>().coordinate.x - i, GetComponent<MainObject>().coordinate.y + i, 0);

                Attack(attackCell, target, attackCost);
            }

            //Вверх-направо
            for (int i = 0; i <= distanceAttack; i++)
            {
                attackCell = new Vector3Int(GetComponent<MainObject>().coordinate.x + i, GetComponent<MainObject>().coordinate.y + i, 0);

                Attack(attackCell, target, attackCost);
            }

            //Вниз-налево
            for (int i = 0; i <= distanceAttack; i++)
            {
                attackCell = new Vector3Int(GetComponent<MainObject>().coordinate.x - i, GetComponent<MainObject>().coordinate.y - i, 0);

                Attack(attackCell, target, attackCost);
            }

            //Вниз-направо
            for (int i = 0; i <= distanceAttack; i++)
            {
                attackCell = new Vector3Int(GetComponent<MainObject>().coordinate.x + i, GetComponent<MainObject>().coordinate.y - i, 0);

                Attack(attackCell, target, attackCost);
            }
        }
    }
}

