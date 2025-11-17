using UnityEngine;

public class CropBlock : MonoBehaviour
{
    public Vector2Int gridPosition;

    // State
    public bool isTilled = false;
    public bool isWatered = false;
    public bool hasSeed = false;
    public bool readyToHarvest = false;

    // Growth
    public SeedPacket seed;
    public int growthStage = 0;
    public float growthTimer = 0f;
    public float timePerStage = 4f;

    public Vector3 worldPosition;

    public void TillSoil()
    {
        isTilled = true;
        Debug.Log($"[{gridPosition}] Soil tilled.");
    }

    public void WaterSoil()
    {
        isWatered = true;
        Debug.Log($"[{gridPosition}] Soil watered.");
    }

    public void PlantSeed(SeedPacket newSeed)
    {
        if (!isTilled)
        {
            Debug.Log($"[{gridPosition}] Cannot plant — soil not tilled.");
            return;
        }

        seed = newSeed;
        hasSeed = true;
        growthStage = 0;
        growthTimer = 0f;

        Debug.Log($"[{gridPosition}] Seed planted: {seed.cropName}");
    }

    private void Update()
    {
        if (!hasSeed || readyToHarvest)
            return;

        growthTimer += Time.deltaTime;

        if (growthTimer >= timePerStage)
        {
            growthTimer = 0f;
            growthStage++;

            Debug.Log($"[{gridPosition}] Crop grew to stage {growthStage}.");

            if (growthStage >= 3)
            {
                readyToHarvest = true;
                Debug.Log($"[{gridPosition}] {seed.cropName} is ready to harvest!");
            }
        }
    }

    public void HarvestPlants()
    {
        if (!readyToHarvest)
        {
            Debug.Log($"[{gridPosition}] Nothing to harvest.");
            return;
        }

        Debug.Log($"[{gridPosition}] Harvested {seed.cropName}!");

        // Reset state
        hasSeed = false;
        readyToHarvest = false;
        isTilled = false;
        isWatered = false;
        seed = null;
        growthStage = 0;
    }
}
public enum SoilState
{
    Empty,
    Tilled,
    Watered,
    Growing,
    HarvestReady
}