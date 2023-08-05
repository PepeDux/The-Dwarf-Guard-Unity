using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : BaseObject
{
    public int cost;


    private void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<MainObject>().money += cost;

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
