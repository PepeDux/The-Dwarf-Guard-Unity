using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMarker : MonoBehaviour
{
    [SerializeField] private Tilemap markerTileMap; //Тайлмап с маркерами

    private Vector3Int CellPosition; //Тайловая координата курсора
    private Vector3Int playerPosition; //Тайловая координата игрока

    [SerializeField] private TileBase basicPointer; //Указатель возможного хода
    [SerializeField] private TileBase enemyPointer; //Указатель возможного хода

    private GameObject player;

    private bool canMove = true;
    private bool canSelect = true;
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

        if (player.GetComponent<Player>().lineMove == true)
        {
            Select(new Vector3Int(0, 1, 0));  //Вверх
            Select(new Vector3Int(0, -1, 0)); //Вниз
            Select(new Vector3Int(-1, 0, 0)); //Влево
            Select(new Vector3Int(1, 0, 0));  //Вправо
        }

        if (player.GetComponent<Player>().diagonalMove == true)
        {
            Select(new Vector3Int(1, 1, 0));   //Вправо вверх
            Select(new Vector3Int(1, -1, 0));  //Вправо вниз
            Select(new Vector3Int(-1, -1, 0)); //Влево вниз
            Select(new Vector3Int(-1, 1, 0));  //Влево вверх
        }
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
