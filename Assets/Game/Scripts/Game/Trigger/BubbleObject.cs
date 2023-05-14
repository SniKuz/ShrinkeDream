using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.Trigger
{
    public class BubbleObject : MonoBehaviour, IPointerClickHandler
    {
        public AudioSource AudioSource;
        public float RemoveTime = 0.5f;

        virtual public void OnPointerClick(PointerEventData eventData)
        {
            AudioSource.Play();
            Invoke("Hide", RemoveTime);
        }

        private void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}