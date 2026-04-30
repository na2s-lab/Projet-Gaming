using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public static SceneFader Instance;

    [Header("Fade")]
    public CanvasGroup fadeGroup;
    public float fadeDuration = 0.5f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        fadeGroup.alpha = 1f;
        StartCoroutine(FadeIn());
    }

    public void LoadSceneWithFade(string sceneName)
    {
        StartCoroutine(FadeOutAndLoad(sceneName));
    }

    IEnumerator FadeIn()
    {
        float time = fadeDuration;

        while (time > 0f)
        {
            time -= Time.deltaTime;
            fadeGroup.alpha = time / fadeDuration;
            yield return null;
        }

        fadeGroup.alpha = 0f;
    }

    IEnumerator FadeOutAndLoad(string sceneName)
    {
        float time = 0f;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            fadeGroup.alpha = time / fadeDuration;
            yield return null;
        }

        fadeGroup.alpha = 1f;

        SceneManager.LoadScene(sceneName);

        yield return null;

        StartCoroutine(FadeIn());
    }
}