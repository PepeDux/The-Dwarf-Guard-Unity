using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    public Transform parentEnemy; //������������ ������ ������ ��������
    public Transform parentStaticObject; //������������ ������ ��������� ��������
    public Transform parentFunctionalObject; //������������ ������ �������������� ��������

    [SerializeField] public Player player; //�����

    [SerializeField] private Tilemap tileMap; //�������
    private Camera mainCamera; //������

    public static Vector3 WorldPosition; //������� ���������� �������
    public static Vector3Int CellPosition; //�������� ���������� �������
    public static Vector3Int playerPosition; //�������� ���������� ������

    public static List<Vector3Int> occupiedCells = new List<Vector3Int>(); //��� ������� ������
    public static List<Vector3Int> impassableCells = new List<Vector3Int>(); //������ �� ������� ������ ���������
    public static List<Vector3Int> functionalCells = new List<Vector3Int>(); //�������������� �������
    public static List<Vector3Int> edgeCells = new List<Vector3Int>(); //������ "������" ������� �� ����� ������ � ����������� ������� �� ���
    public static List<Vector3Int> markerCells = new List<Vector3Int>(); //������ ������� ���������� ������� �� ����
    public static List<Vector3Int> enemyCells = new List<Vector3Int>(); //������ �� ������� ��������� ����

    public static List<MainObject> enemyList = new List<MainObject>(); //������ ������ �� ����� � ���� ������� ��������
    public static List<MainObject> all�haracters = new List<MainObject>(); //������ ���� ���������� �� �����



    public static int xField = 8; //������ ������ �������� ����, ������ ������� � 0
    public static int yField = 8; //������ ������ �������� ����, ������ ������� � 0

    //������������ ���������� ���� ����������� �������� ����
    public static int maxTop = yField;
    public static int maxDown = 0;
    public static int maxLeft = 0;
    public static int maxRight = xField;




    void Start()
    {
        mainCamera = Camera.main;

        TileGameObjectUpdatePosition();
    }

    void Update()
    {
        PlayerSelectTile();
        EdgeCalcelation();
        TileGameObjectUpdatePosition();
    }

    public void TileGameObjectUpdatePosition()
    {
        //������� ��� ����� �� ������ ������ ����� �� ��������
        occupiedCells.Clear();
        impassableCells.Clear();
        functionalCells.Clear();
        enemyCells.Clear();
        enemyList.Clear();
        all�haracters.Clear();



        //������� ������ �� ������� ����
        if (player != null)
        {
            playerPosition = player.coordinate;
        }

        //���������� ����� �������� ���� � ������ ������������ ������
        impassableCells.AddRange(edgeCells);

        //���������� ������� ������ � ������ ������������ � ������� ������
        impassableCells.Add(playerPosition);
        occupiedCells.Add(playerPosition);

        //���������� ��� �������� ������� �� ������������� ������� ������ ��� ������ ��������� � ����
        foreach (Transform obj in parentEnemy.transform)
        {
            if (obj != null)
            {
                impassableCells.Add(obj.GetComponent<BaseObject>().coordinate);
                occupiedCells.Add(obj.GetComponent<BaseObject>().coordinate);
                enemyCells.Add(obj.GetComponent<BaseObject>().coordinate);
                enemyList.Add(obj.gameObject.GetComponent<MainObject>());
            }
        }

        //���������� ��� �������� ������� �� ������������� ������� ��������� �������� ��� ������ ��������� � ����
        foreach (Transform obj in parentStaticObject.transform)
        {
            if (obj != null)
            {
                occupiedCells.Add(obj.GetComponent<BaseObject>().coordinate);
                impassableCells.Add(obj.GetComponent<BaseObject>().coordinate);
            }
        }

        //���������� ��� �������� ������� �� ������������� ������� ������� ��� ������ ��������� � ����
        foreach (Transform obj in parentFunctionalObject.transform)
        {
            if (obj != null)
            {
                occupiedCells.Add(obj.GetComponent<BaseObject>().coordinate);
            }
        }




        all�haracters.AddRange(enemyList);
        all�haracters.Add(player);
    }

    public void EdgeCalcelation()
    {
        //��������� ������� ����� ������ �� �������� �������� � ���������� �� � ������

        for (int i = 0; i <= xField; i++)
        {
            edgeCells.Add(new Vector3Int(i, -1, 0));
            edgeCells.Add(new Vector3Int(i, yField + 1, 0));
        }
        for (int j = 0; j <= yField; j++)
        {
            edgeCells.Add(new Vector3Int(-1, j, 0));
            edgeCells.Add(new Vector3Int(xField + 1, j, 0));
        }
    }

    public void PlayerSelectTile()
    {
        if(player != null)
        {
            WorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition); //����� ���������� ������� �� �����
            CellPosition = tileMap.WorldToCell(WorldPosition); //��������� ������� ���������� � ���������� �� ��������
        }
    }
}