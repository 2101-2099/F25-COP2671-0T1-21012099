using UnityEngine;

public class Seedling : MonoBehaviour
{
    public enum GrowthStage
    {
        None = -1,
        Seed = 0,
        Sprout = 1,
        Young = 2,
        Mature = 3,
    }
    public Sprite[] growthSprites;
    public Sprite seedCover;
    public CropYield cropYield;
    public bool readyToHarvest;

    private SpriteRenderer spriteRenderer;
    private GrowthStage currentStage = GrowthStage.None;
    [SerializeField] private bool nextDay;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        seedCover = spriteRenderer.sprite;
        spriteRenderer.sprite = null;
    }
    private void Update()
    {
        if (nextDay == false || currentStage > GrowthStage.Mature) { return;}
        
        currentStage++;

        spriteRenderer.sprite = growthSprites[(int)currentStage];
         
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.TryGetComponent)
        readyToHarvest = currentStage == GrowthStage.Mature;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        readyToHarvest = false;
    }

    public void convertToYield()
    {
        var yield = Instantiate(cropYield, transform);
        yield.transform.SetParent(null);
        Destroy(gameObject);
    }
}
