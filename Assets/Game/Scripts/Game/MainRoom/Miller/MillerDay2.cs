using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;
using Game.Trigger;

namespace Assets.Game.Scripts.Game.MainRoom.Miller
{
    public class MillerDay2 : DayProgress
    {
        public GameObject[] Guides;
        public TriggerBubble[] Triggers;
        public GameObject EpiCha;
        public DialogueController EpilogueDia;
        public FadeIllust EpilogueCut;

        bool isInit = false;

        private void Start()
        {
            // 2번째 씬 로드부터 Start 생성이 매우 늦는 문제로 인해(구조적 결함)
            if (!isInit)
                Init();
        }

        private void Init()
        {
            isInit = true;
            EpiCha.SetActive(false);
            EpilogueDia.gameObject.SetActive(false);
            EpilogueCut.gameObject.SetActive(false);
            foreach (GameObject obj in Guides)
            {
                obj.SetActive(false);
            }
            foreach (TriggerBubble obj in Triggers)
            {
                obj.SetActive(false);
            }
        }

        protected override IEnumerator Excute()
        {
            Init();

            if (!GameManager.Instance.CanDreamComplete)
            {
                // miller 방문 가이드
                yield return new WaitForSeconds(1.0f);
                Guides[0].SetActive(true);
                // miller 방문
                Triggers[0].SetActive(true);
                yield return new WaitUntil(() => Triggers[0].isEndEvent == true);

                // miller 대화 트리거 on
                Triggers[1].SetActive(true);
                yield return new WaitUntil(() => Triggers[1].isEndEvent == true);

                // Dream 트리거 On
                //GameManager.Instance.CurruntDay = 1;
                Guides[1].SetActive(true);
                Triggers[2].SetActive(true);
            }
            else
            {
                // 테스트버젼
                GameManager.Instance.SceneController.PreloadScene("EndGame");
                //
                
                EpiCha.SetActive(true);
                EpilogueDia.gameObject.SetActive(true);
                EpilogueDia.Show();
                yield return new WaitUntil(() => EpilogueDia.isEndDialogue == true);
                yield return EpilogueCut.FadeIn();
                GameManager.Instance.CurruntDay++;
                //GameManager.Instance.SceneController.LoadScene(SceneController.SceneName.MainRoom);

                // 테스트 버젼 끝
                GameManager.Instance.BGM_Audio.Pause();
                GameManager.Instance.SceneController.PlayPreloadScene();
            }
        }
    }
}