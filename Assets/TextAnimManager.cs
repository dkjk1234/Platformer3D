using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Febucci.UI.Examples
{
    public class TextAnimManager : MonoBehaviour
    {
        public Image wolf;
        public Image human;
        public float fadeInTime = 1f;
        private AudioSource chatSound;
        public bool isQuest = false;
        private List<string> dialogueList = new List<string>()
        {
            "[나무꾼] 안녕, 꼬마야. 무슨 일로 이 숲을 돌아다니고 있니?",
            "[늑대] 가족들과 함께 길을 가던 중 절벽에서 떨어져 가족들을 찾으러 가는 길이었어요.",
            "[나무꾼] 절벽에서 떨어졌다고?!?!?",
            "[나무꾼] 어디 다친 곳은 없었니?",
            "[늑대] 괜찮아요. 신기하게도 몸에 아무 상처 없어요!",
            "[나무꾼] 그거 참 신기하구나.",
            "[늑대] 아저씨는 여기서 뭘 하고 계셨어요?",
            "[나무꾼] 나무를 베던 중에 급하게 볼 일이 생겨 오두막에 갔다왔는데",
            "[나무꾼] 나무를 베던 도끼가 없어져서 도끼를 찾고 있던 참이었지.",
            "[늑대] 그건 정말 곤란하시겠어요...",
            "[늑대] 제가 도끼를 찾는 걸 도와드릴게요!",
            "[나무꾼] 고맙구나. 나는 이 근방에서 계속 찾아볼 테니 너는 절벽 쪽으로 가서 찾아보도록 해.",
            "[늑대] 알겠어요!",
            "[늑대] 여기 도끼를 찾았어요!",
            "[나무꾼] 아이고, 고맙다 꼬마야. 이 은혜를 어떻게 갚아야 할지...",
            "[늑대] 아니에요, 다같이 돕고 돕는 세상인데요. 뭘~",
            "[나무꾼] 정말 고맙구나. 가족을 찾으러 절벽을 올라가야 한다고 했었지?",
            "[나무꾼] 왼쪽에 절벽을 타고 조심히 올라가면 될 거야.",
            "[늑대] 감사합니다, 아저씨! 다음에 또 뵈요."
        };
        private int dialogueIndex = 0;

        public TextAnimatorPlayer tanimPlayer;

        string textToSet;
        private bool isImage1Active = true;

        private void Awake()
        {
            UnityEngine.Assertions.Assert.IsNotNull("TextAnimator: The object 'SetTextOnEnable' has no TextAnimatorPlayer component reference.");

            textToSet = tanimPlayer.textAnimator.tmproText.text;
            
        }

        private void Start()
        {
            tanimPlayer.ShowText(dialogueList[0]);
            wolf.color = new Color(1f, 1f, 1f, 0f);
            human.color = new Color(1f, 1f, 1f, 0f);
            StartCoroutine(FadeInImage(human));

        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                // 이미지 전환
                NextDialogue();
                //SwitchImages();
            }
        }

        public void ChatSoundPlay()
        {
            //chatSound.PlayOneShot(chatSound.clip);
            //Debug.Log("ssss");
        }
        private void NextDialogue()
        {
            dialogueIndex++;
            tanimPlayer.StopShowingText();
            
            if (dialogueIndex >= dialogueList.Count)
            {
                // 대화 종료
                EndDialogue();
            }
            else
            {
                DisplayDialogue();
            }
        }
        
        private void DisplayDialogue()
        {
            string dialogue = dialogueList[dialogueIndex];
            tanimPlayer.StopShowingText();
            tanimPlayer.ShowText(dialogue);
            if (dialogue.Contains("[나무꾼]") && human.color.a < 0.5f)
            {
                StartCoroutine(FadeInImage(human));
                StartCoroutine(FadeOutImage(wolf));
            }
            else if (dialogue.Contains("[늑대]") && wolf.color.a < 0.5f)
            {
                StartCoroutine(FadeInImage(wolf));
                StartCoroutine(FadeOutImage(human));
            }

            //Debug.Log(dialogue);
        }

        private void EndDialogue()
        {
            //Debug.Log("대화 종료");
        }
        
        IEnumerator FadeInImage(Image img)
        {
            for (float t = 0.01f; t < fadeInTime; t += Time.deltaTime)
            {
                img.color = new Color(1f, 1f, 1f, Mathf.Lerp(0f, 1f, t / fadeInTime));
                yield return null;
            }
            img.color = new Color(1f, 1f, 1f, 1f);
        }

        IEnumerator FadeOutImage(Image img)
        {
            for (float t = 0.01f; t < fadeInTime; t += Time.deltaTime)
            {
                img.color = new Color(1f, 1f, 1f, Mathf.Lerp(1f, 0f, t / fadeInTime));
                yield return null;
            }
            img.color = new Color(1f, 1f, 1f, 0f);
        }
    }
}



