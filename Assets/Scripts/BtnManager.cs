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
    //    Debug.Log("��ŸƮ");
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
        Debug.Log("QUit��ư");
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
        Debug.Log("���� Ű��");
    }

    public void InGame_Sound_Off()
    {
        GameManager.instance.Click_Sound(false);
        Debug.Log("���� ����");
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
                Debug.Log("�ΰ��� ����");
                LoadingScene.LoadScene("InGame");
                break;
            case 3:
                Debug.Log("���ӹ������ �޴��� �̵�");
                LoadingScene.LoadScene("Title");
                break;
        }
    }
}
