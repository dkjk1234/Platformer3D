using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] GameObject SettingPopup;

    [SerializeField] GameObject Sound_On;
    [SerializeField] GameObject Sound_Off;
    [SerializeField] AudioSource BG_audio;
    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SettingPopup.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
        }
    }
    public void OnClick_SettingBtn(bool isActive)
    {
        SettingPopup.SetActive(isActive);
    }
    public void Click_Sound(bool isSound)
    {
        if (isSound)
        {
            Sound_Off.SetActive(false);
            Sound_On.SetActive(true);
            BG_audio.volume = 0.3f;
        }
        else
        {
            Sound_Off.SetActive(true);
            Sound_On.SetActive(false);
            BG_audio.volume = 0;
        }
    }

}
