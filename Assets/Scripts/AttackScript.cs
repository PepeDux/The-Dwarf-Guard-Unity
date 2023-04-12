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

        GetComponent<WeaponCalculation>().currentWeapon = GetComponent<Player>().currentWeapon.name;
    }
    void FixedUpdate()
    {
        Attack();
        WeaponChange();
    }

    void Attack()
    {
        if (GetComponent<Player>().energy >= GetComponent<Player>().energyWaste && Input.GetMouseButtonDown(0) && CanAttack == true)
        {
            bufSpeed = GetComponent<Player>().speedBonus;    //���������� ����������� �������� ��������� � �����
            GetComponent<Player>().speedBonus -= GetComponent<Player>().speed;         //������������ ���������

            anim.SetTrigger("Attack");  //������������� �������� �����
            GetComponent<Player>().energy -= GetComponent<Player>().energyWaste; // �������� ������ ������� �� ������� ��������� 
            CanAttack = false;
            NextAnimator.SetTrigger("OnAnimationEnded"); //�������� ����� AttackToogle()

            Collider2D[] HitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, EnemyLayers);

            foreach (Collider2D enemy in HitEnemies)
            {
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
            }

            Invoke("AttackReload", 1);
        }
    }
    public void AttackToogle()
    {
        Debug.Log("WORK");
        GetComponent<Player>().speedBonus = bufSpeed;   //�������������� �������� ���������
    }
    void AttackReload()
    {
        CanAttack = true;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
    }

    void WeaponChange()
    {
        if (Input.GetKeyDown("1") || Input.GetKeyDown("2")) 
        {
            if (GetComponent<Player>().currentWeapon == GetComponent<Player>().firstWeapon) 
            {
                GetComponent<Player>().currentWeapon = GetComponent<Player>().secondWeapon; //������� ������ ������ = �������                 
                GetComponent<WeaponCalculation>().currentWeapon = GetComponent<Player>().secondWeapon.name; //�������� ������� ��� ������� ������������� ������ ������� ������, ��� ���������� �������������
                GetComponent<WeaponCalculation>().lastWeapon = GetComponent<Player>().firstWeapon.name; //������� �������������� ����������� ������
            }
            else if (GetComponent<Player>().currentWeapon == GetComponent<Player>().secondWeapon)
            {
                GetComponent<Player>().currentWeapon = GetComponent<Player>().firstWeapon; //������� ������ ������ = �������  
                GetComponent<WeaponCalculation>().currentWeapon = GetComponent<Player>().firstWeapon.name; //�������� ������� ��� ������� ������������� ������ ������� ������, ��� ���������� �������������
                GetComponent<WeaponCalculation>().lastWeapon = GetComponent<Player>().secondWeapon.name; //������� �������������� ����������� ������
            }   
        }
    }
}

