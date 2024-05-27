using UnityEngine;

public class WorldTimer : MonoBehaviour
{
    private float timerInterval = 5f;
    private float elapsedTime = 0f;

    void Start()
    {
        InvokeRepeating("TimerTick", 0f, timerInterval);
    }

    void TimerTick()
    {
        OnTimerTick?.Invoke();
    }

    public static event System.Action OnTimerTick;

    // Optionally, you can reset the timer if needed
    void ResetTimer()
    {
        elapsedTime = 0f;
    }

    // Clean up
    private void OnDestroy()
    {
        // Make sure to cancel the invoke when the script is destroyed
        CancelInvoke("TimerTick");
    }
}