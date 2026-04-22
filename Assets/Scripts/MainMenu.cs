using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour

{
    [SerializeField] private string playGame;
    [SerializeField] private Camera cam;

    [SerializeField] private Slider slider;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        float savedVolume = PlayerPrefs.GetFloat("volume", 1f);
        AudioListener.volume = savedVolume;

        if (slider != null)
        {
            slider.value = AudioListener.volume;
        }
    }

    public void Play()
    {
        SceneManager.LoadScene(playGame);
    }

    public void Settings()
    {
        cam.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
    }

    public void Back()
    {
        cam.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }

    public void Volume(float value)
    {
        AudioListener.volume = value;
        PlayerPrefs.SetFloat("volume", value); // Save whenever slider moves
        PlayerPrefs.Save();
    }

    public void Exit()
    {
        Application.Quit();
    }
}
