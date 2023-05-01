using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Game.Cut
{
    public class GameControllerCut : GameController
    {
        [Header("Prevate Reference")]
        [SerializeField]
        GameObject[] cutObjects;
        [Header("Private Setting")]
        public float inputWaitTime;
        public float fadeTime;
        [SerializeField]
        private int currentCutIndex = 0;
        private bool isExcuting = true;
        private bool canInput = true;

        private WaitForSeconds InputWait => new WaitForSeconds(inputWaitTime);

        private void Start()
        {
            foreach (GameObject obj in cutObjects)
            {
                obj.TryGetComponent(out Image img);
                img.color = new Color(img.color.r, img.color.g, img.color.b, 0);
            }
            currentCutIndex = 0;

            Excute();
        }

        protected override IEnumerator ExcuteProcess()
        {
            while (isExcuting)
            {
                if (currentCutIndex >= cutObjects.Length)
                    break;

                if (canInput)
                    StartCoroutine(Input_Check());

                yield return null;
            }

            LoadScene();
        }
        public IEnumerator Input_Check()
        {
            canInput = false;

            if (Input.GetMouseButtonDown(0))
            {
                yield return NextCut();
                yield return InputWait;
            }

            canInput = true;
        }
        #region Next_Cut
        private IEnumerator NextCut()
        {
            Sequence sequence = DOTween.Sequence();
            cutObjects[currentCutIndex].TryGetComponent(out Image tempCutImage);
            sequence.Append(tempCutImage.DOFade(1, fadeTime))
                .Play();

            currentCutIndex++;

            yield return null;
        }



        #endregion

        private void OnDestroy()
        {
            DOTween.KillAll();
        }

    }
}