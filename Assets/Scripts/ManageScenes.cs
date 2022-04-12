using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ManageScenes : MonoBehaviour
{
    [SerializeField] GameObject _pausePanel         = null;
    [SerializeField] TextMeshProUGUI _escText       = null;

    private CheckForWin _checkForWin;
    private FirstPersonController _fpsController    = null;

    private bool _isPaused                          = false;
    private int _currentScene;

    private void Start() {
        _currentScene = SceneManager.GetActiveScene().buildIndex;
        _fpsController = FindObjectOfType<FirstPersonController>();
        _checkForWin = FindObjectOfType<CheckForWin>();

        if (_currentScene != 0) { Cursor.visible = false; }
        if (_pausePanel) { _pausePanel.SetActive(false); }
    }

    private void Update() {
        if (!_checkForWin) { return; }
        if (!_checkForWin.ReturnDidWin()) { PauseResumeGame(); }
        // SetCursor();
    }

    private void PauseResumeGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(_isPaused == false) { PauseGame(); }
            // else {  ResumeGame();  }
        }
    }

    public void PauseGame()
    {
        _isPaused = true;
        _fpsController.gameObject.GetComponentInChildren<FirstPersonController>().enabled = false;
        Cursor.visible = true;
        Time.timeScale = 0;
        if ( _escText ) { _escText.enabled = false; }
        _pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        _isPaused = false;
        _fpsController.gameObject.GetComponentInChildren<FirstPersonController>().enabled = true;
        Cursor.visible = false;
        Time.timeScale = 1;
        if (_escText) { _escText.enabled = true; }
        _pausePanel.SetActive(false);
    }

    public void ResetLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(_currentScene);
        ResumeGame();
    }

    public void BackToMenu() { SceneManager.LoadScene("MainMenu"); }

    public void NextLevel() { if (_checkForWin.ReturnDidWin()) { SceneManager.LoadScene(_currentScene + 1); } }

    public void LoadSettings() { SceneManager.LoadScene("Settings"); }

    public void StartGame()
    {
        SceneManager.LoadScene("SplashScreen");
        Time.timeScale = 1;
    }

    public void QuitGame() { Application.Quit(); }

    public bool ReturnIsPaused() => _isPaused;

    // private void SetCursor() { Cursor.visible = _isPaused; }

}
