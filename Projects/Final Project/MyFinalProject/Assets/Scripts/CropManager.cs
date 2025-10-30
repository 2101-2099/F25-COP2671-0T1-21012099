using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

[RequireComponent (typeof(Grid))]
public class CropManager : MonoBehaviour
{
    private Grid _cropGrid;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        _cropGrid = GetComponent<Grid> ();
    }

    private void Start()
    {
        if (_cropGrid == null) return;

        var tileMaps = _cropGrid.GetComponentsInChildren<Tilemap>();
        if (tileMaps.Length == 0)
        { return; }

        foreach (var tilemap in tileMaps)
        {
            tilemap.GetComponent<TilemapRenderer>().enabled = false;
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
