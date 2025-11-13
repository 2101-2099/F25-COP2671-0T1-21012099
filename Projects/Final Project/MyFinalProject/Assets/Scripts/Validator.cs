using UnityEngine;
using UnityEngine.Tilemaps;

public class Validator : MonoBehaviour
{
    [SerializeField] private FarmingController farmingController;
    [SerializeField] private CropManager cropManager;
    [SerializeField] private Tilemap farmingTilemap;

    private CropBlock _currentBlock;

    private void Update()
    {
        Vector3Int cell = farmingTilemap.WorldToCell(transform.position);
        CropBlock block = cropManager.GetBlockAtCell(cell); // pseudo-method

        if (block != null)
            Debug.Log("Validator found block: " + block.name);
        else
            //Debug.Log("Validator found NO block at cell: " + cellPos);

        if (_currentBlock != block)
        {
            _currentBlock = block;
            farmingController.SelectBlock(block);
        }
    }
}
