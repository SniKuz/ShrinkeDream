using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Trigger
{
    public class TriggerBubble : MonoBehaviour
    {
        public GameObject Bubble;

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
            Bubble.SetActive(false);
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