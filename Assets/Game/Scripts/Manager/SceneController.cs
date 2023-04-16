using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public enum SceneName
    {
        LogoScene,
    }
    [SerializeField]
    private string Path_Scene = "Game/Scenes/";
    
    /* Scene Load */
    public void LoadScene(SceneName scene)
    {
        SceneManager.LoadScene(Path_Scene + scene.ToString());
    }
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(Path_Scene + scene);
    }
    public void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
