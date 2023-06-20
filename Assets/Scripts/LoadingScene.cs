using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{
    static string nextScene;
    public Image progressBar;
    public GameObject[] Loading_Text;
    int Text_Num;
    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("LoadingScene");
        
    }
    void Start()
    {
        // 1~3 
        // ����. Q. �� BG_Num���� 0�� ���� �����°�?
        Time.timeScale = 1;
        Text_Num = Random.Range(0, 2);
        StartCoroutine(LoadSceneProcess());
    }

    // Update is called once per frame
    void Update()
    {
    }
    IEnumerator LoadSceneProcess()
    {
        Loading_Text[Text_Num].SetActive(true);

        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;

        float timer = 0f;
        while (!op.isDone)
        {
            yield return null;
            if (op.progress < 0.9f)
            {
                progressBar.fillAmount = op.progress;
            }
            else
            {
                // ����. Q. �� �Ѿ�°� �ʹ� ���� �Ѿ�µ� ��� �����ϴ°�? || ��.  unscaledDeltaTime�� �ƴ� deltaTime�� ����ϰ� ���� �ð��� ���� x 
                timer += Time.deltaTime;
                progressBar.fillAmount = Mathf.Lerp(0.9f, 1f, timer);
                if (progressBar.fillAmount >= 1f)
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }
        Loading_Text[Text_Num].SetActive(false);
    }
}
