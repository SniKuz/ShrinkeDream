using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameController : MonoBehaviour
{
    [Header("Base Reference")]
    [SerializeField]
    protected SceneController sceneController;

    public virtual void Excute() { StartCoroutine(ExcuteProcess()); }
    protected virtual IEnumerator ExcuteProcess() { yield return null; }

    protected virtual void LoadScene()
    {
        sceneController.LoadScene();
    }
}
