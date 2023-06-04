using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Trigger;
using UnityEngine.EventSystems;

namespace Game.MainRoom.Trigger
{
    public class Bubble_Dream : BubbleObject
    {
        public RoomContorller RoomContorller;
        public SceneController.SceneName sceneName;

        public override void OnPointerClick(PointerEventData eventData)
        {
            base.OnPointerClick(eventData);
            RoomContorller.DreamChange(sceneName.ToString());
            TriggerBubble.BubbleAction -= SetActive;
            TriggerBubble.isEndEvent = false;
            TriggerBubble.boxCollider.enabled = false;
        }
    }
}