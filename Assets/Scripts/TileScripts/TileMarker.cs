using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMarker : MonoBehaviour
{
    [SerializeField] private Tilemap markerTileMap; //������� � ���������

    private Vector3Int CellPosition; //�������� ���������� �������
    private Vector3Int playerPosition; //�������� ���������� ������

    [SerializeField] private TileBase movePointer; //��������� ���������� ����
    [SerializeField] private TileBase enemyPointer; //��������� ���������� ����

    private Player player;

    private bool canMove = true;
    private bool canSelectMoveMarker = true;
    private bool canSelectEnemyMarker = true;



    private void OnEnable()
    {
        Player.playerSpawned += AddPlayer;
    }
    private void OnDisable()
    {
        Player.playerSpawned -= AddPlayer;
    }

    private void Start()
    {
       
    }

    void Update()
    {
        CellPosition = TileManager.CellPosition; 
        playerPosition = TileManager.playerPosition;

        markerTileMap.ClearAllTiles(); //������� ������� �� ���������� ������-��������
        playerPosition = TileManager.playerPosition;

        CheckCells();

        if(player != null)
        {
            if (player.lineMove == true)
            {
                SelectMoveCell(new Vector3Int(0, 1, 0));  //�����
                SelectMoveCell(new Vector3Int(0, -1, 0)); //����
                SelectMoveCell(new Vector3Int(-1, 0, 0)); //�����
                SelectMoveCell(new Vector3Int(1, 0, 0));  //������
            }

            if (player.diagonalMove == true)
            {
                SelectMoveCell(new Vector3Int(1, 1, 0));   //������ �����
                SelectMoveCell(new Vector3Int(1, -1, 0));  //������ ����
                SelectMoveCell(new Vector3Int(-1, -1, 0)); //����� ����
                SelectMoveCell(new Vector3Int(-1, 1, 0));  //����� �����
            }



            if (player.lineAttack == true)
            {
                SelectEnemyCell(new Vector3Int(0, 1, 0));  //�����
                SelectEnemyCell(new Vector3Int(0, -1, 0)); //����
                SelectEnemyCell(new Vector3Int(-1, 0, 0)); //�����
                SelectEnemyCell(new Vector3Int(1, 0, 0));  //������
            }

            if (player.diagonalAttack == true)
            {
                SelectEnemyCell(new Vector3Int(1, 1, 0));   //������ �����
                SelectEnemyCell(new Vector3Int(1, -1, 0));  //������ ����
                SelectEnemyCell(new Vector3Int(-1, -1, 0)); //����� ����
                SelectEnemyCell(new Vector3Int(-1, 1, 0));  //����� �����
            }
        }
    }

    private void SelectMoveCell(Vector3Int select)
    {
        if (CellPosition == playerPosition + select && canSelectMoveMarker == true)
        {
            markerTileMap.SetTile(CellPosition, movePointer); //������ ������ ���������� ����                                                
        }
    }

    private void SelectEnemyCell(Vector3Int select)
    {
        if (CellPosition == playerPosition + select && canSelectEnemyMarker == true)
        {
            markerTileMap.SetTile(CellPosition, enemyPointer); //������ ������ �����
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
    private void AddPlayer(Player player)
    {
        this.player = player;
    }
}
