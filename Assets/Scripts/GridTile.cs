using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GridTile : MonoBehaviour
{
    private bool isOccupied = false;

    void OnMouseDown()
    {
        if (isOccupied) return;

        GameObject selectedDefender = DefenderManager.Instance.GetSelectedDefender();
        if (selectedDefender != null) {
            Defender defender = selectedDefender.GetComponent<Defender>();
            defender.PlaceDefender(transform.position + Vector3.up * 1f); // Place slightly above tile
            isOccupied = true;
        }
    }
}
