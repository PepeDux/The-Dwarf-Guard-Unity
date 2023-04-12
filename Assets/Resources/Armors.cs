using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Armor", order = 51)]
public class Armors : EquipmentData
{
    [Header("“ип брони")]
    //”казывает на то какой это тип брони(шлЄм, нагрудник, впрежки, ботиночки)
    [SerializeField] public string armorType;
    public string ArmorType { get => armorType; }




}
