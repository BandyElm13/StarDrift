using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndCredits : MonoBehaviour
{
    [SerializeField] private Image Scene1;
    [SerializeField] private Image Scene2;
    [SerializeField] private Image Scene3;
    [SerializeField] private Image Scene4;
    [SerializeField] private Image Scene5;
    [SerializeField] private Image Scene6;
    [SerializeField] private Image Scene7;

    [SerializeField] private float displayDuration = 34f; // How long each image shows (seconds)
    [SerializeField] private float fadeDuration = 1f;     // How long the fade in/out takes

    private Image[] scenes;

    void Start()
    {
        scenes = new Image[] { Scene1, Scene2, Scene3, Scene4, Scene5, Scene6, Scene7 };

        // Hide all images at the start
        foreach (Image scene in scenes)
        {
            Color c = scene.color;
            c.a = 0f;
            scene.color = c;
        }

        StartCoroutine(PlayCredits());
    }

    private IEnumerator PlayCredits()
    {
        foreach (Image scene in scenes)
        {
            // Fade in
            yield return StartCoroutine(FadeImage(scene, 0f, 1f));

            // Hold
            yield return new WaitForSeconds(displayDuration - fadeDuration * 2);

            // Fade out
            yield return StartCoroutine(FadeImage(scene, 1f, 0f));
        }
    }

    private IEnumerator FadeImage(Image image, float from, float to)
    {
        float elapsed = 0f;
        Color c = image.color;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            c.a = Mathf.Lerp(from, to, elapsed / fadeDuration);
            image.color = c;
            yield return null;
        }

        c.a = to;
        image.color = c;
    }

    public void returnToHub()
    {
        SceneManager.LoadScene("StarDrift Menu");
    }
}