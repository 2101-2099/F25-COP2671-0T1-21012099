using UnityEngine;
using UnityEngine.Tilemaps;

public class CropManager : MonoBehaviour
{
    public Tilemap farmingTilemap;
    public GameObject cropBlockPrefab;  // A prefab containing CropBlock

    private CropBlock[,] cropGrid;
    private Vector3Int boundsMin;
    private Vector3Int boundsMax;

    private void Start()
    {
        CreateGridUsingTilemap(farmingTilemap);
    }

    public void CreateGridUsingTilemap(Tilemap tilemap)
    {
        tilemap.CompressBounds();

        boundsMin = tilemap.cellBounds.min;
        boundsMax = tilemap.cellBounds.max;

        int width = boundsMax.x - boundsMin.x;
        int height = boundsMax.y - boundsMin.y;

        cropGrid = new CropBlock[width, height];

        foreach (Vector3Int cell in tilemap.cellBounds.allPositionsWithin)
        {
            if (!tilemap.HasTile(cell))
                continue;

            Vector2Int gridPos = new Vector2Int(cell.x - boundsMin.x, cell.y - boundsMin.y);
            Vector3 worldPos = tilemap.GetCellCenterWorld(cell);

            CreateGridBlock(tilemap, gridPos, worldPos);
        }

        Debug.Log("Crop grid created (debug only).");
    }

    public void CreateGridBlock(Tilemap tilemap, Vector2Int location, Vector3 position)
    {
        GameObject go = Instantiate(cropBlockPrefab, position, Quaternion.identity);
        CropBlock block = go.GetComponent<CropBlock>();

        block.gridPosition = location;
        block.worldPosition = position;

        cropGrid[location.x, location.y] = block;

        Debug.Log($"Created CropBlock at {location}");
    }

    public CropBlock GetCropBlock(Vector3Int cell)
    {
        Vector2Int pos = new Vector2Int(cell.x - boundsMin.x, cell.y - boundsMin.y);

        if (pos.x < 0 || pos.y < 0 || pos.x >= cropGrid.GetLength(0) || pos.y >= cropGrid.GetLength(1))
            return null;

        return cropGrid[pos.x, pos.y];
    }
}
