using UnityEngine;
using UnityEngine.Tilemaps;

public class FarmingController : MonoBehaviour
{
    public CropManager cropManager;
    public Tilemap tilemap;

    public SeedPacket selectedSeed;
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
    }

    public void OnHoe() => SelectedBlock?.TillSoil();
    public void OnWater() => SelectedBlock?.WaterSoil();
    public void OnSeed() => SelectedBlock?.PlantSeed(selectedSeed);
    public void OnGather() => SelectedBlock?.HarvestPlants();
}
