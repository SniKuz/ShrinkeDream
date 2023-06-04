using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;

public abstract class GameController : MonoBehaviour
{
    [Header("Base Reference")]
    [SerializeField]
    public SceneController.SceneName sceneName;

    public virtual void Excute() { StartCoroutine(ExcuteProcess()); }
    protected virtual IEnumerator ExcuteProcess() { yield return null; }

    protected virtual void LoadScene()
    {
        GameManager.Instance.SceneController.LoadScene(sceneName);
    }
}
