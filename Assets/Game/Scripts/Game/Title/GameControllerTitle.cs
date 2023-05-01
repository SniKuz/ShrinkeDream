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
        [Header("Private Setting")]
        private bool isEnd;

        private void Start()
        {
            zoomEffect.SetEffect();
        }

        #region StartButton
        public void ExcuteStartButton()
        {
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