using System;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

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

    //public Sprite tilledIcon;
    //public SpriteRenderer tiledRenderer;

    //public Sprite wateredIcon;
    //public SpriteRenderer wateredRenderer;

    //public SeedPacket plantedSeed;
    //public SpriteRenderer cropRenderer;

    //[SerializeField] float _growthTimer = 0f;
    //[SerializeField] float _timer = 0f;

    //private bool _isTilled = false;
    //private bool _isWatered = false;
    //private bool _isPlanted = false;

        #region Visual Overlays
        [Header("Overlay Renderers")]
        public SpriteRenderer soilSR;   // optional — can show tilled soil color
        public SpriteRenderer waterSR;  // shows watered overlay
        public SpriteRenderer cropSR;   // shows plant sprites
        #endregion

        #region State
        public bool isTilled = false;
        public bool isWatered = false;
        public bool hasCrop = false;
        #endregion

        #region Growth
        public int currentGrowthStage = 0;
        public float growthTimer = 0f;
        public float growthTimePerStage = 5f;
        public SeedPacket plantedSeed;
        #endregion

        #region Grid / Manager
        public Vector2Int Location { get; private set; }
        public string TilemapName { get; private set; }
        private CropManager _cropManager;
        #endregion

        private void Awake()
        {
            // Make sure overlays start hidden
            if (waterSR != null) waterSR.enabled = false;
            if (cropSR != null) cropSR.enabled = false;
        }

        private void Update()
        {
            if (hasCrop && isWatered && plantedSeed != null)
            {
                growthTimer += Time.deltaTime;

                if (growthTimer >= growthTimePerStage)
                    AdvanceGrowth();
            }
        }

        #region Player Actions
        public void TillSoil()
        {
            if (!isTilled && CanInteract())
            {
                isTilled = true;
                if (soilSR != null)
                {
                    soilSR.enabled = true;  // show dry tilled soil
                }
            }
        }

        public void WaterSoil()
        {
            if (isTilled && !isWatered && CanInteract())
            {
                isWatered = true;
                if (waterSR != null)
                    waterSR.enabled = true; // turn on the overlay
            }
        }

        public void PlantSeed(SeedPacket seed)
        {
            if (isTilled && isWatered && !hasCrop && CanInteract())
            {
                plantedSeed = seed;
                hasCrop = true;
                currentGrowthStage = 0;
                growthTimer = 0f;

                if (cropSR != null)
                {
                    cropSR.enabled = true;
                    cropSR.sprite = plantedSeed.growthSprites[currentGrowthStage];
                }

                _cropManager.AddToPlantedCrops(this);
            }
        }

        public void HarvestPlants()
        {
            if (!hasCrop || plantedSeed == null || !CanInteract())
                return;

            if (currentGrowthStage >= plantedSeed.growthSprites.Length - 1)
            {
                // spawn harvestable prefab if defined
                if (plantedSeed.harvestablePrefab != null)
                    Instantiate(plantedSeed.harvestablePrefab, transform.position, Quaternion.identity);

                ResetCrop();
                _cropManager.RemoveFromPlantedCrops(Location);
            }
        }
        #endregion

        #region Growth Logic
        private void AdvanceGrowth()
        {
            growthTimer = 0f;
            currentGrowthStage++;

            if (plantedSeed != null && currentGrowthStage < plantedSeed.growthSprites.Length)
            {
                if (cropSR != null)
                    cropSR.sprite = plantedSeed.growthSprites[currentGrowthStage];
            }
            else
            {
                currentGrowthStage = plantedSeed.growthSprites.Length - 1;
            }

            // After growing, dry out the soil
            isWatered = false;
            if (waterSR != null)
                waterSR.enabled = false;
        }

        private void ResetCrop()
        {
            hasCrop = false;
            isTilled = true;   // still tilled after harvest
            isWatered = false;
            plantedSeed = null;
            growthTimer = 0f;
            currentGrowthStage = 0;

            // Turn off overlays
            if (waterSR != null) waterSR.enabled = false;
            if (cropSR != null) cropSR.enabled = false;
            if (cropSR != null) cropSR.sprite = null;
        }
        #endregion

        #region Helpers
        private bool CanInteract() => _cropManager != null && enabled;

        public void PreventUse()
        {
            enabled = false;
        }

        public void Initialize(string tilemapName, Vector2Int location, CropManager cropManager)
        {
            TilemapName = tilemapName;
            Location = location;
            _cropManager = cropManager;
        }
        #endregion
}
