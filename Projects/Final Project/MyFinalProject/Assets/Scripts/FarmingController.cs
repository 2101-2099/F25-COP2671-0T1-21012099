using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

//Farming controller Script
public class FarmingController : MonoBehaviour
{
    public CropManager cropManager;
    public Tilemap tilemap;

    public SeedPacket selectedSeed;
    [SerializeField] private List <SeedPacket> _seedList;
    private int _selectedIndex = 0;
    public CropBlock SelectedBlock;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 world = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int cell = tilemap.WorldToCell(world);

            SelectedBlock = cropManager.GetCropBlock(cell);

            if (SelectedBlock != null)
                Debug.Log($"Selected block: {SelectedBlock.gridPosition}");
            else
                Debug.Log("No block at this location.");
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            ChangeSeed();
        }
    }

    private void ChangeSeed()
    {
        _selectedIndex++;
        if (_selectedIndex >= _seedList.Count)
        {
            _selectedIndex = 0;
        }
        selectedSeed =  _seedList[_selectedIndex];
        Debug.Log($"Seed Changed to {selectedSeed.name}");
    }

    public void OnHoe() => SelectedBlock?.TillSoil();
    public void OnWater() => SelectedBlock?.WaterSoil();
    public void OnSeed() => SelectedBlock?.PlantSeed(selectedSeed);
    public void OnGather() => SelectedBlock?.HarvestPlants();
}
