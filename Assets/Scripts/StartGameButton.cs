using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene"); // Change name if needed
    }
}
