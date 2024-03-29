using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BaseObject : MonoBehaviour
{
    [Header("������� � ������")]
    public Vector3Int coordinate;
    public Tilemap tileMap;


    private void OnEnable()
    {
        //������������� �� ������� ����� ���� ������ 
        LevelManager.levelEnded += Destroy;
    }

    private void OnDisable()
    {
        //������������ �� ������� ����� ���� ������ 
        LevelManager.levelEnded -= Destroy;
    }


    public void UpdateCoordinate()
    {
        transform.position = tileMap.CellToWorld(coordinate); //����������� ���������� ������� � ������� �����������
        transform.Translate(0.25f, 0.25f, 0); //������������� ���������� (�������� � ������� ����� ���� ������)



        //���� ���������� ������� ������������ �� ��������� ������ ����,
        //�� ��� ������������� �� ����������� ��������� � �������� ���� �������� ���������� �� ����� �� ����
        //-----------------------------------------
        if (coordinate.y > TileManager.maxTop)
        {
            coordinate.y = TileManager.maxTop;
        }

        if (coordinate.y < TileManager.maxDown)
        {
            coordinate.y = TileManager.maxDown;
        }

        if (coordinate.x > TileManager.maxRight)
        {
            coordinate.x = TileManager.maxRight;
        }

        if (coordinate.x < TileManager.maxLeft)
        {
            coordinate.x = TileManager.maxLeft;
        }
        //-----------------------------------------

    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }

    public virtual void Updater()
    {
        UpdateCoordinate();
    }

    public void FindTileMap()
    {
        tileMap = GameObject.Find("Ground").GetComponent<Tilemap>();
    }
}
