using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Armor", menuName = "Armor", order = 51)]
public class ArmorData : EquipmentData
{
    [Header("��� �����")]
    //��������� �� �� ����� ��� ��� �����(���, ���������, �������, ���������, �����)
    [SerializeField] public string armorType;
    public string ArmorType { get => armorType; }




}
