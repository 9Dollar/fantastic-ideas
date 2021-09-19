using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Customize : MonoBehaviour
{
    // ������Ʈ�� �浹ü

    private Collider _collide;



    // ���� ��ǥ

    private Vector3 _curPosition;

    // ��ǥ ��ǥ

    private Vector3 _direction;



    // ���콺�� ������Ʈ�� �浹�ߴ��� üũ

    private bool _isTrigger = false;



    void Start()
    {

        // ������Ʈ�� �浹ü�� ������

        _collide = GetComponent<Collider>();

    }



    IEnumerator OnMouseDown()

    {

        // ������Ʈ�� ���� ��ǥ�� ��ũ�� ��ǥ�� ��ȯ

        Vector3 scrSpace = Camera.main.WorldToScreenPoint(transform.position);



        // ������Ʈ ���庤�� - ���콺 ���庤�� (���ͳ����� ���� ������ �Ÿ��� ������ ����. ���⼭�� ���콺���� ������Ʈ������ ����)

        Vector3 offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, scrSpace.z));



        // ���콺�� ������ ������ ����

        while (Input.GetMouseButton(0))

        {

            // ���� ���콺�� ��ũ����ǥ

            Vector3 curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, scrSpace.z);



            // ���콺 ���� + ���콺->������Ʈ ���� = ���콺 ���� ��ǥ

            _curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;



            yield return null;

        }



    }



    void OnMouseUp()

    {

        _isTrigger = true;

    }



    void Update()

    {

        if (_isTrigger)

        {

            float step = 5 * Time.deltaTime;



            // MoveTowards : ó�� ��ġ���� ��ǥ ��ġ���� �̵��ϴ� �Լ�

            transform.position = Vector3.MoveTowards(transform.position, _curPosition, step);

        }



        // �ʱ�ȭ

        if (transform.position == _curPosition)

        {

            _isTrigger = false;

        }

    }


}