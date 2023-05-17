using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Transition;
using Game;

namespace Game.MainRoom
{
    public class RoomContorller : MonoBehaviour
    {
        public SceneController SceneController;
        [Header("Audio")]
        public AudioClip[] clips;
        [Header("Reference")]
        public MemoContorller MemoContorller;
        public DialogueController DialogueController;
        [Header("Render")]
        public GameObject DreamChangePrefab;
        private float dreamTime = 1.0f;

        private void Start()
        {
            GameManager.Instance.BGM_Audio.clip = clips[0];
            GameManager.Instance.BGM_Audio.Play();
        }

        public void ShowDialogue()
        {
            DialogueController.Show();
        }

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
            GameManager.Instance.SceneController.LoadScene("Dream");
        }
    }
}