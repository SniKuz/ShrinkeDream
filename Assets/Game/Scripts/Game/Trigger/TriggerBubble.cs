using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Trigger
{
    public class TriggerBubble : MonoBehaviour
    {
        public BubbleObject Bubble;
        public BoxCollider2D boxCollider;

        public Action<bool> BubbleAction;

        [HideInInspector]public bool isEndEvent;

        public void SetActive(bool isAcitve)
        {
            gameObject.SetActive(isAcitve);
        }

        private void Start()
        {
            Init();
            boxCollider = GetComponent<BoxCollider2D>();
        }

        private void Init()
        {
            isEndEvent = false;
            BubbleAction += Bubble.SetActive;
            Bubble.TriggerBubble = this;
            Bubble.SetActive(false);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                BubbleAction?.Invoke(true);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                BubbleAction?.Invoke(false);
            }
        }
    }
}