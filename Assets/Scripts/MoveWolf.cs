using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWolf : MonoBehaviour
{
    public GameObject Wolf;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Animal")
        {
            Wolf.transform.position = new Vector3(-177, 4.5f , 42);
        }
    }
}
