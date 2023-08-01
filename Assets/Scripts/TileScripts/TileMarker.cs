using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMarker : MonoBehaviour
{
    [SerializeField] private Tilemap markerTileMap; //Тайлмап с маркерами

    private Vector3 WorldPosition; //Мировая координата курсора
    private Vector3Int CellPosition; //Тайловая координата курсора
    private Vector3Int playerPosition; //Тайловая координата игрока

    [SerializeField] private TileBase basicPointer; //Указатель возможного хода
    [SerializeField] private TileBase enemyPointer; //Указатель возможного хода

    private bool canMove = true;
    private bool canSelect = true;
    private bool canSelectEnemyMarker = true;



    void Update()
    {
        WorldPosition = TileManager.WorldPosition;
        CellPosition = TileManager.CellPosition;
        playerPosition = TileManager.playerPosition;

        markerTileMap.ClearAllTiles(); //Очищаем тайлмап от предыдущих тайлов-маркеров
        playerPosition = TileManager.playerPosition;

        CheckCells();

        Select(Vector3Int.up);
        Select(Vector3Int.down);
        Select(Vector3Int.left);
        Select(Vector3Int.right);
    }

    private void Select(Vector3Int select)
    {
        if (CellPosition == playerPosition + select && canSelect == true)
        {
            markerTileMap.SetTile(CellPosition, basicPointer); //Ставим маркер возможного хода                      
        }
        else if (CellPosition == playerPosition + select && canSelectEnemyMarker == true && canSelect == false)
        {
            markerTileMap.SetTile(CellPosition, enemyPointer);
        }
    }
    private void CheckCells()
    {
        canSelect = true;
        canMove = true;
        canSelectEnemyMarker = false;

        foreach (var cell in TileManager.impassableCells)
        {
            if (CellPosition == cell)
            {
                canMove = false;
                canSelect = false;
            }
        }

        foreach (var enemyMarker in TileManager.enemyCells)
        {
            if (CellPosition == enemyMarker)
            {
                canSelect = false;
                canSelectEnemyMarker = true;
            }
        }
    }
}
