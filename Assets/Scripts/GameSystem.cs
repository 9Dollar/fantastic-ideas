using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSystem : MonoBehaviour
{
    //게임설정
    public Difficulty difficulty;
    public Transform player;

    //게임 데이터
    public static long Score;

    //UI
    public Text ScoreText;

    //충돌효과
    public Animator CamCrash;
    public Animator RedCrash;
    void Start()
    {
        StartCoroutine("YesMan");
        StartCoroutine("ScoreUp");
    }

    IEnumerator YesMan()
    {
        yield return new WaitForSeconds(difficulty.difficulty);
        ObjectPooler.SpawnFromPool("box", new Vector2(Random.Range(-8, 9), 0), Quaternion.identity);
        Score += difficulty.UpScore;

        yield return new WaitForSeconds(difficulty.difficulty - difficulty.difficulty * .5f);
        ObjectPooler.SpawnFromPool("box", new Vector2(player.position.x, 0), Quaternion.identity);
        Score += difficulty.UpScore;
        ScoreText.text = "Score:" + Score;
        StartCoroutine("YesMan");
        if (difficulty.difficulty <= difficulty.MaxDifficulty)
        {
            difficulty.difficulty = difficulty.MaxDifficulty;
        }
        else
        {
            difficulty.difficulty -= difficulty.MinusDifficulty;
        }
    }
    IEnumerator ScoreUp()
    {
        yield return new WaitForSeconds(1);
        Score += 1;
        ScoreText.text = "Score:" + Score;
        StartCoroutine("ScoreUp");
    }
    private void Update()
    {
        ScoreText.text = "Score:" + Score;
    }
    public void Crash()
    {
        CamCrash.SetTrigger("Warning");
        RedCrash.SetTrigger("Warning");
    }

}
