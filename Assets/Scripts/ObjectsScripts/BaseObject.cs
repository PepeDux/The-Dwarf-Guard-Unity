using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BaseObject : MonoBehaviour
{
    [Header("Тайлмап и прочее")]
    public Vector3Int coordinate;
    public Tilemap tileMap;

    public void UpdateCoordinate()
    {
        transform.position = tileMap.CellToWorld(coordinate); //Привязываем координаты объекта к мировым координатам
        transform.Translate(0.25f, 0.25f, 0); //Корректтируем координаты (Возможно в будущем может быть убрано)



        //Если координата объекта оказываектся за пределами границ поля,
        //то его телепортирует на максимально возможное в пределах поля значение координаты по одной из осей
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

    public virtual void Updater()
    {
        UpdateCoordinate();
    }

    public void FindTileMap()
    {
        tileMap = GameObject.Find("Ground").GetComponent<Tilemap>();
    }
}
