using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card", order = 51)]
public class CardData : ScriptableObject
{
    [Header("��������")]
    //�������� �����
    [SerializeField] public string cardDescription;
    public string CardDescription { get => cardDescription; }



    [Header("�����������")]
    //�����������
    [SerializeField] public ScriptableObject modifier;
    public ScriptableObject Modifier { get => modifier; }


    [Header("��� �����")]
    //��� �����
    public Type type;
    public enum Type { positive, negative };

    [Header("���������� ���")]
    //��� �����
    public Accessory accessory;
    public enum Accessory { player, enemy, global };
}
