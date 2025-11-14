using UnityEngine;
using UnityEngine.Events;

public class FarmingController : MonoBehaviour
{
    //toolbar controller
    //tool at hand
    //tool speed
    //seed to use
    //selected block
    //ignore this tool use changes sprite/tool at hand

    // The currently selected crop tile
    //[Header("Selected Block")]
    //[SerializeField] private CropBlock _selectedBlock;
    //public CropBlock SelectedBlock => _selectedBlock; // read-only

    //[Header("Seed Options")]
    //[SerializeField] private SeedPacket[] availableSeeds;
    //private SeedPacket _selectedSeed;

    //[Header("Toolbar Events")]
    //public UnityEvent OnHoe;
    //public UnityEvent OnWater;
    //public UnityEvent OnPlant;
    //public UnityEvent OnHarvest;

    //private void Awake()
    //{
    //    // Ensure UnityEvents are initialized
    //    OnHoe ??= new UnityEvent();
    //    OnWater ??= new UnityEvent();
    //    OnPlant ??= new UnityEvent();
    //    OnHarvest ??= new UnityEvent();

    //    // Hook up default listeners
    //    OnHoe.AddListener(DoHoe);
    //    OnWater.AddListener(DoWater);
    //    OnPlant.AddListener(DoPlant);
    //    OnHarvest.AddListener(DoHarvest);
    //}

    //private void Start()
    //{
    //    // Default to first seed in array
    //    if (availableSeeds.Length > 0)
    //        _selectedSeed = availableSeeds[0];
    //}

    //private void Update()
    //{
    //    if (_selectedBlock == null)
    //    { Debug.Log("No selected block yet"); return; }

        // Keyboard shortcuts (1-4)
        //if (Input.GetKeyDown(KeyCode.Alpha1)) OnHoe?.Invoke();
        //if (Input.GetKeyDown(KeyCode.Alpha2)) OnWater?.Invoke();
        //if (Input.GetKeyDown(KeyCode.Alpha3)) OnPlant?.Invoke();
        //if (Input.GetKeyDown(KeyCode.Alpha4)) OnHarvest?.Invoke();
   // }

    /// <summary>
    /// Assigns the currently selected crop block (from Validator trigger)
    /// </summary>
//    public void SelectBlock(CropBlock cropBlock)
//    {
//        _selectedBlock = cropBlock;
//        if (cropBlock != null)
//            Debug.Log($"Selected block: {cropBlock.name}");
//        else
//            Debug.Log("Cleared selected block");
//    }

//    #region Farming Actions (called by events)

//    private void DoHoe()
//    {
//        if (_selectedBlock != null)
//            _selectedBlock.TillSoil();
//    }

//    private void DoWater()
//    {
//        if (_selectedBlock != null)
//            _selectedBlock.WaterSoil();
//    }

//    private void DoPlant()
//    {
//        if (_selectedBlock != null && _selectedSeed != null)
//            _selectedBlock.PlantSeed(_selectedSeed);
//    }

//    private void DoHarvest()
//    {
//        if (_selectedBlock != null)
//            _selectedBlock.HarvestPlants();
//    }

//    #endregion
}
