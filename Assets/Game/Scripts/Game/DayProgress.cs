using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DayProgress : MonoBehaviour
{
    public virtual void Run()
    {
        StartCoroutine(Excute());
    }
    protected virtual IEnumerator Excute() {
        yield return null;
    }
}
