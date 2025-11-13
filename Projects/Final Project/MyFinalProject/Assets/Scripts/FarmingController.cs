using UnityEngine;
using UnityEngine.Events;

public class FarmingController : MonoBehaviour
{
    //tool at hand
    //tool speed
    //seed to use
    //selected block
    //ignore this tool use changes sprite/tool at hand

    // The currently selected crop tile
    [SerializeField] private CropBlock _selectedBlock;
    [SerializeField] private SeedPacket[] availableSeeds;
    private SeedPacket _selectedSeed;

    // Events for toolbar actions
    public UnityEvent OnHoe;
    public UnityEvent OnWater;
    public UnityEvent OnPlant;
    public UnityEvent OnHarvest;

    private void Awake()
    {
        // Initialize UnityEvents if they are null
        OnHoe ??= new UnityEvent();
        OnWater ??= new UnityEvent();
        OnPlant ??= new UnityEvent();
        OnHarvest ??= new UnityEvent();
    }
    private void Start()
    {
        _selectedSeed = availableSeeds[0]; // default
    }
    private void Update()
    {
        if (_selectedBlock == null) return;

        if (Input.GetKeyDown(KeyCode.Alpha1))  // Key "1"
            Hoe();

        if (Input.GetKeyDown(KeyCode.Alpha2))  // Key "2"
            Water();

        if (Input.GetKeyDown(KeyCode.Alpha3))  // Key "3"
            Plant(_selectedSeed);  // Make sure you have a selected seed 

        if (Input.GetKeyDown(KeyCode.Alpha4))  // Key "4"
            Harvest();
    }


    // Set the currently selected crop block (called from Tile selection)
    public void SelectBlock(CropBlock cropBlock)
    {
        _selectedBlock = cropBlock;
    }

    // Called from UI button "Hoe"
    public void Hoe()
    {
        if (_selectedBlock != null)
            _selectedBlock.TillSoil();
    }

    // Called from UI button "Water"
    public void Water()
    {
        if (_selectedBlock != null)
            _selectedBlock.WaterSoil();
    }

    // Called from UI button "Plant"
    public void Plant(SeedPacket seed)
    {
        if (_selectedBlock != null)
            _selectedBlock.PlantSeed(seed);
    }

    // Called from UI button "Harvest"
    public void Harvest()
    {
        if (_selectedBlock != null)
            _selectedBlock.HarvestPlants();
    }
}
