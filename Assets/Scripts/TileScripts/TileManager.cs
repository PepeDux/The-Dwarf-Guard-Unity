using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    public Transform parentEnemy; //Родительский объект врагов объектов
    public Transform parentStaticObject; //Родительский объект статичных объектов
    public Transform parentPickUpObject; //Родительский объект подбираемых объектов

    [SerializeField] public GameObject player; //Игрок

    [SerializeField] private Tilemap tileMap; //Тайлмап
    private Camera mainCamera; //Камера

    public static Vector3 WorldPosition; //Мировая координата курсора
    public static Vector3Int CellPosition; //Тайловая координата курсора
    public static Vector3Int playerPosition; //Тайловая координата игрока

    public static List<Vector3Int> occupiedCells = new List<Vector3Int>(); //Все занятые клетки
    public static List<Vector3Int> impassableCells = new List<Vector3Int>(); //Клетки на которые нельзя наступить
    public static List<Vector3Int> edgeCells = new List<Vector3Int>();
    public static List<Vector3Int> markerCells = new List<Vector3Int>(); //Клетки которые отображают маркеры на поле
    public static List<Vector3Int> enemyCells = new List<Vector3Int>(); //Клетки на которых находится враг

    public static List<GameObject> enemyList = new List<GameObject>(); //Список врагов на сцене в виде игровых объектов



    public static int xField = 8;
    public static int yField = 8;

    public static int maxTop = yField;
    public static int maxDown = 0;
    public static int maxLeft = 0;
    public static int maxRight = xField;




    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        PlayerSelectTile();
        EdgeCalcelation();
        TileGameObjectUpdatePosition();
    }

    public void TileGameObjectUpdatePosition()
    {
        //Очищаем все листы чтобы их обновить
        occupiedCells.Clear();
        impassableCells.Clear();
        enemyCells.Clear();
        enemyList.Clear();

        impassableCells.AddRange(edgeCells);
        impassableCells.Add(playerPosition);

        //Перебираем все дочерние объекты из родительского объекта для записи координат в лист
        foreach (Transform obj in parentEnemy.transform)
        {
            if (obj != null)
            {
                impassableCells.Add(tileMap.WorldToCell(obj.transform.position));
                enemyCells.Add(tileMap.WorldToCell(obj.transform.position));
                enemyList.Add(obj.gameObject);
            }
        }

        //Перебираем все дочерние объекты из родительского объекта для записи координат в лист
        foreach (Transform obj in parentStaticObject.transform)
        {
            if (obj != null)
            {
                occupiedCells.Add(tileMap.WorldToCell(obj.transform.position));
                impassableCells.Add(tileMap.WorldToCell(obj.transform.position));
            }
        }

        //Перебираем все дочерние объекты из родительского объекта для записи координат в лист
        foreach (Transform obj in parentPickUpObject.transform)
        {
            if (obj != null)
            {
                occupiedCells.Add(tileMap.WorldToCell(obj.transform.position));
            }
        }
    }

    public void EdgeCalcelation()
    {
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
        WorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition); //Берем координаты мировые на сцене
        CellPosition = tileMap.WorldToCell(WorldPosition); //Переводим мировые координаты в координаты на тайлмапе

        playerPosition = tileMap.WorldToCell(player.transform.position);
    }
}

