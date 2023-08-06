using EZCameraShake;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageScript : MonoBehaviour
{
    public GameObject corpse; //Труп или объект после смерти(не путать с лутом)
    public GameObject[] loot; //Вещи выпадающие из обхекта после смерти

    //Скрипт TakeDamage обрабатывает типы урона поступаемые объектам
    //Он учитывает сопроивления к урону в объекте и выдает  итоге дамаг после вычислений
    //
    //
    //
    //К скрипту можно обратиться так - TakeDamage(Damage:15, Damage:43); минуя не нужные типы урона


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
        Debug.Log($"Я {this.name} умер");

        //loot = UnityEngine.Random.Range(0, loot.Length);

        //Instantiate(loot[random], transform.position, transform.rotation);

        //Instantiate(corpse, transform.position, transform.rotation);

        GetComponent<MainObject>().anim.SetTrigger("Die");

        Destroy(this.gameObject);
    }

    public void Kill()
    {
        GetComponent<MainObject>().HP = -1000;
    }//Метод для отладки
}
