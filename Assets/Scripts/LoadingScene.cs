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
        // 질문. Q. 왜 BG_Num에서 0의 값이 나오는가?
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
                // 질문. Q. 씬 넘어가는거 너무 빨리 넘어가는데 어떻게 조절하는가? || 답.  unscaledDeltaTime이 아닌 deltaTime을 사용하고 실제 시간에 관여 x 
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
