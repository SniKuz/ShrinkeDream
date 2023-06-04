using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Transition;
using TMPro;

namespace Game.MainRoom
{
    public class ChapterUI : MonoBehaviour
    {
        [Header("Reference")]
        public CanvasGroup m_CanvasGroup;
        public TextMeshProUGUI m_TitleText;
        public TextMeshProUGUI m_DayText;
        [Header("Setting")]
        public float transitionTime = 1.0f;

        private static int dayIsRepeat = 0;

        private void OnEnable()
        {
            if (dayIsRepeat != GameManager.Instance.CurruntDay + 1) 
            {
                dayIsRepeat = GameManager.Instance.CurruntDay + 1;
                m_TitleText.text = GameManager.Instance.CurrentCharacter;
                m_DayText.text = dayIsRepeat.ToString();

                StartCoroutine(Excute());
            }
            else
            {
                gameObject.SetActive(false);
            }

            
        }

        IEnumerator Excute()
        {
            yield return FadeOut();
            gameObject.SetActive(false);
        }

        void SetTransition()
        {
            TryGetComponent(out m_CanvasGroup);
            m_CanvasGroup.alpha = 1;
        }

        public IEnumerator FadeOut()
        {
            SetTransition();

            float currentTime = 0;

            while (currentTime < 1)
            {
                currentTime += Time.deltaTime / transitionTime;
                m_CanvasGroup.alpha = Mathf.Clamp01(1-currentTime);
                yield return null;
            }

        }
    }
}