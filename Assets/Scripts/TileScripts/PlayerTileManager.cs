using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerTileManager : MonoBehaviour
{
    [SerializeField] private Tilemap tileMap; //Тайлмап

    private bool canMove = true;

    private Vector3 WorldPosition; //Мировая координата курсора
    private Vector3Int CellPosition; //Тайловая координата курсора
    private Vector3Int playerPosition; //Тайловая координата игрока


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && TurnManager.playerTurn == true && GetComponent<Player>().movePoint > 0)
        {
            WorldPosition = TileManager.WorldPosition;
            CellPosition = TileManager.CellPosition;
            playerPosition = TileManager.playerPosition;

            playerPosition = TileManager.playerPosition;

            CheckCells();

            Move(Vector3Int.up);
            Move(Vector3Int.down);
            Move(Vector3Int.left);
            Move(Vector3Int.right);
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
