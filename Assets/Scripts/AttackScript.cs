using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class AttackScript : MonoBehaviour
{
    public Animator anim;
    public Animator NextAnimator;

    public Transform AttackPoint;
    public float AttackRange = 10f;
    public LayerMask EnemyLayers;

    public float bufSpeed;

    public bool CanAttack = true;


    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {     
        Attack();     
    }

    void Attack()
    {
        if (GetComponent<Player>().energy >= GetComponent<Player>().energyWaste && Input.GetMouseButtonDown(0) && CanAttack == true)
        {     
            bufSpeed = GetComponent<Player>().speedBonus;    //Записываем изначальную скорость персонажа в буфер
            GetComponent<Player>().speedBonus -= GetComponent<Player>().speed;         //Останавлиаем персонажа

            anim.SetTrigger("Attack");  //Воспроизводим анимацию атаки
            GetComponent<Player>().energy -= GetComponent<Player>().energyWaste; // Отнимаем расход энергии от энергии персонажа 
            CanAttack = false;
            NextAnimator.SetTrigger("OnAnimationEnded"); //Вызываем метод AttackToogle()

            Collider2D[] HitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, EnemyLayers);

            foreach (Collider2D enemy in HitEnemies) 
            {
                if (Random.Range(0, 100) <= enemy.GetComponent<Enemy>().dodge) 
                {
                    Debug.Log($"Я {enemy.name} уклонился");
                }
                else
                {
                    enemy.GetComponent<TakeDamageScript>().TakeDamage(
                    prickDamage: GetComponent<Player>().prickDamage,
                    slashDamage: GetComponent<Player>().slashDamage,
                    crushDamage: GetComponent<Player>().crushDamage,
                    poisonDamage: GetComponent<Player>().poisonDamage,
                    fireDamage: GetComponent<Player>().fireDamage,
                    frostDamage: GetComponent<Player>().frostDamage,
                    electricalDamage: GetComponent<Player>().electricalDamage,
                    curseDamage: GetComponent<Player>().curseDamage,
                    drunkennessDamage: GetComponent<Player>().drunkennessDamage
                    );
                }
            }

            Invoke("AttackReload", 1);
        }
    }
    public void AttackToogle()
    {
        Debug.Log("WORK");
        GetComponent<Player>().speedBonus = bufSpeed;   //Востанавливаем скорость персонажа
    }
    void AttackReload()
    {
        CanAttack = true;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere (AttackPoint.position, AttackRange);
    }

}

