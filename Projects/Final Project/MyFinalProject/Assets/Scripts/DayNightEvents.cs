using UnityEngine;
using UnityEngine.Events;

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
    [SerializeField] private TimeManager timeManager;

    private bool _isDaytime;

    private void Start()
    {
        if (timeManager != null)
            timeManager.OnUpdateTrigger.AddListener(CheckTime);
    }

    private void OnDestroy()
    {
        if (timeManager != null)
            timeManager.OnUpdateTrigger.RemoveListener(CheckTime);
    }

    private void CheckTime(float normalizedTime)
    {
        // Detect transitions between night/day

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
    }
}
