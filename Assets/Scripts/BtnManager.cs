using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnManager : MonoBehaviour
{
    int SceneNum;

    private void Start()
    {
        StartCoroutine(Start_Scene_Move());
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

    IEnumerator Start_Scene_Move()
    {
        yield return new WaitForSeconds(2f);
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
            case 2:
                Debug.Log("���� ��� �� ����");
                LoadingScene.LoadScene("HowtoPlay");
                break;
            case 3:
                Debug.Log("���ӹ������ �޴��� �̵�");
                LoadingScene.LoadScene("Title");
                break;
        }
    }
}
