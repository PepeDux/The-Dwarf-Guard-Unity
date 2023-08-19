using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionalObject : BaseObject
{
    [Header("Параметры объекта")]
    [SerializeField] private bool destroyAfterUse = false;
    [SerializeField] private bool useEveryTurn = false;

    [Header("")]
    [SerializeField] private FunctionalObjectData functional;


    private void OnEnable()
    {
        //Подписываемся на событие конца хода игрока 
        PlayerTurnManager.playerTurnFinished += Check;
        LevelManager.LevelEnded += Destroy;
    }

    private void OnDisable()
    {
        //Отписываемся на событие конца хода игрока 
        PlayerTurnManager.playerTurnFinished -= Check;
        LevelManager.LevelEnded -= Destroy;
    }





    private void Update()
    {
        Updater();
    }

    private void Start()
    {
        FindTileMap();
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        Use(target.GetComponent<MainObject>());
    }

    public void Use(MainObject target)
    {
        if (functional != null && target != null)
        {
            target.GetComponent<PermanentCalculation>().Сalculation(functional);
        }

        if (destroyAfterUse == true)
        {
            Destroy(this.gameObject);
        }
    }

    private void Check()
    {
        if (useEveryTurn == true && functional != null)
        {
            foreach (var character in TileManager.allСharacters)
            {
                if (character.coordinate == coordinate)
                {
                    Use(character);
                }
            }
        }
    }
}
