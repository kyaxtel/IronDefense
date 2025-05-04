using UnityEngine;
using TMPro; // This is important for TextMeshProUGUI

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance;

    public int currentResources = 100;
    public TextMeshProUGUI resourceText; // Set this in the Inspector

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        UpdateResourceUI();
    }

    public int GetResources() {
        return currentResources;
    }

    public bool SpendResources(int amount)
    {
        if (currentResources >= amount)
        {
            currentResources -= amount;
            UpdateResourceUI();
            return true;
        }
        return false;
    }

    public void AddResources(int amount)
    {
        currentResources += amount;
        UpdateResourceUI();
    }

    public void UpdateResourceUI()
    {
        if (resourceText != null)
            resourceText.text = "Resources: " + currentResources;
    }
}