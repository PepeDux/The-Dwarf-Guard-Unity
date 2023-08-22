using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMarker : MonoBehaviour
{
    [SerializeField] private Tilemap markerTileMap; //Тайлмап с маркерами

    private Vector3Int CellPosition; //Тайловая координата курсора
    private Vector3Int playerPosition; //Тайловая координата игрока

    [SerializeField] private TileBase movePointer; //Указатель возможного хода
    [SerializeField] private TileBase enemyPointer; //Указатель возможного хода

    private GameObject player;

    private bool canMove = true;
    private bool canSelectMoveMarker = true;
    private bool canSelectEnemyMarker = true;


    private void Start()
    {
        player = GameObject.Find("Dwarf Guard");
    }

    void Update()
    {
        CellPosition = TileManager.CellPosition; 
        playerPosition = TileManager.playerPosition;

        markerTileMap.ClearAllTiles(); //Очищаем тайлмап от предыдущих тайлов-маркеров
        playerPosition = TileManager.playerPosition;

        CheckCells();

        if(player != null)
        {
            if (player.GetComponent<Player>().lineMove == true)
            {
                SelectMoveCell(new Vector3Int(0, 1, 0));  //Вверх
                SelectMoveCell(new Vector3Int(0, -1, 0)); //Вниз
                SelectMoveCell(new Vector3Int(-1, 0, 0)); //Влево
                SelectMoveCell(new Vector3Int(1, 0, 0));  //Вправо
            }

            if (player.GetComponent<Player>().diagonalMove == true)
            {
                SelectMoveCell(new Vector3Int(1, 1, 0));   //Вправо вверх
                SelectMoveCell(new Vector3Int(1, -1, 0));  //Вправо вниз
                SelectMoveCell(new Vector3Int(-1, -1, 0)); //Влево вниз
                SelectMoveCell(new Vector3Int(-1, 1, 0));  //Влево вверх
            }



            if (player.GetComponent<Player>().lineAttack == true)
            {
                SelectEnemyCell(new Vector3Int(0, 1, 0));  //Вверх
                SelectEnemyCell(new Vector3Int(0, -1, 0)); //Вниз
                SelectEnemyCell(new Vector3Int(-1, 0, 0)); //Влево
                SelectEnemyCell(new Vector3Int(1, 0, 0));  //Вправо
            }

            if (player.GetComponent<Player>().diagonalAttack == true)
            {
                SelectEnemyCell(new Vector3Int(1, 1, 0));   //Вправо вверх
                SelectEnemyCell(new Vector3Int(1, -1, 0));  //Вправо вниз
                SelectEnemyCell(new Vector3Int(-1, -1, 0)); //Влево вниз
                SelectEnemyCell(new Vector3Int(-1, 1, 0));  //Влево вверх
            }
        }
    }

    private void SelectMoveCell(Vector3Int select)
    {
        if (CellPosition == playerPosition + select && canSelectMoveMarker == true)
        {
            markerTileMap.SetTile(CellPosition, movePointer); //Ставим маркер возможного хода                                                
        }
    }

    private void SelectEnemyCell(Vector3Int select)
    {
        if (CellPosition == playerPosition + select && canSelectEnemyMarker == true)
        {
            markerTileMap.SetTile(CellPosition, enemyPointer); //Ставим маркер врага
        }
    }
    private void CheckCells()
    {
        canSelectMoveMarker = true;
        canMove = true;
        canSelectEnemyMarker = false;

        foreach (var cell in TileManager.impassableCells)
        {
            if (CellPosition == cell)
            {
                canMove = false;
                canSelectMoveMarker = false;
            }
        }

        foreach (var cell in TileManager.enemyCells)
        {
            if (CellPosition == cell)
            {
                canSelectMoveMarker = false;
                canSelectEnemyMarker = true;
            }
        }
    }
}
