using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevelInfo : MonoBehaviour
{
    [Header("����� �� ������")]
    //����������� ������ ������� ����� ���������� ��� ������ ������
    public int melee = 1; //�������� 
    public int range = 1; //��������
    public int captain = 1; //��������
    public int wizard = 0; //�������

    [Header("��������� �������")]
    //����������� ��������� �������� ������� ����� ���������� ��� ������ ������
    public int wall = 5; //�����
    public int pit = 3; //���

    [Header("�������������� �������")]
    public int trap = 2; //�������
    public int food = 3; //���
    public int money = 0; //������
    public int crystal = 0; //���������
}
