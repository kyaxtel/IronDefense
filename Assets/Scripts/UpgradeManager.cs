using NUnit.Framework.Interfaces;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager Instance;

    private Defender selectedDefender;

    // Declare buttons for upgrading stats
    public Button upgradeDamageButton;
    public Button upgradeFireRateButton;
    public Button upgradeHealthButton;

    // Button colors
    public Color normalButtonColor = Color.white;
    public Color disabledButtonColor = new Color(0.5f, 0.5f, 0.5f); // Gray
    public Color selectedButtonColor = new Color(0.2f, 0.6f, 1f); // Blueish

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        // Add listeners to buttons
        upgradeDamageButton.onClick.AddListener(UpgradeDamage);
        upgradeFireRateButton.onClick.AddListener(UpgradeFireRate);
        upgradeHealthButton.onClick.AddListener(UpgradeHealth);

        // Initialize buttons as disabled at start
        UpdateButtonInteractivity(false);
    }

    // Set the selected defender for upgrade
    public void SetSelectedDefender(Defender defender)
    {
        selectedDefender = defender;
        // Update the defender name in the UI
        Debug.Log("Selected defender: " + defender.gameObject.name);

        // Update button interactivity and colors based on defender selection
        UpdateButtonInteractivity(true);
    }

    // Update button states based on the selection
    private void UpdateButtonInteractivity(bool isDefenderSelected)
    {
        // Enable/Disable buttons based on defender selection
        upgradeDamageButton.interactable = isDefenderSelected;
        upgradeFireRateButton.interactable = isDefenderSelected;
        upgradeHealthButton.interactable = isDefenderSelected;

        // Change the button colors to show their states
        upgradeDamageButton.GetComponent<Image>().color = isDefenderSelected ? normalButtonColor : disabledButtonColor;
        upgradeFireRateButton.GetComponent<Image>().color = isDefenderSelected ? normalButtonColor : disabledButtonColor;
        upgradeHealthButton.GetComponent<Image>().color = isDefenderSelected ? normalButtonColor : disabledButtonColor;
    }

    // Upgrade damage
    public void UpgradeDamage()
    {
        if (selectedDefender == null)
        {
            Debug.LogError("No defender selected!");
            return;
        }

        selectedDefender.UpgradeDamage(1f); // Upgrade damage
        ResourceManager.Instance.SpendResources(25);
        Debug.Log("Damage upgraded!");

        // After upgrade, update button color to indicate it was pressed
        upgradeDamageButton.GetComponent<Image>().color = selectedButtonColor;
    }

    // Upgrade fire rate
    public void UpgradeFireRate()
    {
        if (selectedDefender == null)
        {
            Debug.LogError("No defender selected!");
            return;
        }

        selectedDefender.UpgradeFireRate(0.1f); // Upgrade fire rate
        ResourceManager.Instance.SpendResources(30);
        Debug.Log("Fire rate upgraded!");

        // After upgrade, update button color to indicate it was pressed
        upgradeFireRateButton.GetComponent<Image>().color = selectedButtonColor;
    }

    // Upgrade health
    public void UpgradeHealth()
    {
        if (selectedDefender == null)
        {
            Debug.LogError("No defender selected!");
            return;
        }

        selectedDefender.UpgradeHealth(2f); // Upgrade health
        ResourceManager.Instance.SpendResources(20);
        Debug.Log("Health upgraded!");

        // After upgrade, update button color to indicate it was pressed
        upgradeHealthButton.GetComponent<Image>().color = selectedButtonColor;
    }
}
