using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    [RequireComponent(typeof(Canvas))]
    public class DreamChangeRander : MonoBehaviour
    {
        public Canvas Canvas;
        public CanvasGroup CanvasGroup;
        public Camera mainCamera;
        [Header("Render")]
        [SerializeField] private Image Image;
        [Header("Option")]
        public float FadeTime = 1.0f;
        public bool isFadeIn = true;

        private void Start()
        {
            TryGetComponent(out Canvas);
            mainCamera = Camera.main;
            Canvas.worldCamera = mainCamera;

            if (isFadeIn)
                StartCoroutine(FadeIn());
            else
                StartCoroutine(FadeOut());
        }

        IEnumerator FadeIn()
        {
            float time_count = 0;
 
            while (time_count < 1)
            {
                time_count += Time.deltaTime / FadeTime;
                FadeAlpha(0, 1, time_count);
                FadeBrightness(2, -0.5f, time_count);
                Debug.Log("asda");
                yield return null;
            }
           CanvasGroup.alpha = 1;
           Image.material.SetFloat("_Brightness", -0.5f);
        }
        IEnumerator FadeOut()
        {
            float time_count = 0;

            while (time_count < 1)
            {
                time_count += Time.deltaTime / FadeTime;
                FadeAlpha(1, 0, time_count);
                FadeBrightness(-0.5f, 2f, time_count);
                yield return null;
            }

            CanvasGroup.alpha = 0;
            Image.material.SetFloat("_Brightness", 2f);
        }

        private void FadeAlpha(float start, float des, float time)
        {
            CanvasGroup.alpha = Mathf.Lerp(start, des, time);
        }
        private void FadeBrightness(float start, float des, float time)
        {
            float value = Mathf.Lerp(start, des, time);
            Image.material.SetFloat("_Brightness", value);
        }
    }
}