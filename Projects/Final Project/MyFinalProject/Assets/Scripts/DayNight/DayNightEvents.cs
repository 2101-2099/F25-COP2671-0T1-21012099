using UnityEngine;
using UnityEngine.Events;

//Day Night Events
public class DayNightEvents : MonoBehaviour
{
    //variables
    [Header("Time Thresholds")]
    [Range(0f, 1f)]
    [Tooltip("When the sun rises (0 = midnight, 0.25 = 6AM, 0.5 = noon, etc.)")]
    [SerializeField] private float _sunriseTime = 0.25f; // 6 AM

    //[Range(0f, 1f)]
    //[Tooltip("When the sun rises (0 = midnight, 0.25 = 6AM, 0.5 = noon, etc.)")]
    //[SerializeField] private float _midnightTime = 0f; //midnight

    [Range(0f, 1f)]
    [Tooltip("When the sun sets (0 = midnight, 0.75 = 6PM, etc.)")]
    [SerializeField] private float _sunsetTime = 0.75f;  // 6 PM

    [Header("Events")]
    public UnityEvent OnSunrise;
    public UnityEvent OnSunset;
    public UnityEvent OnMidnight;

    private float _previousTime = 0f;

    public bool _isDaytime = true;
    private bool _hasTriggeredMidnight;

    private void OnEnable()
    {
        // Subscribe to TimeManager’s normalized time updates
        TimeManager.OnTimerUpdate.AddListener(CheckTime);
    }

    private void OnDisable()
    {
        // Unsubscribe cleanly
        TimeManager.OnTimerUpdate.RemoveListener(CheckTime);
    }


    private void CheckTime(float normalizedTime)
    {

        // Sunrise: was night, now time >= sunrise and before sunset
        if (!_isDaytime && normalizedTime >= _sunriseTime && normalizedTime < _sunsetTime)
        {
            _isDaytime = true;
            OnSunrise?.Invoke();
            Debug.Log("Sunrise");

        }

        // Sunset: was day, now time >= sunset or wrapped around to 0
        else if (_isDaytime && (normalizedTime >= _sunsetTime || normalizedTime < _sunriseTime))
        {
            _isDaytime = false;
            OnSunset?.Invoke();
            Debug.Log("Sunset");
        }

        // --- Midnight ---
        // Detect wrap-around from near 1 back to 0 (start of new day)
        if (_previousTime > 0.9f && normalizedTime < 0.1f && !_hasTriggeredMidnight)
        {
            _hasTriggeredMidnight = true;
            OnMidnight?.Invoke();
            Debug.Log("Midnight triggered");
        }

        // Reset midnight trigger once we’ve moved past the early part of the day
        if (normalizedTime > 0.1f)
        {
            _hasTriggeredMidnight = false;
        }

        _previousTime = normalizedTime;
    }
}
