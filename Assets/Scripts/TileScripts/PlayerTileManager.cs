using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerTileManager : MonoBehaviour
{
    [SerializeField] private Tilemap tileMap; //�������

    private Vector3Int CellPosition; //�������� ���������� �������
    private Vector3Int playerPosition; //�������� ���������� ������

    private void Start()
    {
        tileMap = GameObject.Find("Ground").GetComponent<Tilemap>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && GetComponent<Player>().movePoint > 0)
        {
            CellPosition = TileManager.CellPosition;
            playerPosition = TileManager.playerPosition;

            playerPosition = TileManager.playerPosition;

            CheckCells();

            if(GetComponent<Player>().lineMove == true)
            {
                Move(new Vector3Int(0, 1, 0));  //�����
                Move(new Vector3Int(0, -1, 0)); //����
                Move(new Vector3Int(-1, 0, 0)); //�����
                Move(new Vector3Int(1, 0, 0));  //������
            }

            if(GetComponent<Player>().diagonalMove == true)
            {
                Move(new Vector3Int(1, 1, 0));   //������ �����
                Move(new Vector3Int(1, -1, 0));  //������ ����
                Move(new Vector3Int(-1, -1, 0)); //����� ����
                Move(new Vector3Int(-1, 1, 0));  //����� �����
            }
         
        }
    }

    private void Move(Vector3Int move)
    {
        if (CellPosition == playerPosition + move && CheckCells() == true)
        {
            transform.position = tileMap.CellToWorld(CellPosition); //���������� ������ �� ����� ���������� �����
            transform.Translate(0.25f, 0.25f, 0); //������������� ���������� (�������� � ������� ����� ���� ������)
           
            playerPosition = tileMap.WorldToCell(transform.position);
            GetComponent<Player>().coordinate = playerPosition;

            GetComponent<Player>().movePoint -= 1; //�������� � ������ ���� ��������
        }
    }

    

    private bool CheckCells()
    {
        foreach (var cell in TileManager.impassableCells)
        {
            if (CellPosition == cell)
            {
                //���� �������� ������ ������, �� ������ �� ��� �����������
                return false;
            } 
        }

        //���������� true ���� ��� �������� ������ �������� ������ ���� ���������
        return true;
    }
}
