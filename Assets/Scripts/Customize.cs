using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Customize : MonoBehaviour
{
    // 오브젝트의 충돌체

    private Collider _collide;



    // 현재 좌표

    private Vector3 _curPosition;

    // 목표 좌표

    private Vector3 _direction;



    // 마우스와 오브젝트가 충돌했는지 체크

    private bool _isTrigger = false;



    void Start()
    {

        // 오브젝트의 충돌체를 가져옴

        _collide = GetComponent<Collider>();

    }



    IEnumerator OnMouseDown()

    {

        // 오브젝트의 월드 좌표를 스크린 좌표로 변환

        Vector3 scrSpace = Camera.main.WorldToScreenPoint(transform.position);



        // 오브젝트 월드벡터 - 마우스 월드벡터 (벡터끼리의 차는 서로의 거리와 방향을 뜻함. 여기서는 마우스에서 오브젝트까지의 벡터)

        Vector3 offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, scrSpace.z));



        // 마우스를 누르고 있을때 루프

        while (Input.GetMouseButton(0))

        {

            // 현재 마우스의 스크린좌표

            Vector3 curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, scrSpace.z);



            // 마우스 벡터 + 마우스->오브젝트 벡터 = 마우스 월드 좌표

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



            // MoveTowards : 처음 위치에서 목표 위치까지 이동하는 함수

            transform.position = Vector3.MoveTowards(transform.position, _curPosition, step);

        }



        // 초기화

        if (transform.position == _curPosition)

        {

            _isTrigger = false;

        }

    }


}