using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInfo : MonoBehaviour
{
    //����������� ������ ������� ����� ���������� ��� ������ ������
    public static int melee = 1; //�������� 
    public static int range = 1; //��������
    public static int captain = 1; //��������
    public static int wizard = 0; //�������

    //����������� ��������� �������� ������� ����� ���������� ��� ������ ������
    public static int wall = 5; //�����
    public static int trap = 2; //�������
    public static int pit = 30; //���

    //����������� ����������� �������� ������� ����� ���������� ��� ������ ������
    public static int food = 3; //���
    public static int money = 0; //������
    public static int crystal = 0; //���������
}
