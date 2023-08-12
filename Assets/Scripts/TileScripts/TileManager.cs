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
    public static List<Vector3Int> edgeCells = new List<Vector3Int>(); //Клетки "стенки" стоящие на краях уровня и запрещающие движеня за них
    public static List<Vector3Int> markerCells = new List<Vector3Int>(); //Клетки которые отображают маркеры на поле
    public static List<Vector3Int> enemyCells = new List<Vector3Int>(); //Клетки на которых находится враг

    public static List<MainObject> enemyList = new List<MainObject>(); //Список врагов на сцене в виде игровых объектов



    public static int xField = 8; //Размер ширины игрового поля, начало отсчета с 0
    public static int yField = 8; //Размер высоты игрового поля, начало отсчета с 0

    //Максимальные координаты всех направлений игрового поля
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
        //Очищаем все листы от старых данных чтобы их обновить
        occupiedCells.Clear();
        impassableCells.Clear();
        enemyCells.Clear();
        enemyList.Clear();

        //Позиция игрока на игровом поле
        playerPosition = player.GetComponent<Player>().coordinate;

        //Записываем грани игрового поля в список непроходимых клеток
        impassableCells.AddRange(edgeCells);

        //Записываем позицию игрока в список непроходимых и занятых клеток
        impassableCells.Add(playerPosition);
        occupiedCells.Add(playerPosition);

        //Перебираем все дочерние объекты из родительского объекта врагов для записи координат в лист
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

        //Перебираем все дочерние объекты из родительского объекта статичных объектов для записи координат в лист
        foreach (Transform obj in parentStaticObject.transform)
        {
            if (obj != null)
            {
                occupiedCells.Add(obj.GetComponent<BaseObject>().coordinate);
                impassableCells.Add(obj.GetComponent<BaseObject>().coordinate);
            }
        }

        //Перебираем все дочерние объекты из родительского объекта подбираемых объектов для записи координат в лист
        foreach (Transform obj in parentPickUpObject.transform)
        {
            if (obj != null)
            {
                occupiedCells.Add(obj.GetComponent<BaseObject>().coordinate);
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
        if(player != null)
        {
            WorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition); //Берем координаты мировые на сцене
            CellPosition = tileMap.WorldToCell(WorldPosition); //Переводим мировые координаты в координаты на тайлмапе
        }
    }
}