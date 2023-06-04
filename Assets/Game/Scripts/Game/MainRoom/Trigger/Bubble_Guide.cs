using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.MainRoom.Trigger
{
    public class Bubble_Guide : MonoBehaviour
    {
        public GameObject GuideObj;

        private void OnEnable()
        {
            GuideObj.SetActive(true);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                GuideObj.SetActive(false);
            }
        }
    }
}