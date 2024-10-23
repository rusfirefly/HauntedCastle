using System;
using UnityEngine;

public class FinishHandler : MonoBehaviour
{
    public static event Action Finish;
    private SoundHandler _soundHandler;

    private void Start()
    {
        _soundHandler = GetComponent<SoundHandler>();   
        _soundHandler.Initialize(); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out FirstPersonController player))
        {
            _soundHandler.Play();
            GhostMove ghost = FindAnyObjectByType<GhostMove>();
            
            if(ghost)
            {
                ghost.Restart();
            }

            Cursor.lockState = CursorLockMode.Confined;
            player.DisableInput();
            Finish?.Invoke();
        }
    }
}
