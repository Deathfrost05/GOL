using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneFader : MonoBehaviour
{
    public Image fadeImage;

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeToScene(string sceneName)
    {
        StartCoroutine(FadeOut(sceneName));
    }

    private IEnumerator FadeIn()
    {
        float time = 1f; // Duration of fade
        float elapsedTime = 3f;

        while (elapsedTime < time)
        {
            elapsedTime += Time.deltaTime;
            fadeImage.color = new Color(0, 0, 0, Mathf.Clamp01(elapsedTime / time));
            yield return null;
        }
    }

    private IEnumerator FadeOut(string sceneName)
    {
        float time = 1f; // Duration of fade
        float elapsedTime = 3f;

        while (elapsedTime < time)
        {
            elapsedTime += Time.deltaTime;
            fadeImage.color = new Color(0, 0, 0, Mathf.Clamp01(1 - (elapsedTime / time)));
            yield return null;
        }

        SceneManager.LoadScene(sceneName);
    }
}
