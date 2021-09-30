using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUI_script : MonoBehaviour
{
    private PlayerScript _player;

    [SerializeField] private Texture2D _banana;

    private Rect _boxRect = new Rect(20, 20, 110, 100);
    private Rect _labelRect = new Rect(25, 25, 100, 25);
    private Rect _sliderRect = new Rect(25, 50, 100, 25);
    private Rect _bananaIcoRect = new Rect(25, 75, 25, 25);
    private Rect _bananaTextRect = new Rect(80, 75, 25, 25);

    private float _healthMin = 0f;
    private float _healthMax = 100f;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag(Storage.PlayerTag).GetComponent<PlayerScript>();
    }

    private void OnGUI()
    {
        GUI.Box(_boxRect, "");

        GUI.Label(_labelRect, $"HEALTH\t{_player.Health:d3}");

        GUI.HorizontalSlider(_sliderRect, _player.Health, _healthMin, _healthMax);

        GUI.DrawTexture(_bananaIcoRect, _banana);

        GUI.Label(_bananaTextRect, _player.Bananas.ToString());
    }
}
