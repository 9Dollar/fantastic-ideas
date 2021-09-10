using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : MonoBehaviour
{
    public GameObject Box;
    public GameObject Warning;

    void OnDisable()
    {
        ObjectPooler.ReturnToPool(gameObject);  // �� ��ü�� �ѹ���
        CancelInvoke();    // Monobehaviour�� Invoke�� �ִٸ�
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("����");
    }
}
