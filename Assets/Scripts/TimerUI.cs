using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TimerUI : MonoBehaviour
{
    private TextMeshProUGUI timerText;
    private Timer gt;

    void Start()
    {
    timerText = GetComponent<TextMeshProUGUI>();
    gt = FindAnyObjectByType<Timer>();
    if (gt != null)
        {
            gt.onTimer.AddListener(OnTimerEnd);
        }

    gt = FindAnyObjectByType<Timer>();

    }

    void Update()
    {
        if(gt != null && gt.timerRunning)
        {
            UpdateTimer();
        }
    }
    public void UpdateTimer()
    {
        timerText.text = gt.currentTime.ToString();
    }

    private void OnTimerEnd()
    {
        timerText.text = "0";
        SceneManager.LoadScene("DeathScrean");

    }

}
