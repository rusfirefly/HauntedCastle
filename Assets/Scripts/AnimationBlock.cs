using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SoundHandler))]
public class AnimationBlock : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private SoundHandler _soundHandler;

    private void Start()
    {
        _soundHandler = GetComponent<SoundHandler>();
        _rigidbody = GetComponent<Rigidbody>();
        _soundHandler.Initialize();
    }

    public void DisableKinematic()
    {
        _rigidbody.isKinematic = false;
        Invoke("SoundPlay", 1f);
    }

    private void SoundPlay()
    {
        _soundHandler.Play();
    }
}
