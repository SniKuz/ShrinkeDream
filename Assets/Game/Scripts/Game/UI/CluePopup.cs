using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CluePopup : MonoBehaviour
{
    public PopupRayBlocker RayBlocker;

    private void OnEnable()
    {
        RayBlocker.gameObject.SetActive(true);
        RayBlocker.DestroyTarget = gameObject;
    }

    private void OnDisable()
    {
        RayBlocker.gameObject.SetActive(false);
    }
}
