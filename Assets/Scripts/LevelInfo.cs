using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInfo : MonoBehaviour
{
    [Header("����� �� ������")]
    //����������� ������ ������� ����� ���������� ��� ������ ������
    public int melee; //�������� 
    public int range; //��������
    public int captain; //��������
    public int wizard; //�������

    [Header("��������� �������")]
    //����������� ��������� �������� ������� ����� ���������� ��� ������ ������
    public int wall; //�����
    public int pit; //���

    [Header("�������������� �������")]
    public int trap; //�������
    public int food; //���
    public int money; //������
    public int crystal; //���������
}
