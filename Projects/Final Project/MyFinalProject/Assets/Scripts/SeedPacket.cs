using UnityEngine;

[CreateAssetMenu(fileName = "NewSeedPacket", menuName = "Farming/Seed Packet")]
public class SeedPacket : ScriptableObject
{
    public Sprite[] growthSprites;
    public string cropName;

    public Sprite coverImage;

    public GameObject harvestablePrefab;
}
