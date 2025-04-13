using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class PlayerHealthManager : MonoBehaviour
{
    public static PlayerHealthManager Instance {get; private set;}
    public int maxHealth = 5;
    public int currentHealth;
    public TextMeshProUGUI healthText;

    void Awake()
    {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        currentHealth = maxHealth;
    }

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    public void TakeDamage(int amount) {
        currentHealth -= amount;
        UpdateHealthUI();

        if (currentHealth <= 0) {
            GameOver();
        }
    }

    void UpdateHealthUI() {
        healthText.text = "Health: "  + currentHealth;
    }

    void GameOver() {
        SceneManager.LoadScene("GameOverScene");
    }
}
