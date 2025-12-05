using UnityEngine;

//Crop Block script
public class CropBlock : MonoBehaviour
{
    public Vector2Int gridPosition;
    public enum GrowthStage
    {
        None = -1,
        Seed = 0,
        Sprout = 1,
        Young = 2,
        Mature = 3,
    }

    // State
    public bool isTilled = false;
    public bool isWatered = false;
    public bool hasSeed = false;
    public bool readyToHarvest = false;

    // Growth
    [SerializeField] private SeedPacket seed;
    //[SerializeField] private Seedling seedling;
    [SerializeField] private int growthStage = 0;
    [SerializeField] private float growthTimer = 0f;
    public float timePerStage = 20f;
    //[SerializeField] private Harvestable _cropHarvest;
    private SpriteRenderer spriteRenderer;
    //private DayNightEvents _dayNightEvents;
    private bool _canGrow = true;
    


    public Vector3 worldPosition;

    //on awake
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    //Till the soil
    public void TillSoil()
    {
        isTilled = true;
        Debug.Log($"[{gridPosition}] Soil tilled.");
    }

    //Water the soil
    public void WaterSoil()
    {
        isWatered = true;
        Debug.Log($"[{gridPosition}] Soil watered.");
    }

    //Plant the given seed
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

    //Growth Logic
    private void Update()
    {
        if (!hasSeed || readyToHarvest || !_canGrow)
            return;
        //if (!_dayNightEvents._isDaytime)
        //{
        //    return;
        //}
        growthTimer += Time.deltaTime;
        if (growthTimer >= timePerStage)
        {
            growthTimer = 0f;
            growthStage++;

            Debug.Log($"[{gridPosition}] Crop grew to stage {growthStage}.");
            spriteRenderer.sprite = seed.growthSprites[(int)growthStage];

            if (growthStage >= 3)
            {
                readyToHarvest = true;
                Debug.Log($"[{gridPosition}] {seed.cropName} is ready to harvest!");
            }
        }
    }

    //Harvest The plant
    public void HarvestPlants()
    {
        Debug.Log("Harvest Plant function called");
        if (!readyToHarvest)
        {
            Debug.Log($"[{gridPosition}] Nothing to harvest.");
            return;
        }

        Debug.Log($"[{gridPosition}] Harvested {seed.cropName}!");
        //Instantiate(_cropHarvest, transform.position, Quaternion.identity);
        if (seed.harvestablePrefab != null)
        {
            Debug.Log("Making sure harvest");
            Instantiate(seed.harvestablePrefab, transform.position, Quaternion.identity);
        }

        // Reset state
        hasSeed = false;
        readyToHarvest = false;
        isTilled = false;
        isWatered = false;
        seed = null;
        growthStage = 0;
        spriteRenderer = null;
    }
    //checks if day
    private void CheckGrowthTime(float normalizedTime)
    {
        if (normalizedTime >= 0.25 && normalizedTime <= 0.75)
        { _canGrow = true; }
        else
            { _canGrow = false; }
    }

    private void OnEnable()
    {
        // Subscribe to TimeManager’s normalized time updates
        TimeManager.OnTimerUpdate.AddListener(CheckGrowthTime);
    }

    private void OnDisable()
    {
        // Unsubscribe cleanly
        TimeManager.OnTimerUpdate.RemoveListener(CheckGrowthTime);
    }
}