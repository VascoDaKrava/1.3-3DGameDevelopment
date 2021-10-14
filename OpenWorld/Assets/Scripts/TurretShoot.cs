using System.Collections;
using UnityEngine;

public class TurretShoot : MonoBehaviour
{
    private Light _shootingLight;
    private ParticleSystem _shootingFX;
    private float _fireInterval = 2f; // One shoot per 2 seconds
    private float _durationFX;
    private float _shootLightIntensity = 50f;

    // Start is called before the first frame update
    void Start()
    {
        _shootingLight = Storage.FindTransformInChildrenWithTag(gameObject, Storage.FlashlightTag).GetComponent<Light>();

        _shootingFX = Storage.FindTransformInChildrenWithTag(gameObject, Storage.ParticleSystemTag).GetComponent<ParticleSystem>();
        _durationFX = _shootingFX.main.duration;

        InvokeRepeating("Fire", 0f, _fireInterval);
    }

    private void Fire()
    {
        _shootingFX.Play();

        _shootingLight.intensity = _shootLightIntensity;
        StartCoroutine(LightFadingFX(_shootLightIntensity, _durationFX));
    }

    /// <summary>
    /// Slowly changing light intensity from maxValue due duration
    /// </summary>
    /// <param name="maxValue">Ligth intensity</param>
    /// <param name="duration">Duration in seconds</param>
    /// <returns></returns>
    IEnumerator LightFadingFX(float maxValue, float duration)
    {
        while (_shootingLight.intensity > 0)
        {
            yield return null;
            _shootingLight.intensity -= maxValue / duration * Time.deltaTime;
        }
    }
}
