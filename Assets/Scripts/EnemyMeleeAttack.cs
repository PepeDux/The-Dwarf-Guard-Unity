using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
    public Animator anim;
    public Animator NextAnimator;

    public Transform AttackPoint;
    public float AttackRange = 10f;
    public LayerMask PlayerLayers;

    public bool CanAttack = true;


    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Attack()
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
                if (Random.Range(0, 100) <= player.GetComponent<Player>().dodge) 
                {
                    Debug.Log($"Я {player.name} уклонился");
                }
                else 
                {
                    player.GetComponent<TakeDamageScript>().TakeDamage(
                    prickDamage: GetComponent<Enemy>().prickDamage,
                    slashDamage: GetComponent<Enemy>().slashDamage,
                    crushDamage: GetComponent<Enemy>().crushDamage,
                    poisonDamage: GetComponent<Enemy>().poisonDamage,
                    fireDamage: GetComponent<Enemy>().fireDamage,
                    frostDamage: GetComponent<Enemy>().frostDamage,
                    electricalDamage: GetComponent<Enemy>().electricalDamage,
                    curseDamage: GetComponent<Enemy>().curseDamage,
                    drunkennessDamage: GetComponent<Enemy>().drunkennessDamage
                    );
                }
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
