using Febucci.UI.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ax;
    private void Start()
    {
        ax = GameObject.FindWithTag("QuestItem");
    }
    public void isAxCheck()
    {
        if(ax.GetComponent<Collider>().enabled == false)
        {
            FindAnyObjectByType<TextAnimManager>().QuestSuccess();
            ax.GetComponent<Collider>().enabled = false;
            ax.transform.position = new Vector3(-180.735992f, -0.263000011f, 91.9179993f);
            ax.transform.rotation = Quaternion.identity;
            ax.transform.parent = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
