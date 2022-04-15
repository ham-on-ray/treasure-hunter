using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float healthAmount = 12f;
    [SerializeField] GameObject diePanel = null;

    private Timer _timer = null;
    private ScoreCount _scoreCount = null;
    private ManageScenes _manageScenes;
    private TextMeshProUGUI _timeText = null;
    private TextMeshProUGUI _scoresCountText = null;

    private void Start() {
        _scoreCount = FindObjectOfType<ScoreCount>();
        _timer = FindObjectOfType<Timer>();

        if (diePanel)
        {
            diePanel.SetActive(false);
            _timeText = diePanel.gameObject.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
            _scoresCountText = diePanel.gameObject.transform.GetChild(4).GetComponent<TextMeshProUGUI>();
        }
        _manageScenes = FindObjectOfType<ManageScenes>();
    }
    public void ReduceHealth(float hitAmount)
    {
        healthAmount -= hitAmount;
        if (healthAmount<=0) { PlayerDie(); }
    }

    private void PlayerDie() 
    {
        _manageScenes.isPaused = true;
        _manageScenes.SetCursor();

        Time.timeScale = 0;
        if(diePanel) diePanel.SetActive(true);
        _scoresCountText.text = _scoreCount.ReturnTotalScore();
        _timeText.text = _timer.ReturnTimeInTimeFormat();
    }
}
