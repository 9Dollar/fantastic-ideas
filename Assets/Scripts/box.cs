using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : MonoBehaviour
{
    public GameObject Box;
    public GameObject Warning;

    public bool isCrash;
    public float Size;
    public LayerMask Layer;
    void OnDisable()
    {
        ObjectPooler.ReturnToPool(gameObject);  // 한 객체에 한번만
        CancelInvoke();    // Monobehaviour에 Invoke가 있다면
    }
    private void OnEnable()
    {
        Warning.SetActive(true);
        StartCoroutine("enableBox");
    }
    private void Start()
    {
        Warning.SetActive(true);
        StartCoroutine("enableBox");
    }
    IEnumerator enableBox()
    {
        yield return new WaitForSeconds(2);
        Box.SetActive(true);
        Warning.SetActive(false);
        yield return new WaitForSeconds(2);
        Box.SetActive(false);
        gameObject.SetActive(false);
    }
    //충돌구현

    /*private void Update()
    {
        Collider2D crashObj = Physics2D.OverlapBox(Box.transform.position, new Vector2(Size, Size),0);
        if(crashObj != null)
        Debug.Log(1);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(Box.transform.position, new Vector2(Size, Size));
    }*/
}
