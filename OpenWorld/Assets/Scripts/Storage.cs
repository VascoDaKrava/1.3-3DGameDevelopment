using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Audio;

public class Storage : MonoBehaviour
{
    [SerializeField] private AudioMixer _mixer;
    [SerializeField] List<AudioClip> _musicClips;

    private void Awake()
    {
        // Load audio settings
        if (Settings.VolumeMute)
            _mixer.SetFloat(VolumeNameMaster, -80f);
        else
            _mixer.SetFloat(VolumeNameMaster, Settings.VolumeMaster);
        
        _mixer.SetFloat(VolumeNameMusic, Settings.VolumeMusic);
        _mixer.SetFloat(VolumeNameMenu, Settings.VolumeMenu);
        _mixer.SetFloat(VolumeNameFX, Settings.VolumeFX);
    }

    #region Static for Volume

    private static string _mixerMaster = "MasterVolume";
    private static string _mixerMusic = "MusicVolume";
    private static string _mixerMenu = "MenuVolume";
    private static string _mixerFX = "FXVolume";

    public static string VolumeNameMaster { get { return _mixerMaster; } }
    public static string VolumeNameMusic { get { return _mixerMusic; } }
    public static string VolumeNameMenu { get { return _mixerMenu; } }
    public static string VolumeNameFX { get { return _mixerFX; } }

    #endregion

    #region Static for Tags

    private static string _playerHeadTag = "PlayerHead";// 00
    private static string _weaponPosTag = "WeaponPositionTag";// 01
    private static string _globalTag = "GlobalScript";// 02
    private static string _weaponTag = "Weapon";// 03
    private static string _bullet1StartPositionTag = "BulletStart1";// 04
    private static string _healthUI = "UI_health";// 05
    private static string _bulletsUI = "UI_bullets";// 06
    private static string _UI = "UI";// 07
    private static string _audioSource = "AudioSource";// 08
    private static string _particleSystem = "ParticleSystem";// 09
    private static string _flashlight = "Flashlight";// 10

    public static string GlobalTag { get { return _globalTag; } }
    public static string WeaponPositionTag { get { return _weaponPosTag; } }
    public static string WeaponTag { get { return _weaponTag; } }
    public static string Bullet1StartPositionTag { get { return _bullet1StartPositionTag; } }
    public static string PlayerHeadTag { get { return _playerHeadTag; } }
    public static string HealthUITag { get { return _healthUI; } }
    public static string BulletsUITag { get { return _bulletsUI; } }
    public static string UITag { get { return _UI; } }
    public static string AudioSourceTag { get { return _audioSource; } }
    public static string ParticleSystemTag { get { return _particleSystem; } }
    public static string FlashlightTag { get { return _flashlight; } }

    private static string _untagged = "Untagged";
    private static string _mainCamera = "MainCamera";
    private static string _playerTag = "Player";
    public static string PlayerTag { get { return _playerTag; } }
    public static string MainCameraTag { get { return _mainCamera; } }
    public static string Untagged { get { return _untagged; } }

    #endregion

    #region Static methods

    /// <summary>
    /// Find transform with "tag" in children of "gameObj"
    /// </summary>
    /// <param name="gameObj">GameObject, where searching</param>
    /// <param name="tag">Tag for searched transform</param>
    /// <returns></returns>
    public static Transform FindTransformInChildrenWithTag(GameObject gameObj, string tag)
    {
        foreach (Transform item in gameObj.GetComponentsInChildren(typeof(Transform)))
        {
            if (item.CompareTag(tag))
                return item;
        }
        return null;
    }

    /// <summary>
    /// Find ALL transforms with "tag" in children of "gameObj", return as LIST
    /// </summary>
    /// <param name="gameObj"></param>
    /// <param name="tag"></param>
    /// <returns></returns>
    public static List<Transform> FindALLTransformInChildrenWithTag(GameObject gameObj, string tag)
    {
        List<Transform> result = new List<Transform>();
        foreach (Transform item in gameObj.GetComponentsInChildren(typeof(Transform)))
        {
            if (item.CompareTag(tag))
                result.Add(item);
        }
        return result;
    }

    /// <summary>
    /// Translate X-rotation angle of transform to humanity-like variant (0-360 degree)
    /// </summary>
    /// <param name="trans"></param>
    /// <returns></returns>
    public static float ToAngleX(Transform trans)
    {
        return trans.eulerAngles.x > 90 ?
                Mathf.Abs(trans.eulerAngles.z * 3 - trans.eulerAngles.x) :
                Mathf.Abs(trans.eulerAngles.z - trans.eulerAngles.x);
    }

    /// <summary>
    /// Translate Y-rotation angle of transform to humanity-like variant (0-360 degree)
    /// </summary>
    /// <param name="trans"></param>
    /// <returns></returns>
    public static float ToAngleY(Transform trans)
    {
        return (trans.eulerAngles.y - trans.parent.eulerAngles.y < 0) ? trans.eulerAngles.y - trans.parent.eulerAngles.y + 360 : trans.eulerAngles.y - trans.parent.eulerAngles.y;
    }

    /// <summary>
    /// Write message to Unity log from current class and method
    /// </summary>
    /// <param name="obj">Current class. Write - this</param>
    /// <param name="met">Current method. Write - Storage.GetCallerName()</param>
    /// <param name="message">Message for logging</param>
    public static void ToLog(Object obj, string met, string message)
    {
        Debug.Log($"{obj.GetType()} : {met} - {message}");
    }

    /// <summary>
    /// Get name of current method
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static string GetCallerName([CallerMemberName] string name = "")
    {
        return name;
    }

    #endregion
}