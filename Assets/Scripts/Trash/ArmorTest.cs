using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<WeaponCalculation>().currentWeapon = GetComponent<Player>().currentWeapon.name;
    }

    // Update is called once per frame
    void Update()
    {
        ArmorChange();
    }


    void ArmorChange()
    {
        if (Input.GetKeyDown("0"))
        {

            GetComponent<ArmorCalculation>().currentArmor = null;
            GetComponent<ArmorCalculation>().lastArmor = GetComponent<Player>().headArmor.name;
            



        }
    }
}
