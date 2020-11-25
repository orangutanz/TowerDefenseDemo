using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _Instance;
    public AudioSource _audioSource;
    public AudioClip _coin;
    // Start is called before the first frame update
    void Start()
    {
        _Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static AudioManager Get()
    {
        if(_Instance == null)
        {
            _Instance = new AudioManager();
        }
        return _Instance;
    }

    public void PlayCoinSound()
    {
        _audioSource.clip = _coin;
        _audioSource.Play();
    }
}
