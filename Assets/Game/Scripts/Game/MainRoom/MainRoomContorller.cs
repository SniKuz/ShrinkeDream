using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Transition;
using Game;

namespace Game.MainRoom
{
    public class MainRoomContorller : MonoBehaviour
    {
        [Header("Audio")]
        public AudioClip[] clips;
        [Header("Reference")]
        public MemoContorller MemoContorller;
        public ChapterUI chaptuerUI;
        [Header("Render")]
        public GameObject DreamChangePrefab;
        private float dreamTime = 1.0f;
        [Header("DayProgress")]
        public GameObject[] dayProgress;

        private void Start()
        {
            GameManager.Instance.BGM_Audio.clip = clips[0];
            GameManager.Instance.BGM_Audio.Play();
            if (dayProgress.Length > 0)
            {
                dayProgress[GameManager.Instance.CurruntDay].GetComponent<DayProgress>();
            }
        }

        #region DreamChange
        public void DreamChange()
        {
            if (DreamChangePrefab == null) return;

            Instantiate(DreamChangePrefab);
            dreamTime = DreamChangePrefab.GetComponent<DreamChangeRander>().FadeTime;
            StartCoroutine(IEDreamChange());
        }

        IEnumerator IEDreamChange()
        {
            yield return new WaitForSeconds(dreamTime);
            //Itemcount와 currentday를 받아서 Dream 추격 / 퍼즐 나눠서 넘어가는 기능으로 구현예정
            if (GameManager.Instance.ItemCount < 2) { 
                GameManager.Instance.SceneController.LoadScene("Dream");
            }
            else if (GameManager.Instance.ItemCount >= 2)
            {
                GameManager.Instance.SceneController.LoadScene("Dream2");
            }
        }
        #endregion
    }
}