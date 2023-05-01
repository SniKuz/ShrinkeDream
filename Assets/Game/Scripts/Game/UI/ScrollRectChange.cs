using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollRectChange : UIBehaviour, ILayoutSelfController
{
    public ScrollRect scrollRect;

    public void SetLayoutHorizontal()
    {

    }

    public void SetLayoutVertical()
    {

    }

    protected override void OnRectTransformDimensionsChange()
    {
        scrollRect.verticalNormalizedPosition = 0;
    }
}
