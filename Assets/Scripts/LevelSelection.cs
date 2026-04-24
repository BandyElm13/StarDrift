using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    //standard level
    [SerializeField] private string levelA;
    //Timed level varient time is what ever i feel like
    [SerializeField] private string levelB;
    //Dare Devil Level- current health = 1
    [SerializeField] private string levelC;

    private string hubWorld = "StarDriftHub";

    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void LevelA()
    {
        SceneManager.LoadScene(levelA);
    }
    public void LevelB()
    {
        SceneManager.LoadScene(levelB);
    } 
    public void LevelC()
    {
        SceneManager.LoadScene(levelC);
    } 

    public void HubWorld()
    {
        SceneManager.LoadScene(hubWorld);
    } 
}
