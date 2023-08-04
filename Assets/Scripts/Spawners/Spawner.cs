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
    public GameObject tileManager;

    [HideInInspector] public Vector3Int coordinate;
    [HideInInspector] public bool canPut;

    public void Spawn(GameObject[] objects)
    {
        if (objects.Length > 0)
        {
            tileManager.GetComponent<TileManager>().TileGameObjectUpdatePosition();

            canPut = true;

            //�������� ��������� �� ����������� ������
            �heckCoordinate();

            if (canPut == true)
            {
                //������� ������ �� ����� ������ �� ���������� ��������� �������
                int random = Random.Range(0, objects.Length);

                //������ ������ � ���������� ��� �� ������ ����������
                GameObject gameObject = Instantiate(objects[random], transform);
                gameObject.GetComponent<BaseObject>().coordinate = coordinate;
            }
        }      
    }

    public void �heckCoordinate()
    {
        //��������� ���������� � �������� �������� ����
        coordinate = new Vector3Int(Random.Range(0, TileManager.xField + 1), Random.Range(0, TileManager.yField + 1), 0);

        foreach (var cell in TileManager.occupiedCells)
        {
            if (coordinate == cell)
            {
                //���� ������ ������������ � �����, �� ��� ����� �����������
                canPut = false;
            }
        }
    }
}
