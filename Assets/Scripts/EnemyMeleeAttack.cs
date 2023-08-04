using EZCameraShake;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
    public Animator anim;
    public Animator NextAnimator;

    public GameObject player;

    private bool CanAttack = true;


    private void Start()
    {
        player = GameObject.Find("Dwarf Guard"); //Использует Find вместо GetComponent из-за того, что GetComponent отказывается работать в этом месте
        anim = GetComponent<Animator>();
    }

    public void Attack(Vector3Int attackCell)
    {
        if (CanAttack == true && attackCell == player.GetComponent<Player>().coordinate && GetComponent<Enemy>().actionPoints > 0)
        {
            anim.SetTrigger("Attack");
            //Enemy.speed = 0;
            CanAttack = false;
            //NextAnimator.SetTrigger("OnAnimationEnded");


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

                CameraShaker.Instance.ShakeOnce(0.7f, 12f, 0.3f, 0.3f);
            }

            GetComponent<Enemy>().actionPoints -= 1;
        }

        Invoke("AttackReload", 1);

    }

 

    void AttackReload()
    {
        CanAttack = true;
    }
}
