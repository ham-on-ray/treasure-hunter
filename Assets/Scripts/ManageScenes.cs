using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using FPSControllerLPFP;
// using FPSControllerLPFP;

public class ManageScenes : MonoBehaviour
{
    [SerializeField] GameObject _pausePanel                             = null;
    [SerializeField] TextMeshProUGUI _escText                           = null;

    private CheckForWin _checkForWin;
    private FirstPersonController _fpsController                        = null;
    private FPSControllerLPFP.FpsControllerLPFP _fpsControllerLPFP      = null;

    public bool isPaused                                                = false;
    private int _currentScene;

    private void Start() {
        _currentScene = SceneManager.GetActiveScene().buildIndex;
        _fpsController = FindObjectOfType<FirstPersonController>();
        _fpsControllerLPFP = FindObjectOfType<FpsControllerLPFP>();
        _checkForWin = FindObjectOfType<CheckForWin>();

        if (_currentScene != 0) 
        {
            // Cursor.visible = false;
            // Cursor.lockState = CursorLockMode.Locked; 
            SetCursor();
        }
        if (_pausePanel) { _pausePanel.SetActive(false); }
    }

    private void Update() {
        if (!_checkForWin) { return; }
        if (!_checkForWin.ReturnDidWin()) { PauseResumeGame(); }
    }

    private void PauseResumeGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused == false) { PauseGame(); }
            else {  ResumeGame();  }
            SetCursor();
        }
    }

    public void PauseGame()
    {
        isPaused = true;


        SetCursor();
        // if ( _fpsController ) _fpsController.gameObject.GetComponentInChildren<FirstPersonController>().enabled = false;
        // if ( _fpsControllerLPFP ) _fpsControllerLPFP.gameObject.GetComponentInChildren<FpsControllerLPFP>().enabled = false;
        // Cursor.visible = true;
        // Cursor.lockState = CursorLockMode.Confined;
        // if ( _fpsControllerLPFP ) _fpsControllerLPFP.enabled = false;

        
        Time.timeScale = 0;
        if ( _escText ) { _escText.enabled = false; }
        _pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        isPaused = false;


        SetCursor();
        // if (_fpsController) _fpsController.gameObject.GetComponentInChildren<FirstPersonController>().enabled = true;
        // if (_fpsControllerLPFP) _fpsControllerLPFP.gameObject.GetComponentInChildren<FpsControllerLPFP>().enabled = true;
        // if (_fpsControllerLPFP) _fpsControllerLPFP.enabled = true;
        // Cursor.visible = false;


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

    public bool ReturnIsPaused() => isPaused;

    public void SetCursor() 
    { 
        if (isPaused)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            // if (_fpsControllerLPFP) _fpsControllerLPFP.enabled = false;
            if (_fpsControllerLPFP) _fpsControllerLPFP.gameObject.GetComponentInChildren<FpsControllerLPFP>().enabled = false;

        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            // if (_fpsControllerLPFP) _fpsControllerLPFP.enabled = true;
            if (_fpsControllerLPFP) _fpsControllerLPFP.gameObject.GetComponentInChildren<FpsControllerLPFP>().enabled = true;

        }
    }

}
