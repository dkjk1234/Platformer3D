using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text_Anim : MonoBehaviour
{
    private Text textComponent;
    void Start()
    {
        textComponent = GetComponent<Text>();
        InvokeRepeating("ToggleTextVisibility", 0f, 0.5f); // 0.5�ʸ��� ToggleTextVisibility() �Լ� ȣ��
    }

    void ToggleTextVisibility()
    {
        textComponent.enabled = !textComponent.enabled; // �ؽ�Ʈ�� Ȱ��/��Ȱ�� ���¸� ������Ŵ
    }
}
