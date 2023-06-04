using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;
using Game.Trigger;

namespace Assets.Game.Scripts.Game.MainRoom.Miller
{
    public class MillerDay1 : DayProgress
    {
        public GameObject[] Guides;
        public TriggerBubble[] Triggers;
        public GameObject EpiCha;
        public DialogueController EpilogueDia;
        public FadeIllust EpilogueCut;

        private void Start()
        {
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
                EpiCha.SetActive(true);
                EpilogueDia.gameObject.SetActive(true);
                EpilogueDia.Show();
                yield return new WaitUntil(() => EpilogueDia.isEndDialogue == true);
                yield return EpilogueCut.FadeIn();
                GameManager.Instance.CurruntDay++;
                GameManager.Instance.CanDreamComplete = false;
                GameManager.Instance.SceneController.LoadScene(SceneController.SceneName.MainRoom);
            }
        }
    }
}