using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Trigger;
using UnityEngine.EventSystems;

namespace Game.MainRoom.Trigger
{
    public class Bubble_Cut : BubbleObject
    {

        public override void OnPointerClick(PointerEventData eventData)
        {
            base.OnPointerClick(eventData);
            GameManager.Instance.SceneController.AdditveScene(2);
            TriggerBubble.isEndEvent = false;
        }
    }
}