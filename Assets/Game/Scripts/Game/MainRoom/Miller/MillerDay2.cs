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
            // 2��° �� �ε���� Start ������ �ſ� �ʴ� ������ ����(������ ����)
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
                // miller �湮 ���̵�
                yield return new WaitForSeconds(1.0f);
                Guides[0].SetActive(true);
                // miller �湮
                Triggers[0].SetActive(true);
                yield return new WaitUntil(() => Triggers[0].isEndEvent == true);

                // miller ��ȭ Ʈ���� on
                Triggers[1].SetActive(true);
                yield return new WaitUntil(() => Triggers[1].isEndEvent == true);

                // Dream Ʈ���� On
                //GameManager.Instance.CurruntDay = 1;
                Guides[1].SetActive(true);
                Triggers[2].SetActive(true);
            }
            else
            {
                // �׽�Ʈ����
                GameManager.Instance.SceneController.PreloadScene("EndGame");
                //
                
                EpiCha.SetActive(true);
                EpilogueDia.gameObject.SetActive(true);
                EpilogueDia.Show();
                yield return new WaitUntil(() => EpilogueDia.isEndDialogue == true);
                yield return EpilogueCut.FadeIn();
                GameManager.Instance.CurruntDay++;
                //GameManager.Instance.SceneController.LoadScene(SceneController.SceneName.MainRoom);

                // �׽�Ʈ ���� ��
                GameManager.Instance.BGM_Audio.Pause();
                GameManager.Instance.SceneController.PlayPreloadScene();
            }
        }
    }
}