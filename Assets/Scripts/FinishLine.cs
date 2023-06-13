using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Animal")
        {
            StartCoroutine(Scene_Move());
        }
    }

    IEnumerator Scene_Move()
    {
        yield return new WaitForSeconds(0.5f);
        LoadingScene.LoadScene("Title");
    }
}
