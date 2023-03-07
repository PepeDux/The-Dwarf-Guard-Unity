using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] public GameObject gam;

    private PereodicDamage pereodicDamage;

    public int HP;
    public int energy;
    public int time;
    public int interval;
    public int damage;
    public string type;

    private void OnTriggerEnter2D(Collider2D other)
    {
        pereodicDamage = gam.GetComponent<PereodicDamage>();

        if (other.gameObject.tag == "Player")
        {
            Player.HP += HP;
            Player.energy += energy;

            pereodicDamage.takeInfo(time, damage, interval, type);
            

            Destroy(this.gameObject);
        }
    }

    //public void Poison(int time, int damage, int interval)
    //{
    //    while(realyTime <= time)
    //    {
    //        realyTime += Time.deltaTime;

    //        if(realyTime % interval == 0) 
    //        {
    //            Player.HP -= damage;
    //            Debug.Log(Player.HP);
    //        }
    //    }
      
    //}

   
}
