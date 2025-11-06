using UnityEngine;

[CreateAssetMenu(fileName = "NewSeedPacket", menuName = "Farming/Seed Packet")]
public class SeedPacket : ScriptableObject
{
    public string cropName;

    public Sprite[] growthSprites;

    public Sprite coverImage;

    public GameObject harvestablePrefab;
}
