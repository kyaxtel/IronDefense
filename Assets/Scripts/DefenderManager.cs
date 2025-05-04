using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DefenderManager : MonoBehaviour
{
    public static DefenderManager Instance;

    public GameObject selectedDefenderPrefab;
    private DefenderButton selectedButton;

    private void Awake() {
        Instance = this;
    }

    public void SetSelectedDefender(GameObject defenderPrefab) {
        selectedDefenderPrefab = defenderPrefab;
    }

    public void TryPlaceDefender(Vector3 position) {
        if (selectedDefenderPrefab == null) return;

        Instantiate(selectedDefenderPrefab, position, Quaternion.identity);
    }

    public GameObject GetSelectedDefender() {
        return selectedDefenderPrefab;
    }

    public void UpdateSelectedButton(DefenderButton newButton)
    {
        if (selectedButton != null)
        {
            selectedButton.SetSelectedVisual(false);
        }

        selectedButton = newButton;
        selectedButton.SetSelectedVisual(true);
    }
}
