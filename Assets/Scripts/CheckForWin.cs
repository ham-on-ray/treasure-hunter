using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CheckForWin : MonoBehaviour
{
    [SerializeField] GameObject _resultPanel;
    
    private EndLevel _endLevel                      = null;
    private ScoreCount _scoreCount                  = null;
    private Timer _timer                            = null;
    private ManageScenes _manageScenes              = null;

    private TextMeshProUGUI _timeText               = null;
    private TextMeshProUGUI _scoresCountText        = null;
    private bool _didWin                            = false;

    void Start()
    {
        Cursor.visible = false;
        _endLevel = FindObjectOfType<EndLevel>();
        _scoreCount = FindObjectOfType<ScoreCount>();
        _timer = FindObjectOfType<Timer>();
        _manageScenes = FindObjectOfType<ManageScenes>();

        if (_resultPanel) 
        { 
            _resultPanel.SetActive(false);
            _timeText = _resultPanel.gameObject.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
            _scoresCountText = _resultPanel.gameObject.transform.GetChild(4).GetComponent<TextMeshProUGUI>();
        }
    }

    void Update() 
    { 
        CheckIfWin();
        SetResultPanel();
    }

    private void CheckIfWin() { if (_endLevel) { if (_endLevel.reachedTheEnd) { _didWin = true; } } }

    private void SetResultPanel()
    {
        if (_didWin)
        {
            // Cursor.visible = true;
            _manageScenes.isPaused = true;
            _manageScenes.SetCursor();
            
            Time.timeScale = 0;
            _resultPanel.SetActive(true);
            _scoresCountText.text = _scoreCount.ReturnTotalScore();
            _timeText.text = _timer.ReturnTimeInTimeFormat();
        }
    }

    public bool ReturnDidWin() => _didWin; 

}
