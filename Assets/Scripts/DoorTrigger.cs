using UnityEngine;

public class DoorTrigger : Interactable
{
    private bool _isOpenDoor;
    private SoundHandler _soundHandler;
    private Animator _animator;

    private void Awake()
    {
        _soundHandler = GetComponent<SoundHandler>();
        _animator = GetComponent<Animator>();
        Initizlize();
    }

    public override void OnInteract()
    {
        if (_isOpenDoor) return;
        
        OpenDoor();
    }

    private void OpenDoor()
    {
        _animator.SetBool("isOpen", true);
        _soundHandler.Play(1);
        _isOpenDoor = true;
    }


}
