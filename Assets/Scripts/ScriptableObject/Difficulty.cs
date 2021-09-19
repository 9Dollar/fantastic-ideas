using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Difficulty", menuName = "Difficulty")]
public class Difficulty : ScriptableObject
{
    public float difficulty = 5;//처음 난이도

    public float MaxDifficulty = .5f; //얼마까지 어려워지는지

    public float MinusDifficulty = .1f; //어려워지는속도(?)

    public int UpScore = 5; //피할때마다 얻는 점수
}
