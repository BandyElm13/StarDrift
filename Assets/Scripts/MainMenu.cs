using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    [SerializeField] private string playGame;
    [SerializeField] private string totorial;

    public void Play()
    {
        SceneManager.LoadScene(playGame);
    }

    public void Totorial()
    {
        SceneManager.LoadScene(totorial);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
