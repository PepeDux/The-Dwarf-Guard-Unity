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

    [Header("Информация о уровне")]
    public LevelInfo levelInfo;

    private Vector3Int coordinate;
    private bool canPut;

    public void Spawn(GameObject[] objects)
    {
        if (objects.Length > 0)
        {
            //Проверка всех клеток на их статус
            tileManager.TileGameObjectUpdatePosition();

            //n-ое попыток на спавн объекта
            for (int i = 0; i < 5; i++)
            {
                if (СheckCoordinate() == true)
                {
                    //Спавним объект на сцену исходя из случайного выбраного объекта
                    int random = Random.Range(0, objects.Length);

                    //Спаним объект и перемещаем его на нужную координату, и прикрепляем его к соответствующему ему объекту
                    GameObject gameObject = Instantiate(objects[random], transform);
                    gameObject.GetComponent<BaseObject>().coordinate = coordinate;

                    break;
                }
            }      
        }      
    }

    public bool СheckCoordinate()
    {
        //Случайная координата в пределах игрового поля
        coordinate = new Vector3Int(Random.Range(0, TileManager.xField + 1), Random.Range(0, TileManager.yField + 1), 0);

        foreach (var cell in TileManager.occupiedCells)
        {     
            if (coordinate == cell)
            {
                //Если объект присутствует в листе, то его спавн запрещается
                return false;
            }
        }

        return true;
    }
}
