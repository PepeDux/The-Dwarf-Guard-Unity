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
        float prickDamage = 0,
        float slashDamage = 0,
        float crushDamage = 0,
        float poisonDamage = 0,
        float fireDamage = 0,
        float frostDamage = 0,
        float electricalDamage = 0,
        float curseDamage = 0,
        float drunkennessDamage = 0
        )
    {
        GetComponent<MainObject>().HP -= prickDamage * (1 - GetComponent<MainObject>().prickResist / 100);
        GetComponent<MainObject>().HP -= slashDamage * (1 - GetComponent<MainObject>().slashResist / 100);
        GetComponent<MainObject>().HP -= crushDamage * (1 - GetComponent<MainObject>().crushResist / 100);
        GetComponent<MainObject>().HP -= poisonDamage * (1 - GetComponent<MainObject>().poisonResist / 100);
        GetComponent<MainObject>().HP -= fireDamage * (1 - GetComponent<MainObject>().fireResist / 100);
        GetComponent<MainObject>().HP -= frostDamage * (1 - GetComponent<MainObject>().frostResist / 100);
        GetComponent<MainObject>().HP -= electricalDamage * (1 - GetComponent<MainObject>().electricalResist / 100);
        GetComponent<MainObject>().HP -= curseDamage * (1 - GetComponent<MainObject>().curseResist / 100);
        GetComponent<MainObject>().HP -= drunkennessDamage * (1 - GetComponent<MainObject>().curseResist / 100);

        CameraShaker.Instance.ShakeOnce(0.7f, 12f, 0.3f, 0.3f);
        //GetComponent<MainObject>().anim.SetTrigger("TakeDamage");

        if (GetComponent<MainObject>().HP <= 0)
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
