using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialObject : MonoBehaviour
{
    public Transform targetPosition; // Ư�� ����
    public float speed = 1f; // �̵� �ӵ�
    public LayerMask specialObjectLayer; // Ư�� ������Ʈ�� ���̾�

    public int objectCount = 0; // �浹�� Ư�� ������Ʈ ��
    private bool isMoving = false; // ������Ʈ�� �����̴��� Ȯ���ϴ� �÷���

    private void OnTriggerEnter(Collider other)
    {
        // Ư�� ���̾��� ������Ʈ�� �浹�� ��� ī���� ����
        if (((1 << other.gameObject.layer) & specialObjectLayer) != 0)
        {
            objectCount++;
        }

        // �浹�� Ư�� ������Ʈ�� 5���� ���
        if (objectCount >= 5 && !isMoving)
        {
            isMoving = true; // �����̴� ���·� ����
            StartCoroutine(MoveToTarget()); // �ڷ�ƾ ����
        }
    }

    private IEnumerator MoveToTarget()
    {
        // ���� ��ġ���� ��ǥ ��ġ���� �ε巴�� �̵�
        while (Vector3.Distance(transform.position, targetPosition.position) > 0.01f)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition.position, speed * Time.deltaTime);
            yield return null;
        }
        // ��ǥ ��ġ�� �����ߴٸ� ��Ȯ�� ��ǥ ��ġ�� �̵�
        transform.position = targetPosition.position;
    }
}