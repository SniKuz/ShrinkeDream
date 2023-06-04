using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Trigger;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Game.MainRoom.Trigger
{
    public class Bubble_Popup : BubbleObject
    {
        public GameObject Popup;

        public override void OnPointerClick(PointerEventData eventData)
        {
            Popup.SetActive(true);
            base.OnPointerClick(eventData);
            TriggerBubble.isEndEvent = false;
        }
    }
}