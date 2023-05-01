using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Transition
{
    public class LogoTransition : MonoBehaviour
    {
        public float transitionTime = 1.0f;
        [SerializeField]
        Image image;

        void SetTransition()
        {
            TryGetComponent(out image);
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
        }

        public IEnumerator FadeOut()
        {
            SetTransition();

            float currentTime = 0;

            while (currentTime < 1)
            {
                currentTime += Time.deltaTime / transitionTime;
                image.color = new Color(image.color.r, image.color.g, image.color.b, Mathf.Clamp01(currentTime));
                yield return null;
            }

        }
    }
}