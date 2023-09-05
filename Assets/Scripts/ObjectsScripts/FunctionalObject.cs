using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionalObject : BaseObject
{
    [SerializeField] private bool canUse = true;

    [Header("Параметры объекта")]
    [SerializeField] private bool destroyAfterUse = false;
    [SerializeField] private bool timer;

    [Header("")]
    [SerializeField] private FunctionalObjectData functional;

    [Header("Счетчик ходов")]
    [SerializeField] private int turnsToActivate = 0;
    [SerializeField] private int turnTimer;

    [Header("Спрайты")]
    private Sprite waitingSprite;
    [SerializeField] private Sprite activatedSprite;


    private void OnEnable()
    {
        //Подписываемся на событие конца хода игрока
        PlayerTurnManager.playerTurnFinished += Timer;
        PlayerTurnManager.playerTurnFinished += Check;
        LevelManager.LevelEnded += Destroy;
    }

    private void OnDisable()
    {
        //Отписываемся на событие конца хода игрока
        PlayerTurnManager.playerTurnFinished -= Timer;
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

        waitingSprite = GetComponent<SpriteRenderer>().sprite;
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        //Предмет юзается при соприкосновении с целью
        Use(target.GetComponent<MainObject>());
    }

    public void Use(MainObject target)
    {
        if (functional != null && target != null && canUse == true)
        {
            target.GetComponent<PermanentCalculation>().Сalculation(functional);
            //Меняет спрайт на активированный
            GetComponent<SpriteRenderer>().sprite = activatedSprite;


            canUse = false;

        }

        if (destroyAfterUse == true)
        {
            Destroy(this.gameObject);
        }
    }

    private void Check()
    {
        if (functional != null && canUse == true)
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

    private void Timer()
    {
        if(timer == true)
        {
            turnsToActivate++;

            if (turnsToActivate == turnTimer)
            {
                canUse = true;
                turnsToActivate = 0;

                //Меняет спрайт на ожидающий
                GetComponent<SpriteRenderer>().sprite = waitingSprite;
            }
        }
    }
}
