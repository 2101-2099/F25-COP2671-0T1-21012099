using UnityEngine;
using UnityEngine.Rendering.Universal;

//required component
[RequireComponent(typeof(Light2D))]
public class DayNightLighting : MonoBehaviour
{
    //variables
    public Gradient dayNightColors;
    public AnimationCurve lightIntensityCurve;

    public Light2D _light;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _light = GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _light.color = dayNightColors.Evaluate(TimeManager.Now);
        _light.intensity = lightIntensityCurve.Evaluate(TimeManager.Now);
    }
}
