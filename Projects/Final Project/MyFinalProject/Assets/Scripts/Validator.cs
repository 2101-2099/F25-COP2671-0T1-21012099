using UnityEngine;
using UnityEngine.Tilemaps;

public class Validator : MonoBehaviour
{
    [SerializeField] private FarmingController farmingController;
    [SerializeField] private CropManager cropManager;
    [SerializeField] private Tilemap cropTilemap; // Reference to the tilemap the crops are on

    private CropBlock _currentBlock;

    private void Update()
    {
        SelectBlockUnderValidator();
        HandleInput();
    }

    private void SelectBlockUnderValidator()
    {
        if (cropManager == null || cropTilemap == null || farmingController == null)
            return;

        // Convert world position to tilemap cell position
        Vector3Int cellPos = cropTilemap.WorldToCell(transform.position);

        // Get the block at that cell
        CropBlock block = cropManager.GetBlockAtCell(cellPos); // You'll need to implement this

        // Only update if the block changed
        if (_currentBlock != block)
        {
            _currentBlock = block;
            farmingController.SelectBlock(_currentBlock);

            if (_currentBlock != null)
                Debug.Log("Selected block: " + _currentBlock.name);
            else
                Debug.Log("No block under Validator");
        }
    }

    private void HandleInput()
    {
        if (_currentBlock == null)
            return;

        if (Input.GetKeyDown(KeyCode.Alpha1))
            farmingController.OnHoe?.Invoke();
        if (Input.GetKeyDown(KeyCode.Alpha2))
            farmingController.OnWater?.Invoke();
        if (Input.GetKeyDown(KeyCode.Alpha3))
            farmingController.OnPlant?.Invoke();
        if (Input.GetKeyDown(KeyCode.Alpha4))
            farmingController.OnHarvest?.Invoke();
    }
}
