using UnityEngine;

public class CropBlock : MonoBehaviour
{
    enum GrowthStage
    {
        seed,
        sprout,
        youngPlant,
        mature
    }

    public SeedPacket plantedSeed;
    public SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void TillSoil()
    {
        //placeholder
    }

    private void WaterSoil()
    {
        //placeholder
    }
    private void PlantSeed()
    {
        //placeholder
    }

    private void HarvestPlants()
    {
        //placeholder
    }
}
