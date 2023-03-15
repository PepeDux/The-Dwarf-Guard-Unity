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
        if (Player.energy >= Player.energyWaste && Input.GetMouseButtonDown(0) && CanAttack == true)
        {     
            bufSpeed = Player.speed;    //���������� ����������� �������� ��������� � �����
            Player.speed = 0f;         //������������ ���������

            anim.SetTrigger("Attack");  //������������� �������� �����
            Player.energy -= Player.energyWaste; // �������� ������ ������� �� ������� ��������� 
            CanAttack = false;
            NextAnimator.SetTrigger("OnAnimationEnded"); //�������� ����� AttackToogle()

            Collider2D[] HitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, EnemyLayers);

            foreach(Collider2D enemy in HitEnemies)
            {
               enemy.GetComponent<Enemy>().TakeDamage(fireDamage: 10);
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
        Player.speed = bufSpeed;   //�������������� �������� ���������
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere (AttackPoint.position, AttackRange);
    }

}

