using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Trigger;
using UnityEngine.EventSystems;

namespace Game.MainRoom.Trigger
{
    public class Bubble_Dialogue : BubbleObject
    {
        public DialogueController DialogueController;

        private void OnEnable()
        {
            DialogueController.Close();
        }

        public override void OnPointerClick(PointerEventData eventData)
        {
            base.OnPointerClick(eventData);
            DialogueController.Show();
            TriggerBubble.BubbleAction -= SetActive;
            TriggerBubble.isEndEvent = true;
            TriggerBubble.boxCollider.enabled = false;
        }
    }
}