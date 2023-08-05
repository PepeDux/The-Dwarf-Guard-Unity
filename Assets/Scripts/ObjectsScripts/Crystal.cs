using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : BaseObject
{
    public ScriptableObject scriptableObject = new ScriptableObject();
    private void OnTriggerEnter2D(Collider2D other)
    {
        GetComponent<StatusCalculation>().statusAdd = scriptableObject.name;

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
