using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HpBarController : MonoBehaviour
{
    public float healthValue;
    Image bar;
    

    // Start is called before the first frame update
    void Start()
    {
        bar = GetComponent<Image>();
    }
    public void SetHealthValue(float value)
    {
        healthValue = value;
    }

    // Update is called once per frame
    void Update()
    {
        bar.fillAmount = healthValue/100;
    }
}
