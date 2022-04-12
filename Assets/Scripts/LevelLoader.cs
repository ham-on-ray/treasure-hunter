using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [Range(1,5)] [SerializeField] float _loadingTime = 3;
    private float _timer = 0;
    private bool _timerIsRunning = false;
    private int _currentScene = 0;
    
    private Slider _slider;

    void Start()
    {
        _currentScene = SceneManager.GetActiveScene().buildIndex;
        SetSlider();
        _timerIsRunning = true;
    }

    private void SetSlider()
    {
        _timer = Time.timeSinceLevelLoad;

        _slider = GetComponentInChildren<Slider>();
        _slider.minValue = 0;
        _slider.maxValue = _loadingTime;
        _slider.value = _timer;
    }

    void Update()
    {
        if (_timerIsRunning)
        {
            if (_loadingTime > _timer )
            {
                _timer += Time.deltaTime;
                _slider.value = _timer;
            }
            else
            {
                // _timer = _loadingTime;
                _timerIsRunning = false;
                SceneManager.LoadScene(_currentScene + 1);
            }
        }
    }

}
