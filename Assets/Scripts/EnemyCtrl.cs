using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Animal")
        {
            GameManager.instance.player_HP.fillAmount -= 0.2f;
            Debug.Log(GameManager.instance.player_HP.fillAmount);
        }
    }
}
