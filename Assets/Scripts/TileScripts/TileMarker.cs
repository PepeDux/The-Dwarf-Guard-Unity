using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMarker : MonoBehaviour
{
    [SerializeField] private Tilemap markerTileMap; //������� � ���������

    private Vector3Int CellPosition; //�������� ���������� �������
    private Vector3Int playerPosition; //�������� ���������� ������

    [SerializeField] private TileBase basicPointer; //��������� ���������� ����
    [SerializeField] private TileBase enemyPointer; //��������� ���������� ����

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

        markerTileMap.ClearAllTiles(); //������� ������� �� ���������� ������-��������
        playerPosition = TileManager.playerPosition;

        CheckCells();

        if (player.GetComponent<Player>().lineMove == true)
        {
            Select(new Vector3Int(0, 1, 0));  //�����
            Select(new Vector3Int(0, -1, 0)); //����
            Select(new Vector3Int(-1, 0, 0)); //�����
            Select(new Vector3Int(1, 0, 0));  //������
        }

        if (player.GetComponent<Player>().diagonalMove == true)
        {
            Select(new Vector3Int(1, 1, 0));   //������ �����
            Select(new Vector3Int(1, -1, 0));  //������ ����
            Select(new Vector3Int(-1, -1, 0)); //����� ����
            Select(new Vector3Int(-1, 1, 0));  //����� �����
        }
    }

    private void Select(Vector3Int select)
    {
        if (CellPosition == playerPosition + select && canSelect == true)
        {
            markerTileMap.SetTile(CellPosition, basicPointer); //������ ������ ���������� ����                      
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
