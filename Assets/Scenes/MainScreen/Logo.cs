using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EndLogo(SceneManager.GetActiveScene().buildIndex + 1));
    }
    IEnumerator EndLogo(int levelIndex)
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(levelIndex);
    }
}
