using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Game.Trigger;

namespace Game
{
    public class FadeIllust : MonoBehaviour
    {
        [HideInInspector] public bool isEnd = false;
        public float transitionTime = 1.0f;
        [SerializeField]
        CanvasGroup canvasGroup;

        private void Start()
        {
            //SetTransition(false);
        }

        void SetTransition(bool isActive)
        {
            canvasGroup.alpha = 0;
            canvasGroup.gameObject.SetActive(isActive);
        }

        public IEnumerator FadeIn()
        {
            SetTransition(true);

            float currentTime = 0;

            while (currentTime < 1)
            {
                currentTime += Time.deltaTime / transitionTime;
                canvasGroup.alpha = Mathf.Clamp01(currentTime);
                Debug.Log("currentTime");
                yield return null;
            }

            yield return new WaitForSeconds(1.0f);
            SetTransition(false);
            isEnd = true;
        }
    }
}