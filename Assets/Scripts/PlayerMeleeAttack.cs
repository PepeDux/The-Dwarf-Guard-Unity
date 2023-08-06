using EZCameraShake;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerAttackScript : MonoBehaviour
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

    private void Update()
    {
        Attack();
    }

    void Attack()
    {
        if(Input.GetMouseButtonDown(0) && CanAttack == true && GetComponent<Player>().actionPoints >= 1)
        {
            foreach(var enemy in TileManager.enemyList)
            {
                if(enemy.GetComponent<Enemy>().coordinate == TileManager.CellPosition)
                {
                    anim.SetTrigger("Attack");  //Воспроизводим анимацию атаки
                    GetComponent<Player>().actionPoints -= 1; // Отнимаем расход энергии от энергии персонажа 
                    CanAttack = false;
                    NextAnimator.SetTrigger("OnAnimationEnded"); //Вызываем метод AttackToogle()



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

                    Invoke("AttackReload", 1);
                }              
            }
        }

        
     


           

           
        
    }
    public void AttackToogle()
    {
        CameraShaker.Instance.ShakeOnce(0.7f, 12f, 0.3f, 0.3f);
        Debug.Log("WORK");
    }
    void AttackReload()
    {
        CanAttack = true;
    }

    void WeaponChange()
    {
        if (Input.GetKeyDown("1") || Input.GetKeyDown("2")) 
        {
            if (GetComponent<Player>().currentWeapon == GetComponent<Player>().firstWeapon) 
            {
                GetComponent<Player>().currentWeapon = GetComponent<Player>().secondWeapon; //Текущее оружее игрока = второму
                if (GetComponent<Player>().currentWeapon != null)
                {
                    GetComponent<WeaponCalculation>().currentWeapon = GetComponent<Player>().secondWeapon.name; //Передает скрипту для расчета характеристик оружия текущее оружее, для добавления характеристик
                    GetComponent<WeaponCalculation>().lastWeapon = GetComponent<Player>().firstWeapon.name; //Убирает характеристики предыдущего оружия
                }
                
            }
            else if (GetComponent<Player>().currentWeapon == GetComponent<Player>().secondWeapon)
            {
                GetComponent<Player>().currentWeapon = GetComponent<Player>().firstWeapon; //Текущее оружее игрока = второму  
                if (GetComponent<Player>().currentWeapon != null)
                {
                    GetComponent<WeaponCalculation>().currentWeapon = GetComponent<Player>().firstWeapon.name; //Передает скрипту для расчета характеристик оружия текущее оружее, для добавления характеристик
                    GetComponent<WeaponCalculation>().lastWeapon = GetComponent<Player>().secondWeapon.name; //Убирает характеристики предыдущего оружия
                }
                    
            }   
        }
    }
}

