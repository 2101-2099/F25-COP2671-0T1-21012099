using UnityEngine;
//Set starting time
public class DayNightController : MonoBehaviour
{
    [Range(0, 23)]
    public int startHour = 6;

    private void Start()
    {
        // Set the starting hour in TimeManager
        TimeManager.SetStartHour(startHour);
    }
}
