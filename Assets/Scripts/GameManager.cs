using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject gameOverPanel;

    void Awake()
    {
        Instance = this;
    }

    public void GameOver() {
        Time.timeScale = 0f; // Pause game
        gameOverPanel.SetActive(true); // Assign a UI panel in inspector
    }
}
