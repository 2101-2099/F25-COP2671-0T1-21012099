using UnityEngine;
using UnityEngine.Rendering.Universal;

//Lighting script
//required component
[RequireComponent(typeof(Light2D))]
public class DayNightLighting : MonoBehaviour
{
    //variables
    public Gradient dayNightColors;
    public AnimationCurve lightIntensityCurve;

    public Light2D _light;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _light = GetComponent<Light2D>();
    }

    private void OnEnable()
    {
        // Subscribe to the time update event
        TimeManager.OnTimerUpdate.AddListener(UpdateLighting);
    }

    private void OnDisable()
    {
        // Unsubscribe to avoid memory leaks or errors when disabled
        TimeManager.OnTimerUpdate.RemoveListener(UpdateLighting);
    }

    /// <summary>
    /// Called automatically whenever TimeManager updates the normalized time (0–1).
    /// </summary>
    private void UpdateLighting(float normalizedTime)
    {
        if (_light == null) return;

        _light.color = dayNightColors.Evaluate(normalizedTime);
        _light.intensity = lightIntensityCurve.Evaluate(normalizedTime);
    }
}
