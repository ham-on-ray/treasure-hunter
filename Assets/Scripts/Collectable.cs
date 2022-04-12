using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (AudioSource))]
public class Collectable : MonoBehaviour
{
    [Range(80, 90)] [SerializeField] protected int _rotationSpeed                   = 90;
    [Range(5, 25)] [SerializeField] protected int _score                            = 5;
    [Range(0.01f, 0.5f)] [SerializeField] protected float _disappearPeriod          = 0.1f;
    [SerializeField] protected List<AudioClip> _audoiClips                          = new List<AudioClip>();
    [SerializeField] protected List<ParticleSystem> _particles                      = new List<ParticleSystem>();

    protected ScoreCount _scoreCount;
    protected AudioSource _audioSource;

    protected int _randomDir = 1;
    protected int _randomRS = 0;

    protected void Start() 
    {
        _scoreCount = FindObjectOfType<ScoreCount>();
        _audioSource = GetComponent<AudioSource>();

        _randomRS = Random.Range(_rotationSpeed - 10, _rotationSpeed);
        _randomDir = (Random.Range(0,2) * 2) - 1;
    }

    protected virtual void Update() 
    {
        transform.RotateAround(transform.position, transform.up, Time.deltaTime * _randomRS * _randomDir);
    }

    protected virtual void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
            // print(this.gameObject.name);
            _scoreCount.AddScore(_score);
            Destroying();
        }    
    }

    protected void Destroying()
    {
        // add sound effect
        _audioSource.Play();
        GetComponent<MeshRenderer>().enabled = false;
        // add visual effect

        Destroy(this.gameObject, _disappearPeriod);
    }

}
