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

        public override void OnPointerClick(PointerEventData eventData)
        {
            DialogueController.Show();
            base.OnPointerClick(eventData);
        }
    }
}