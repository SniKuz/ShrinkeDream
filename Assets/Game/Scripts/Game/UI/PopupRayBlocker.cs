using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PopupRayBlocker : MonoBehaviour, IPointerClickHandler
{
    public GameObject DestroyTarget;
    public void OnPointerClick(PointerEventData eventData)
    {
        DestroyTarget?.SetActive(false);
    }
}
