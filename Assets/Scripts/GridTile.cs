using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GridTile : MonoBehaviour
{
    private bool isOccupied = false; // Flag to check if the tile is occupied

    // Called when the defender is placed on the tile
    public void PlaceDefender(Defender defender)
    {
        if (isOccupied)
        {
            Debug.Log("Tile is already occupied!");
            return;
        }

        isOccupied = true; // Mark the tile as occupied
        defender.SetTile(this); // Set the current tile for the defender
    }

    // This method will be called when the defender dies
    public void OnDefenderDied()
    {
        isOccupied = false; // Free up the tile when the defender dies
    }

    // Handle mouse click to place a defender
    void OnMouseDown()
{
    if (isOccupied) return;

    GameObject selectedDefender = DefenderManager.Instance.GetSelectedDefender();
    if (selectedDefender != null)
    {
        Defender defender = selectedDefender.GetComponent<Defender>();
        if (defender != null)
        {
            // Call the updated method that also passes the tile
            defender.PlaceDefender(transform.position + Vector3.up * 1f, this);
        }
    }
}

}