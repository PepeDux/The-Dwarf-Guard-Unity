using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
    public Animator anim;
    public Animator NextAnimator;

    public Transform AttackPoint;
    public float AttackRange = 10f;
    public LayerMask PlayerLayers;

    public bool CanAttack = true;

    public int AttackDamage = 5;

    void Update()
    {
        anim = GetComponent<Animator>();
    }

    void Attack()
    {
        if(CanAttack == true) 
        {
            anim.SetTrigger("Attack");
            //Enemy.speed = 0;
            CanAttack = false;
            //NextAnimator.SetTrigger("OnAnimationEnded");

            Collider2D[] HitPlayer = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, PlayerLayers);

            foreach (Collider2D player in HitPlayer)
            {
               // player.GetComponent<Player>().TakeDamage(AttackDamage);
            }

            Invoke("AttackReload", 1);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        FindObjectOfType<Rigidbody2D>().WakeUp();
        if (other.CompareTag("Player"))
        {
            Attack();
        }
    }  

    void AttackReload()
    {
        CanAttack = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
    }
}
