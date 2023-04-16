using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogoTransition : MonoBehaviour
{
    public float transitionTime = 1.0f;

    Image image;
    
    void Start()
    {
        TryGetComponent<Image>(out image);
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        float currentTime = 0;

        while (currentTime < transitionTime)
        {
            currentTime += Time.deltaTime;
            image.color = new Color(image.color.r, image.color.g, image.color.b, Mathf.Clamp01(currentTime / transitionTime));
            yield return null;
        }

        GameManager.Instance.SceneController.LoadScene(SceneController.SceneName.LogoScene);

        yield break;
    }
}
