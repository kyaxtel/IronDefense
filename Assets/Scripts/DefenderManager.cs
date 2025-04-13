using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DefenderManager : MonoBehaviour
{
    public static DefenderManager Instance;

    public GameObject selectedDefenderPrefab;

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
}
