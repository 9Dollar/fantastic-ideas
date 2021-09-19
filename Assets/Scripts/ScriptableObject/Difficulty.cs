using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Difficulty", menuName = "Difficulty")]
public class Difficulty : ScriptableObject
{
    public float difficulty = 5;//ó�� ���̵�

    public float MaxDifficulty = .5f; //�󸶱��� �����������

    public float MinusDifficulty = .1f; //��������¼ӵ�(?)

    public int UpScore = 5; //���Ҷ����� ��� ����
}
