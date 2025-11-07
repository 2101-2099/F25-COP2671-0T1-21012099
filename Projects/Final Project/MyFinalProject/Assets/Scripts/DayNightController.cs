using UnityEngine;

public class DayNightController : MonoBehaviour
{
    //set starting time at 6:00 am

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TimeManager.SetStartHour(6);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
