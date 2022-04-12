using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class EndLevel : MonoBehaviour
{
    // [SerializeField] GameObject _openedChest    = null;
    [SerializeField] GameObject _alertPanel     = null;
    public bool reachedTheEnd                   = false;

    private LevelKey _levelKey                  = null;
    private AudioSource _audioSource            = null;

    private void Start() 
    {
        _levelKey = FindObjectOfType<LevelKey>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other) 
    {
        Player _player = other.gameObject.GetComponent<Player>();
        if (_player != null)
        {
            if (_levelKey.IsCollected()) 
            {
                _audioSource.Play();
                this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
                this.gameObject.transform.GetChild(1).gameObject.SetActive(true);
                reachedTheEnd = true; 
            }
            else { if (_alertPanel) { _alertPanel.SetActive(true); }}
        }

    }

    private void OnTriggerExit(Collider other) {
        Player _player = other.gameObject.GetComponent<Player>();
        if (_player && _alertPanel) { _alertPanel.SetActive(false); }
    }
}
