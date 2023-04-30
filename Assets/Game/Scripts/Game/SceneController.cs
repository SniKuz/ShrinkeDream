using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public enum SceneName
    {
        Logo,
        Title,
        Cut,
        MainRoom,
        
    }

    public SceneName sceneName;
    [SerializeField]
    private string Path_Scene = "Game/Scenes/";
    
    /* Scene Load */
    /// <summary>
    /// 씬 불러오기, SceneController 클래스의 SceneName에 올바른 Scene 이름을 넣으세요.
    /// </summary>
    /// <param name="scene"></param>
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
    public void LoadScene()
    {
        SceneManager.LoadScene(Path_Scene + sceneName.ToString());
    }
}
