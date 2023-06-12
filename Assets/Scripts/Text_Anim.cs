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
        InvokeRepeating("ToggleTextVisibility", 0f, 0.5f); // 0.5초마다 ToggleTextVisibility() 함수 호출
    }

    void ToggleTextVisibility()
    {
        textComponent.enabled = !textComponent.enabled; // 텍스트의 활성/비활성 상태를 반전시킴
    }
}
