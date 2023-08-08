using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerTileManager : MonoBehaviour
{
    [SerializeField] private Tilemap tileMap; //Тайлмап

    private bool canMove = true;

    private Vector3Int CellPosition; //Тайловая координата курсора
    private Vector3Int playerPosition; //Тайловая координата игрока


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && TurnManager.playerTurn == true && GetComponent<Player>().movePoint > 0)
        {
            CellPosition = TileManager.CellPosition;
            playerPosition = TileManager.playerPosition;

            playerPosition = TileManager.playerPosition;

            CheckCells();

            if(GetComponent<Player>().lineMove == true)
            {
                Move(new Vector3Int(0, 1, 0));  //Вверх
                Move(new Vector3Int(0, -1, 0)); //Вниз
                Move(new Vector3Int(-1, 0, 0)); //Влево
                Move(new Vector3Int(1, 0, 0));  //Вправо
            }

            if(GetComponent<Player>().diagonalMove == true)
            {
                Move(new Vector3Int(1, 1, 0));   //Вправо вверх
                Move(new Vector3Int(1, -1, 0));  //Вправо вниз
                Move(new Vector3Int(-1, -1, 0)); //Влево вниз
                Move(new Vector3Int(-1, 1, 0));  //Влево вверх
            }
         
        }
    }

    private void Move(Vector3Int move)
    {
        if (CellPosition == playerPosition + move && canMove == true)
        {
            transform.position = tileMap.CellToWorld(CellPosition); //Перемещаем игрока на место кликнутого тайла
            transform.Translate(0.25f, 0.25f, 0); //Корректтируем координаты (Возможно в будущем может быть убрано)
           
            playerPosition = tileMap.WorldToCell(transform.position);
            GetComponent<Player>().coordinate = playerPosition;

            GetComponent<Player>().movePoint -= 1; //Отнимаем у игрока очки движения

            Debug.Log(playerPosition);
        }
    }

    

    private void CheckCells()
    {
        canMove = true;

        foreach (var cell in TileManager.impassableCells)
        {
            if (CellPosition == cell)
            {
                canMove = false;
            } 
        }
    }
}
