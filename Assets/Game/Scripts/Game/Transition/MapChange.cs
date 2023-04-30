using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Transition
{
    public class MapChange : MonoBehaviour
    {
        [SerializeField]
        private Material mapChangeMaterial;
        [SerializeField]
        private float transitionTime = 0.5f;
        [SerializeField]
        private string propertyName = "_Progress";

        public UnityEvent OnTransitionDone;

        private void Start()
        {

        }

        public IEnumerator OpenTransition()
        {
            float currentTime = 0;

            while (currentTime < transitionTime)
            {
                currentTime += Time.deltaTime;
                mapChangeMaterial.SetFloat(propertyName,
                    Mathf.Clamp01(currentTime / transitionTime));
                yield return null;
            }
            OnTransitionDone?.Invoke();
        }

        public IEnumerator CloseTransition()
        {
            float currentTime = 0;

            while (currentTime < transitionTime)
            {
                currentTime += Time.deltaTime;
                mapChangeMaterial.SetFloat(propertyName,
                    0.9f - Mathf.Clamp01(currentTime / transitionTime));
                yield return null;
            }
            OnTransitionDone?.Invoke();
        }
    }
}