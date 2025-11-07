using UnityEngine;

[CreateAssetMenu(fileName = "NewSeedPacket", menuName = "Farming/Seed Packet")]
public class SeedPacket : ScriptableObject
{
    //seed
    //sprout
    //young
    //mature
    //public enum CropStage
    //{
       // Seed,
       // Sprout,
       // Young,
        //Mature
    //
    // in growthsprite I want the sprite I want to make it in each element above each sprite is a dropdown that allows me to choose if it is a seed, sprout, young, or mature sprite 
    //probably make it a header that groups growth sprite with cropstage. Probably make different headers
    public Sprite[] growthSprites;
    public string cropName;

    public Sprite coverImage;

    public GameObject harvestablePrefab;
}
