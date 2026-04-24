using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    [SerializeField] private string backToHub = "StarDriftHub";
    [SerializeField] private string backToMainMenu;
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void restartGame()
    {
        SceneManager.LoadScene(backToHub);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(backToMainMenu);
    }
}
