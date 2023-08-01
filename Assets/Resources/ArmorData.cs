using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Armor", menuName = "Armor", order = 51)]
public class ArmorData : EquipmentData
{
    [Header("“ип брони")]
    //”казывает на то какой это тип брони(шлЄм, нагрудник, впрежки, ботиночки, штаны)
    [SerializeField] public string armorType;
    public string ArmorType { get => armorType; }




}
