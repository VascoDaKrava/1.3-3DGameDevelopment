using UnityEngine;

public class DayNightController : MonoBehaviour
{
    private Light _light;

    private Vector3 _sunRotation;
    private Vector3 _sunStartRotation = new Vector3(-25f, 0f, 0f);

    private Color _sunrise = new Color(170f, 40f, 40f) / 255;
    private Color _sunZenith = new Color(240f, 210f, 100f) / 255;
    private Color _moon = new Color(170f, 200f, 200f) / 255;

    private int _dayTime = 120; // Day duration in seconds

    private float _minIntensity = 0.5f;
    private float _maxIntensity = 1.5f;
    private float _moonIntensity = 0.2f;

    private float _zenithAngle = 75f;
    private float _sunsetAngle = 205f;

    private bool _isDay = true;

    // Start is called before the first frame update
    void Start()
    {
        _light = GetComponent<Light>();
        _light.color = _sunrise;
        _light.intensity = _minIntensity;
        _sunRotation = _sunStartRotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(_sunRotation);

        if (_sunRotation.x < _zenithAngle && _isDay)
        {
            _light.color = Color.Lerp(_sunrise, _sunZenith, _sunRotation.x / _zenithAngle);
            _light.intensity = Mathf.Lerp(_minIntensity, _maxIntensity, _sunRotation.x / _zenithAngle);
        }
        else if ((_sunRotation.x > (180 - _zenithAngle)) && (_sunRotation.x < _sunsetAngle) && _isDay)
        {
            _light.color = Color.Lerp(_sunZenith, _sunrise, (_sunRotation.x - 90f) / _zenithAngle);
            _light.intensity = Mathf.Lerp(_maxIntensity, _minIntensity, (_sunRotation.x - 90f) / _zenithAngle);
        }
        else if (_sunRotation.x > _sunsetAngle)
        {
            _sunRotation = _sunStartRotation;
            _isDay = !_isDay;
            if (_isDay)
            {
                RenderSettings.skybox.SetFloat("_AtmosphereThickness", 1f);
            }
            else
            {
                _light.color = _moon;
                _light.intensity = _moonIntensity;
                RenderSettings.skybox.SetFloat("_AtmosphereThickness", 0.1f);
            }
        }
        _sunRotation.x += Time.deltaTime * 180f / _dayTime;
    }
}
