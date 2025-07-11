using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountDownTimer : MonoBehaviour
{
    public int startTime = 60; // Start time (default 60 seconds)
    private int currentTime;
    private Coroutine timerCoroutine; // To track the coroutine

    public Text timerText; // Assign in Inspector (UI Text)
    public GameObject gameOverPanel; // Assign in Inspector (Game Over UI)

    private void Start()
    {
        RestartTimer(); // Start the timer on game start
    }

    private IEnumerator TimerRoutine()
    {
        while (currentTime > 0)
        {
            yield return new WaitForSeconds(1f);
            currentTime--;
            UpdateTimerUI();
        }

        GameOver();
    }

    private void UpdateTimerUI()
    {
        if (timerText != null)
        {
            timerText.text = currentTime.ToString(); // Show time as integer
        }
    }

    private void GameOver()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true); // Enable Game Over UI
        }
    }

    // Public function to restart the timer
    public void RestartTimer()
    {
        if (timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine); // Stop the existing coroutine if running
        }

        currentTime = startTime; // Reset time
        UpdateTimerUI(); // Update UI immediately
        gameOverPanel?.SetActive(false); // Hide Game Over panel

        timerCoroutine = StartCoroutine(TimerRoutine()); // Restart the timer
    }
}
