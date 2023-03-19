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

    public int AttackDamage;



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
            bufSpeed = GetComponent<Player>().speed;    //Записываем изначальную скорость персонажа в буфер
            GetComponent<Player>().speed = 0f;         //Останавлиаем персонажа

            anim.SetTrigger("Attack");  //Воспроизводим анимацию атаки
            GetComponent<Player>().energy -= GetComponent<Player>().energyWaste; // Отнимаем расход энергии от энергии персонажа 
            CanAttack = false;
            NextAnimator.SetTrigger("OnAnimationEnded"); //Вызываем метод AttackToogle()

            Collider2D[] HitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, EnemyLayers);

            foreach(Collider2D enemy in HitEnemies)
            {
                if(Random.Range(0, 100) <= enemy.GetComponent<Enemy>().dodge)
                {
                    Debug.Log($"Я {enemy.name} уклонился");
                }
                else
                {
                    enemy.GetComponent<TakeDamageScript>().TakeDamage(
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

    void AttackReload()
    {
        CanAttack = true;
    }

    public void AttackToogle()
    {
        Debug.Log("WORK");
        GetComponent<Player>().speed = bufSpeed;   //Востанавливаем скорость персонажа
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere (AttackPoint.position, AttackRange);
    }

}

