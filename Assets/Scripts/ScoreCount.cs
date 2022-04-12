using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCount : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _scoreText             = null;

    private int _totalScore                                 = 0;

    private void Update() {
        ReturnScore();
    }
    
    public void AddScore(int score) { _totalScore += score; }
    public void ReturnScore() { if(_scoreText != null) { _scoreText.text = "" + _totalScore; } }
    public string ReturnTotalScore() => "" + _totalScore;
}
