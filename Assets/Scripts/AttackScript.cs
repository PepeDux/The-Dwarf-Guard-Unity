using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public Animator anim;
    public Animator NextAnimator;

    public Transform AttackPoint;
    public float AttackRange = 10f;
    public LayerMask EnemyLayers;

    public bool CanAttack = true;

    public int AttackDamage = 5; 

    void FixedUpdate()
    {
        anim = GetComponent<Animator>();
        Attack();     
    }

    void Attack()
    {
        if (Player.energy >= Player.energyWaste && Input.GetMouseButtonDown(0) && CanAttack == true)
        {
           
            anim.SetTrigger("Attack");
            Player.speed = 0;
            Player.energy -= 10;
            CanAttack = false;
            NextAnimator.SetTrigger("OnAnimationEnded");

            Collider2D[] HitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, EnemyLayers);

            foreach(Collider2D enemy in HitEnemies)
            {
                enemy.GetComponent<Enemy>().TakeDamage(AttackDamage);
            }

            Invoke("AttackReload", 1);
        }

    }

    void AttackReload()
    {
        CanAttack = true;
    }

    public void AttackToogle()
    {
        Debug.Log("WORK");
        Player.speed = 2;   
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere (AttackPoint.position, AttackRange);
    }

}

