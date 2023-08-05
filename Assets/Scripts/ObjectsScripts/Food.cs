using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : BaseObject
{
    //
    //
    //  À¿—— ¬ –¿«–¿¡Œ“ ≈!!!
    //
    //

    public int restoredHP;
    public int restoredEnergy;

    public int time;
    public int interval;
    public int damage;
    public string type;

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<MainObject>().HP += restoredHP;
        other.GetComponent<MainObject>().energy += restoredEnergy;

        other.GetComponent<PereodicDamageScript>().TakeInfo(time, damage, type);

        Destroy(this.gameObject);
    }

    private void Update()
    {
        Updater();
    }

    private void Start()
    {
        FindTileMap();
    }
}
