using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{

    private AudioSource _volumeLevel;
    private Slider _volumeSlider;
    private GameManager _gameManager;
    

    // Start is called before the first frame update
    void Start()
    {
        _volumeLevel = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        _volumeSlider = GameObject.Find("Volume Slider").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        _volumeLevel.volume = _volumeSlider.value;
    }
}
