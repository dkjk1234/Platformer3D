using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringRotator : MonoBehaviour
{
    public float rotationSpeed = 50f; // 회전 속도를 설정합니다. 원하는 속도로 조절 가능합니다.
    public int rotateXYZNumState = 0;
    public bool isReverse = false;

    void Update()
    {
        if(rotateXYZNumState == 0)
        transform.Rotate( rotationSpeed * Time.deltaTime * (isReverse ? 1 : -1),0,1, 0); // X 축을 중심으로 회전합니다.
        if(rotateXYZNumState == 1)
            transform.Rotate( 0,rotationSpeed * Time.deltaTime * (isReverse ? 1 : -1), 0); // Y 축을 중심으로 회전합니다.
        if(rotateXYZNumState == 2)
            transform.Rotate( 0,0, rotationSpeed * Time.deltaTime * (isReverse ? 1 : -1)); // Z 축을 중심으로 회전합니다.


    }
}

