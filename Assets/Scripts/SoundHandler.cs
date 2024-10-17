using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class SoundHandler : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _audioClip;
    }

    private void OnValidate()
    {
        _audioSource??= GetComponent<AudioSource>();
    }

    public void Play(float pitch = 1f)
    {
        if (_audioSource.isPlaying == false)
        {
            _audioSource.pitch = pitch;
            _audioSource.Play();
        }
    }

    public void Stop()
    {
        _audioSource.Stop();
    }
}
