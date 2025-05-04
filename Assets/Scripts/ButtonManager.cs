using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour
{
    public GameObject defenderPrefab; // Assign in Inspector
    private Button button;
    private Image buttonImage;
    private Color normalColor = Color.white;
    private Color selectedColor = new Color(0.7f, 0.7f, 0.7f); // Grayed out

    private void Awake()
    {
        button = GetComponent<Button>();
        buttonImage = GetComponent<Image>();

        button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        DefenderManager.Instance.SetSelectedDefender(defenderPrefab);
        DefenderManager.Instance.UpdateSelectedButton(this);
    }

    public void SetSelectedVisual(bool selected)
    {
        if (buttonImage != null)
        {
            buttonImage.color = selected ? selectedColor : normalColor;
        }
    }
}
