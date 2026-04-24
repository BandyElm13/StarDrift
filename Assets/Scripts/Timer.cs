using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] public int currentTime;
    public bool timerRunning = false;

    public UnityEvent onTimer;

    void Start()
    {
        timerRunning = true;
        StartCoroutine(gameTimer());
    }

    public IEnumerator gameTimer() {
    for(int i = currentTime; i > 0; i--) {
        currentTime = i;
        //Debug.Log("current time = " + i);
        yield return new WaitForSeconds(1f);
    }
    currentTime = 0;
    timerRunning = false;
    onTimer.Invoke();
}
}
