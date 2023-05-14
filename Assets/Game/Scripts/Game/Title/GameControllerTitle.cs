using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Transition;

namespace Game.Title
{
    public class GameControllerTitle : GameController
    {
        [Header("Prevate Reference")]
        [SerializeField]
        ZoomEffect zoomEffect;
        public AudioClip[] clips;
        public AudioSource SFX_Audio;
        [Header("Private Setting")]
        private bool isEnd;

        private void Start()
        {
            GameManager.Instance.BGM_Audio.clip = clips[0];
            GameManager.Instance.BGM_Audio.Play();
            zoomEffect.SetEffect();
            SFX_Audio.clip = clips[1];
        }

        #region StartButton
        public void ExcuteStartButton()
        {
            SFX_Audio.Play();
            StartCoroutine(ExcuteStart());
        }

        private IEnumerator ExcuteStart()
        {
            yield return zoomEffect.RunZoomIn();
            yield return new WaitForSeconds(0.1f);
            LoadScene();
        }

        #endregion

    }
}