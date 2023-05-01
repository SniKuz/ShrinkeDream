using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Transition;

namespace Game.Logo
{
    public class GameControllerLogo : GameController
    {
        [Header("Prevate Reference")]
        [SerializeField]
        LogoTransition logoTransition;
        [Header("Private Setting")]
        public float fadeTime;

        private void Start()
        {
            Excute();
        }

        protected override IEnumerator ExcuteProcess()
        {

            yield return logoTransition.FadeOut();

            LoadScene();
        }
    }
}