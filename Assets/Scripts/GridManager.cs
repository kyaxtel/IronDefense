using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public GameObject tilePrefab;
    public int width = 9;
    public int height = 5;
    public float spacing = 1.1f;

    void Start()
    {
        for ( int z = 0; z < height; z++) {
            for ( int x = 0; x < width; x++) {
                Vector3 pos = new Vector3( x * spacing, 0, z * spacing );
                Instantiate( tilePrefab, pos, Quaternion.identity, transform );
            }
        }   
    }
}
