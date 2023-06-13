using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialObject : MonoBehaviour
{
    public Transform targetPosition; // 특정 지점
    public float speed = 1f; // 이동 속도
    public LayerMask specialObjectLayer; // 특정 오브젝트의 레이어

    public int objectCount = 0; // 충돌한 특정 오브젝트 수
    private bool isMoving = false; // 오브젝트가 움직이는지 확인하는 플래그

    private void OnTriggerEnter(Collider other)
    {
        // 특정 레이어의 오브젝트와 충돌한 경우 카운터 증가
        if (((1 << other.gameObject.layer) & specialObjectLayer) != 0)
        {
            objectCount++;
        }

        // 충돌한 특정 오브젝트가 5개인 경우
        if (objectCount >= 5 && !isMoving)
        {
            isMoving = true; // 움직이는 상태로 변경
            StartCoroutine(MoveToTarget()); // 코루틴 시작
        }
    }

    private IEnumerator MoveToTarget()
    {
        // 현재 위치에서 목표 위치까지 부드럽게 이동
        while (Vector3.Distance(transform.position, targetPosition.position) > 0.01f)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition.position, speed * Time.deltaTime);
            yield return null;
        }
        // 목표 위치에 도착했다면 정확히 목표 위치로 이동
        transform.position = targetPosition.position;
    }
}