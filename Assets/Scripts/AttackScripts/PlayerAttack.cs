using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : AttackScript
{
    void Update()
    {
        if (Input.GetMouseButton(0) && GetComponent<Player>().actionPoints >= GetComponent<Player>().meleeAttackCost) 
        {
            foreach(var target in TileManager.enemyList)
            {
                if(TileManager.CellPosition == target.coordinate)
                {
                    CalculationAttack(target);
                }
            }
        }
    }
}
