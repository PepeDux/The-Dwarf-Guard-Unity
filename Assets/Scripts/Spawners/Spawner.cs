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

            //Проверка координат на свободность клетки
            СheckCoordinate();

            if (canPut == true)
            {
                //Спавним объект на сцену исходя из случайного выбраного объекта
                int random = Random.Range(0, objects.Length);

                //Спаним объект и перемещаем его на нужную координату
                GameObject gameObject = Instantiate(objects[random], transform);
                gameObject.GetComponent<BaseObject>().coordinate = coordinate;
            }
        }      
    }

    public void СheckCoordinate()
    {
        //Случайная координата в пределах игрового поля
        coordinate = new Vector3Int(Random.Range(0, TileManager.xField + 1), Random.Range(0, TileManager.yField + 1), 0);

        foreach (var cell in TileManager.occupiedCells)
        {
            if (coordinate == cell)
            {
                //Если объект присутствует в листе, то его спавн запрещается
                canPut = false;
            }
        }
    }
}
