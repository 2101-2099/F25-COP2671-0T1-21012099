using UnityEngine;

public class CropBlock : MonoBehaviour
{
    public enum GrowthStage
    {
        seed,
        sprout,
        young,
        mature
    }

    //tilled soil group
        //tilled soil icon Sprite
        //plowed soil sr    Sprite Render
    //water soil group
        //water soil icon Sprite
        //watered soil sr Sprite Render

    //crop sr       Sprite Render

    //timer being timer in the bottom left corner with time
    //also a growth time
    //check to see if something is selected or not to see if you can plant
    //particle effect when ready to harvest
    //plantings, watering, tilling, and harvest are going to be on button
    //in an empty game object I have a WaterSR sprite and a CropSR sprite
    //do not forget to shift all of the tilemap by 0.5 to allign everything

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
