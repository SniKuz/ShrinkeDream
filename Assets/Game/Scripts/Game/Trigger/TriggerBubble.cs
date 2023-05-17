using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Trigger
{
    public class TriggerBubble : MonoBehaviour
    {
        public GameObject Bubble;
        public bool bubbleVisible = false;

        private void Start()
        {
            Init();
        }

        private void OnDisable()
        {
            Init();
        }

        private void Init()
        {
            Bubble.SetActive(bubbleVisible);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                Bubble.gameObject.SetActive(true);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                Bubble.gameObject.SetActive(false);
            }
        }
    }
}