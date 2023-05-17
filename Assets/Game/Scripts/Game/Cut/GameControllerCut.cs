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
        CutContainer[] CutContainer;
        [SerializeField] List<GameObject[]> ListCut;
        [Header("Private Setting")]
        public float inputWaitTime;
        public float fadeTime;
        public int currentContainer;
        [SerializeField]
        private int currentCutIndex = 0;
        private bool isExcuting = true;
        private bool canInput = true;

        private float waitTime = 0;

        private WaitForSeconds InputWait => new WaitForSeconds(inputWaitTime);

        private void Start()
        {
            currentContainer = GameManager.Instance.CurruntDay;
            foreach (GameObject obj in CutContainer[currentContainer].cutObjects)
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
                waitTime += Time.deltaTime;

                if (currentCutIndex >= CutContainer[currentContainer].cutObjects.Length)
                {
                    yield return new WaitForSeconds(fadeTime + 1.0f);
                    break;
                }

                if (waitTime > 1.0f)
                {
                    canInput = false;
                    yield return WaitTimeNext(NextCut());
                    waitTime -= waitTime;
                    continue;
                }

                if (canInput)
                    yield return Input_Check();

                yield return null;
            }

            LoadScene();
        }

        public IEnumerator WaitTimeNext(IEnumerator ie)
        {
            yield return InputWait;
            yield return ie;
        }

        public IEnumerator Input_Check()
        {
            canInput = false;

            if (Input.GetMouseButtonDown(0))
            {
                waitTime -= waitTime;

                yield return NextCut();
                yield return InputWait;
            }

            canInput = true;
        }
        #region Next_Cut
        private IEnumerator NextCut()
        {
            Sequence sequence = DOTween.Sequence();
            CutContainer[currentContainer].cutObjects[currentCutIndex].TryGetComponent(out Image tempCutImage);
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