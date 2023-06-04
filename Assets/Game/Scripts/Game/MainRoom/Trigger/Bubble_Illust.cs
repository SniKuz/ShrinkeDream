using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Game.Trigger;

namespace Game.MainRoom.Trigger
{
    public class Bubble_Illust : BubbleObject
{
        private bool isClick = false;
        
        public float transitionTime = 1.0f;
        [SerializeField]
        CanvasGroup canvasGroup;

        private void Start()
        {
            canvasGroup.gameObject.SetActive(false);
            SetTransition(false);
        }

        public override void OnPointerClick(PointerEventData eventData)
        {
            if (isClick) return;

            isClick = true;
            TriggerBubble.BubbleAction -= SetActive;
            AudioSource.Play();
            StartCoroutine(FadeIn());
            
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
            TriggerBubble.isEndEvent = true;
            SetActive(false);
        }
    }
}