using EZCameraShake;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageScript : MonoBehaviour
{
    public GameObject corpse; //���� ��� ������ ����� ������(�� ������ � �����)
    public GameObject[] loot; //���� ���������� �� ������� ����� ������

    //������ TakeDamage ������������ ���� ����� ����������� ��������
    //�� ��������� ������������ � ����� � ������� � ������  ����� ����� ����� ����������
    //
    //
    //
    //� ������� ����� ���������� ��� - TakeDamage(Damage:15, Damage:43); ����� �� ������ ���� �����


    public void TakeDamage
        (
        int physicalDamage = 0,
        int poisonDamage = 0,
        int fireDamage = 0,
        int frostDamage = 0,
        int drunkennessDamage = 0
        )
    {
        //GetComponent<MainObject>().HP -= poisonDamage * (1 - GetComponent<MainObject>().poisonResist / 100);
        //GetComponent<MainObject>().HP -= fireDamage * (1 - GetComponent<MainObject>().fireResist / 100);
        //GetComponent<MainObject>().HP -= frostDamage * (1 - GetComponent<MainObject>().frostResist / 100);
        //GetComponent<MainObject>().HP -= drunkennessDamage * (1 - GetComponent<MainObject>().drunkennessResist / 100);


        physicalDamage -= GetComponent<MainObject>().physicalResist;

        if (physicalDamage > 0)
        {
            if (GetComponent<MainObject>().armor <= 0)
            {
                GetComponent<MainObject>().HP -= physicalDamage;
            }

            GetComponent<MainObject>().armor -= 1;
        }



        CameraShaker.Instance.ShakeOnce(0.7f, 12f, 0.3f, 0.3f); //�������� ������ ��� ��������� �����
        //GetComponent<MainObject>().anim.SetTrigger("TakeDamage");

        if (GetComponent<MainObject>().HP <= 0 && gameObject != null)
        {
            Die();
        }
    }


    public void Die()
    {
        Debug.Log($"� {this.name} ����");

        //loot = UnityEngine.Random.Range(0, loot.Length);

        //Instantiate(loot[random], transform.position, transform.rotation);

        //Instantiate(corpse, transform.position, transform.rotation);

        GetComponent<MainObject>().anim.SetTrigger("Die");

        Destroy(this.gameObject);
    }

    public void Kill()
    {
        GetComponent<MainObject>().HP = -1000;
    }//����� ��� �������
}
