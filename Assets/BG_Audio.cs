using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_Audio : MonoBehaviour
{
    private void Awake()
    {
        var objs = FindObjectsOfType<BG_Audio>();
        if (objs.Length ==1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
