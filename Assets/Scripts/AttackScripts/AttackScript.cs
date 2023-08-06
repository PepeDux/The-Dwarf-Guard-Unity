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


    public void Attack(Vector3Int attackCell, MainObject target)
    { 
        if (canAttack == true && attackCell == target.coordinate && GetComponent<MainObject>().actionPoints > 0)
        {
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

            GetComponent<MainObject>().actionPoints -= 1;
        }
    }



    public void CalculationAttack(MainObject target)
    {
        if (GetComponent<MainObject>().melee == true)
        {
            FindTarget(1, target);
        }

        if (GetComponent<MainObject>().range == true)
        {
            FindTarget(TileManager.xField, target);
        }
    }

    public void FindTarget(int distanceAttack, MainObject target)
    {
        Vector3Int attackCell = new Vector3Int();

        //Напрво от атакующего
        if(GetComponent<MainObject>().lineAttack == true) 
        {
            for (int i = 0; i <= distanceAttack; i++)
            {
                attackCell = new Vector3Int(GetComponent<MainObject>().coordinate.x + i, GetComponent<MainObject>().coordinate.y, 0);

                Attack(attackCell, target);
            }

            //Налево от атакующего
            for (int i = 0; i <= distanceAttack; i++)
            {
                attackCell = new Vector3Int(GetComponent<MainObject>().coordinate.x - i, GetComponent<MainObject>().coordinate.y, 0);

                Attack(attackCell, target);
            }

            //Вверх от атакующего
            for (int i = 0; i <= distanceAttack; i++)
            {
                attackCell = new Vector3Int(GetComponent<MainObject>().coordinate.x, GetComponent<MainObject>().coordinate.y + i, 0);

                Attack(attackCell, target);
            }

            //Вниз от атакующего
            for (int i = 0; i <= distanceAttack; i++)
            {
                attackCell = new Vector3Int(GetComponent<MainObject>().coordinate.x, GetComponent<MainObject>().coordinate.y - i, 0);

                Attack(attackCell, target);
            }
        }

        if(GetComponent<MainObject>().diagonalAttack == true)
        {
            //Вверх-налево
            for (int i = 0; i <= distanceAttack; i++)
            {
                attackCell = new Vector3Int(GetComponent<MainObject>().coordinate.x - i, GetComponent<MainObject>().coordinate.y + i, 0);

                Attack(attackCell, target);
            }

            //Вверх-направо
            for (int i = 0; i <= distanceAttack; i++)
            {
                attackCell = new Vector3Int(GetComponent<MainObject>().coordinate.x + i, GetComponent<MainObject>().coordinate.y + i, 0);

                Attack(attackCell, target);
            }

            //Вниз-налево
            for (int i = 0; i <= distanceAttack; i++)
            {
                attackCell = new Vector3Int(GetComponent<MainObject>().coordinate.x - i, GetComponent<MainObject>().coordinate.y - i, 0);

                Attack(attackCell, target);
            }

            //Вниз-направо
            for (int i = 0; i <= distanceAttack; i++)
            {
                attackCell = new Vector3Int(GetComponent<MainObject>().coordinate.x + i, GetComponent<MainObject>().coordinate.y - i, 0);

                Attack(attackCell, target);
            }
        }
       


    }
}

