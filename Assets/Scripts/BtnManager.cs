using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnManager : MonoBehaviour
{
    int SceneNum;

    private void Start()
    {
        //   StartCoroutine(Start_Scene_Move());
    }
    //public void Title_Start()
    //{
    //    Debug.Log("스타트");
    //    SceneNum = 1;
    //    StartCoroutine(Scene_Move());

    //}
    public void Title_HowtoPlay()
    {
        SceneNum = 2;
        StartCoroutine(Scene_Move());
    }

    public void Title_Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif 
        Application.Quit();
    }
    public void InGame_Quit()
    {
        Debug.Log("QUit버튼");
        Time.timeScale = 1;
        SceneNum = 3;
        StartCoroutine(Scene_Move());
    }
    public void InGame_SettingBtn()
    {
        GameManager.instance.OnClick_SettingBtn(true);
        Time.timeScale = 0;
    }
    public void InGame_Cancel()
    {
        GameManager.instance.OnClick_SettingBtn(false);
        Time.timeScale = 1;
    }

    public void InGame_Sound_On()
    {
        GameManager.instance.Click_Sound(true);
        Debug.Log("사운드 키기");
    }

    public void InGame_Sound_Off()
    {
        GameManager.instance.Click_Sound(false);
        Debug.Log("사운드 끄기");
    }


    IEnumerator Start_Scene_Move()
    {
        yield return new WaitForSeconds(7f);
        LoadingScene.LoadScene("InGame");
    }

    IEnumerator Scene_Move()
    {
        yield return new WaitForSeconds(0.5f);
        switch (SceneNum)
        {
            case 1:
                Debug.Log("인게임 입장");
                LoadingScene.LoadScene("InGame");
                break;
            case 3:
                Debug.Log("게임방법에서 메뉴로 이동");
                LoadingScene.LoadScene("Title");
                break;
        }
    }
}
