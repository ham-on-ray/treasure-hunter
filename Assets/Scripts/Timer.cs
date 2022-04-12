using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    // [SerializeField] bool _hasTimer                 = false;
    [SerializeField] TextMeshProUGUI _timerText     = null;

    private CheckForWin _checkForWin                = null;

    private float _time                             = 0.0f;
    private float _minutes                          = 0.0f;
    private float _seconds                          = 0.0f;

    private void Start() 
    {
        _checkForWin = FindObjectOfType<CheckForWin>();    
    }

    void Update()
    {
        if (!_checkForWin.ReturnDidWin()) { RunTimer(); }
    }

    private void RunTimer() 
    { 
        _time += Time.deltaTime;
        ReturnTime();
    }

    private void ReturnTime()
    {
        _minutes = Mathf.FloorToInt(_time / 60);
        _seconds = Mathf.FloorToInt(_time % 60);

        if(_timerText != null) { _timerText.text = string.Format("{0:00}:{1:00}", _minutes, _seconds); }
    }

    public string ReturnTimeInTimeFormat() =>  string.Format("{0:00}:{1:00}", _minutes, _seconds);
}
