using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance; // Static reference to the singleton instance

    public GameObject tilePrefab; // The tile prefab to instantiate
    public int width = 15; // The number of columns in the grid
    public int height = 5; // The number of rows in the grid
    public float spacing = 6f; // The space between each tile

    private GridTile[,] gridTiles; // 2D array to store references to all the grid tiles

    void Awake()
    {
        if (Instance == null)
            Instance = this; // Set the static reference to this instance
        else
            Destroy(gameObject); // Destroy duplicate if there's already an instance
    }

    void Start()
    {
        gridTiles = new GridTile[width, height]; // Initialize the gridTiles array

        // Loop through and create the grid of tiles
        for (int z = 0; z < height; z++)
        {
            for (int x = 0; x < width; x++)
            {
                Vector3 pos = new Vector3(x * spacing - 6f, -8f, z * spacing);
                GameObject tileObject = Instantiate(tilePrefab, pos, Quaternion.identity, transform);
                GridTile gridTile = tileObject.GetComponent<GridTile>();

                // Store the tile reference in the gridTiles array
                gridTiles[x, z] = gridTile;
            }
        }
    }

    // Method to get a tile at a specific position
    public GridTile GetTileAtPosition(Vector3 position)
    {
        // Convert the position to grid coordinates based on spacing
        int x = Mathf.FloorToInt(position.x / spacing);
        int z = Mathf.FloorToInt(position.z / spacing);

        // Check if the position is within the bounds of the grid
        if (x >= 0 && x < width && z >= 0 && z < height)
        {
            return gridTiles[x, z]; // Return the tile at the calculated position
        }
        return null; // Return null if position is out of bounds
    }
}

