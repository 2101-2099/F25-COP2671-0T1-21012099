using UnityEngine;
using UnityEngine.InputSystem;

//ToolBar script
public class ToolbarController : MonoBehaviour
{
    public FarmingController farmingController;

    void Update()
    {
        if (farmingController == null) return;

        // 1 Hoe
        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            farmingController.OnHoe();
            Debug.Log("OnHoe called");
        }

        // 2 Water
        if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            farmingController.OnWater();
            Debug.Log("OnWater called");
        }

        // 3Plant Seed
        if (Keyboard.current.digit3Key.wasPressedThisFrame)
        {
            farmingController.OnSeed();
            Debug.Log("OnSeed called");
        }

        // 4 Harvest
        if (Keyboard.current.digit4Key.wasPressedThisFrame)
        {
            farmingController.OnGather();
            Debug.Log("OnHarvest called");
        }
    }
}
