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
    public GameObject[] objects;

    public GameObject tileManager;

    private Vector3Int coordinate;

    private bool canPut;


    private void Start()
    {

    }
    public void Spawn()
    {
        tileManager.GetComponent<TileManager>().TileGameObjectUpdatePosition();

        canPut = true;

        //Проверка координат на свободность клетки
        СheckCoordinate();

        if(canPut == true)
        {
            //Спавним объект на сцену исходя из случайного выбраного объекта и координат
            int randomGameObject = Random.Range(0, objects.Length);

            //Спаним объект и перемещаем его на нужную координату
            GameObject gameObject = Instantiate(objects[randomGameObject], transform);
            gameObject.transform.position = tileMap.CellToWorld(coordinate);
            gameObject.transform.Translate(0.25f, 0.25f, 0);
        }
    }

    public void СheckCoordinate()
    {
        //Случайная координата в пределах игрового поля
        coordinate = new Vector3Int(Random.Range(0, TileManager.maxRight + 1), Random.Range(0, TileManager.maxTop + 1), 0);

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
