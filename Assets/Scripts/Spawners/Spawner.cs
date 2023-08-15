using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Tilemaps;

public class Spawner : MonoBehaviour
{
    public Tilemap tileMap;
    public TileManager tileManager;

    [Header("���������� � ������")]
    public LevelInfo levelInfo;

    private Vector3Int coordinate;
    private bool canPut;

    public void Spawn(GameObject[] objects)
    {
        if (objects.Length > 0)
        {
            //�������� ���� ������ �� �� ������
            tileManager.TileGameObjectUpdatePosition();

            //n-�� ������� �� ����� �������
            for (int i = 0; i < 5; i++)
            {
                if (�heckCoordinate() == true)
                {
                    //������� ������ �� ����� ������ �� ���������� ��������� �������
                    int random = Random.Range(0, objects.Length);

                    //������ ������ � ���������� ��� �� ������ ����������, � ����������� ��� � ���������������� ��� �������
                    GameObject gameObject = Instantiate(objects[random], transform);
                    gameObject.GetComponent<BaseObject>().coordinate = coordinate;

                    break;
                }
            }      
        }      
    }

    public bool �heckCoordinate()
    {
        //��������� ���������� � �������� �������� ����
        coordinate = new Vector3Int(Random.Range(0, TileManager.xField + 1), Random.Range(0, TileManager.yField + 1), 0);

        foreach (var cell in TileManager.occupiedCells)
        {     
            if (coordinate == cell)
            {
                //���� ������ ������������ � �����, �� ��� ����� �����������
                return false;
            }
        }

        return true;
    }
}
