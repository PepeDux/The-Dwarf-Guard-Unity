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
                    anim.SetTrigger("Attack");  //������������� �������� �����
                    GetComponent<Player>().actionPoints -= 1; // �������� ������ ������� �� ������� ��������� 
                    CanAttack = false;
                    NextAnimator.SetTrigger("OnAnimationEnded"); //�������� ����� AttackToogle()



                    if (Random.Range(0, 100) <= enemy.GetComponent<Enemy>().dodge)
                    {
                        Debug.Log($"� {enemy.name} ���������");
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
                GetComponent<Player>().currentWeapon = GetComponent<Player>().secondWeapon; //������� ������ ������ = �������
                if (GetComponent<Player>().currentWeapon != null)
                {
                    GetComponent<WeaponCalculation>().currentWeapon = GetComponent<Player>().secondWeapon.name; //�������� ������� ��� ������� ������������� ������ ������� ������, ��� ���������� �������������
                    GetComponent<WeaponCalculation>().lastWeapon = GetComponent<Player>().firstWeapon.name; //������� �������������� ����������� ������
                }
                
            }
            else if (GetComponent<Player>().currentWeapon == GetComponent<Player>().secondWeapon)
            {
                GetComponent<Player>().currentWeapon = GetComponent<Player>().firstWeapon; //������� ������ ������ = �������  
                if (GetComponent<Player>().currentWeapon != null)
                {
                    GetComponent<WeaponCalculation>().currentWeapon = GetComponent<Player>().firstWeapon.name; //�������� ������� ��� ������� ������������� ������ ������� ������, ��� ���������� �������������
                    GetComponent<WeaponCalculation>().lastWeapon = GetComponent<Player>().secondWeapon.name; //������� �������������� ����������� ������
                }
                    
            }   
        }
    }
}

