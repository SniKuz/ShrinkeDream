using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.Trigger
{
    public class BubbleObject : MonoBehaviour, IPointerClickHandler
    {
        [HideInInspector]public TriggerBubble TriggerBubble;

        public AudioSource AudioSource;
        public float RemoveTime = 0.5f;

        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }
        private void Hide()
        {
            gameObject.SetActive(false);
        }

        public virtual void OnPointerClick(PointerEventData eventData)
        {
            AudioSource.Play();
            Invoke("Hide", RemoveTime);
        }
    }
}