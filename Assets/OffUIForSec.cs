using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffUIForSec : MonoBehaviour
{
    public float waitSec = 5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(OffUi(waitSec));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator OffUi(float waitSec)
    {
        yield return new WaitForSeconds(waitSec);
        transform.gameObject.SetActive(false);
    }
}
