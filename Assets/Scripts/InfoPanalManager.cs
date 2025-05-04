using UnityEngine;
using UnityEngine.UI;  // Needed for buttons
using TMPro;  // Needed for TextMeshPro

public class InfoPanelManager : MonoBehaviour
{
    public GameObject infoPanel;  // Reference to the info panel UI
    public TextMeshProUGUI infoText;  // Reference to the text UI element for info
    public Button infoButton;  // Reference to the Info Button
    public Button closeButton; // Reference to the Close Button

    void Start()
    {
        // Initially hide the info panel
        infoPanel.SetActive(false);

        // Add button listeners
        infoButton.onClick.AddListener(ToggleInfoPanel);  // Open the panel when Info button is clicked
        closeButton.onClick.AddListener(CloseInfoPanel);  // Close the panel when Close button is clicked
    }

    // This method toggles the visibility of the info panel
    void ToggleInfoPanel()
    {
        infoPanel.SetActive(true);  // Make the panel visible
    }

    // This method closes the info panel
    void CloseInfoPanel()
    {
        infoPanel.SetActive(false);  // Hide the panel
    }
}
