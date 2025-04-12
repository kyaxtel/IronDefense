using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GridTile : MonoBehaviour
{
    public GameObject defenderPrefab;
    private bool isOccupied = false;

    void OnMouseDown()
    {
        if (!isOccupied) {
            Instantiate(defenderPrefab, transform.position + Vector3.up * 1f, Quaternion.identity);
            isOccupied = true;
        }
    }
}
