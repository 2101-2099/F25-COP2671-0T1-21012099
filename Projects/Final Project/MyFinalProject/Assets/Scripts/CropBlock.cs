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

    //tilled soil group probably a header
    //tilled soil icon Sprite
    //plowed soil sr    Sprite Render

    //water soil group probably a header
    //water soil icon Sprite
    //watered soil sr Sprite Render

    //crop sr       Sprite Render

    //timer being timer in the bottom left corner with time of the world. So as the day goes by the timer shows the time in an hour.
    //also a growth time
    //plant needs to have been watered to grow
    //check to see if something is selected or not to see if you can plant
    //if there is already a plant there they are not allowed to till/plant there
    //particle effect when ready to harvest
    //plantings, watering, tilling, and harvest are going to be on button
    //probably check if the tile has been watered by checking its tile instead maybe use a watered boolen that gets attached to a tile.
    //watered tile will have the waterSR sprite on them.
    //after a growth make the water tile back into the till tile to show it need to be watered again and turns off a watered tag.
    //in an empty game object named cropblock I have a WaterSR sprite and a CropSR sprite
    //going to make the cropblock object into a prefab object

    //needs selected block for later used with farming controller for get; set; selected block is selecting a tile from the tilemap

    //ignore this is a reminder do not forget to shift all of the tilemap by -0.5 to allign everything (going to work more with SO (scriptible objects))
    //ignore this remember to add collision to water

    public Sprite tilledIcon;
    public SpriteRenderer tiledRenderer;

    public Sprite wateredIcon;
    public SpriteRenderer wateredRenderer;

    public SeedPacket plantedSeed;
    public SpriteRenderer cropRenderer;

    [SerializeField] float _growthTimer = 0f;
    [SerializeField] float _timer = 0f;

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
