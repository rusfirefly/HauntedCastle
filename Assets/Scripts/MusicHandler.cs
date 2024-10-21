using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicHandler : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void OnValidate()
    {
        _audioSource??=GetComponent<AudioSource>();
    }
}
