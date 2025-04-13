using UnityEngine;
using TMPro;

public class ResourceManager : MonoBehaviour 
{
    public static ResourceManager Instance;

    public int currentResources = 100; // Starting resources, you can adjust this
    public TextMeshProUGUI resourceText; // Reference to a UI text elemnet to show resources

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        UpdateResourcesUI();
    }

    // Method to add resources
    public void AddResources(int amount) {
        currentResources += amount;
        UpdateResourcesUI();
    }

    // Method to subtract resources (e.g., when placing a defender)
    public bool SpendResources(int amount) {
        if (currentResources >= amount) {
            currentResources -= amount;
            UpdateResourcesUI();
            return true;
        }
        return false; // Not enough resources
    }

    private void UpdateResourcesUI() {
        if (resourceText != null) {
            resourceText.text = "Resources: " + currentResources.ToString();
        }
    }
}