using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] public GameObject gam;

    public int HP;
    public int energy;

    public int time;
    public int interval;
    public int damage;
    public string type;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<MainObject>().HP += HP;
            other.GetComponent<MainObject>().energy += energy;
            
            other.GetComponent<PereodicDamageScript>().TakeInfo(time, damage, interval, type);

            Destroy(this.gameObject);
        }
    }
}
