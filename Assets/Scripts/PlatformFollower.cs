using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFollower : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "RotatingPlatform") // 움직이는 오브젝트의 태그가 'RotatingPlatform'인 경우
        {
            this.transform.parent = other.transform; // 이 오브젝트의 부모를 움직이는 오브젝트로 설정합니다.
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "RotatingPlatform") // 움직이는 오브젝트의 태그가 'RotatingPlatform'인 경우
        {
            this.transform.parent = null; // 이 오브젝트의 부모를 null로 설정합니다. 즉, 부모-자식 관계를 해제합니다.
        }
    }
}
