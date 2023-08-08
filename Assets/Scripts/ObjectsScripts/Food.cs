using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : BaseObject
{
    public int restoredHP;
    public int restoredMovePoint;
    public int restoredActionPoint;
    public int restoredBeerPoint;

    private void OnTriggerEnter2D(Collider2D target)
    {
        target.GetComponent<MainObject>().HP += restoredHP;
        target.GetComponent<MainObject>().movePoint += restoredMovePoint;
        target.GetComponent<MainObject>().actionPoints += restoredActionPoint;
        target.GetComponent<MainObject>().beerPoint += restoredBeerPoint;

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
