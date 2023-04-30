using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleMC : BaseMC
{
    public GameObject[] buttons;

    public void PressStart()
    {
        StartCoroutine(StartAnimation());
    }

    IEnumerator StartAnimation()
    {
        yield return null;
        Destroy(gameObject);
    }

    override public IEnumerator DestroyProgrss()
    {

        yield break;
    }
}
