using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SocialPlatforms;

public class Player : MainObject
{    
    private bool isFacingRight = true;


    private void Start()
    {
        Starter();
    }
    private void Update()
    {
        Updater();
        MoveOrientation(); //Отвечает за передвижение персонажа и его направление
    }

    void MoveOrientation()
    {
        if (TileManager.WorldPosition.x < GetComponent<Player>().transform.position.x && isFacingRight == true)
        {
            Flip();
        }
        else if (TileManager.WorldPosition.x > GetComponent<Player>().transform.position.x && isFacingRight == false)
        {
            Flip();
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        //получаем размеры персонажа
        Vector3 theScale = transform.localScale;
        //зеркально отражаем персонажа по оси Х
        theScale.x *= -1;
        //задаем новый размер персонажа, равный старому, но зеркально отраженный
        transform.localScale = theScale;
    }

}

