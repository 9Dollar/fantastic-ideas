using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSystem : MonoBehaviour
{
    //게임설정
    public Difficulty difficulty;
    Transform player;

    //게임 데이터
    public long Score;

    //UI
    public Text ScoreText;
    void Start()
    {
        StartCoroutine("YesMan");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    IEnumerator YesMan()
    {
        yield return new WaitForSeconds(difficulty.difficulty);
        ObjectPooler.SpawnFromPool("box", new Vector2(Random.Range(-8, 9), 0), Quaternion.identity);
        player = GameObject.FindWithTag("Player").transform;
        Score += 10;
        ScoreText.text = "Score:" + Score;
        yield return new WaitForSeconds(difficulty.difficulty - difficulty.difficulty * .5f);
        ObjectPooler.SpawnFromPool("box", new Vector2(player.position.x, 0), Quaternion.identity);
        Score += 10;
        ScoreText.text = "Score:" + Score;
        StartCoroutine("YesMan");
        if (difficulty.difficulty <= difficulty.MaxDifficulty)
        {
            difficulty.difficulty = difficulty.MaxDifficulty;
        }
        else
        {
            difficulty.difficulty -= 0.1f;
        }
    }

}
