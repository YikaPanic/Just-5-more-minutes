using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public float timeLeft = 300.0f; 
    public Text timerText;

    private void Update()
    {
        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0)
        {
            EndGame();
        }
        else
        {
            UpdateTimerUI();
        }
    }

    void EndGame()
    {
        // load WinScene
        SceneManager.LoadScene("WinScene");
    }

    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(timeLeft / 60);
        int seconds = Mathf.FloorToInt(timeLeft % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
