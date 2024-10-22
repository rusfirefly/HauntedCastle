using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public static event Action<bool> EscPresed;
    public static event Action MainMenu;
    private Interactable _interactableObject;
    private bool _isEscPresed;


    public void CheckInteractableKeyInput()
    {
        if (_interactableObject)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _interactableObject.OnInteract();
            }
        }
       
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _isEscPresed = true;
            MainMenu?.Invoke();
            EscPresed?.Invoke(_isEscPresed);
        }
    }
    
    public bool IsEscPresed => _isEscPresed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Interactable interactable))
        {
            _interactableObject = interactable;
            _interactableObject.ShowMessage();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (_interactableObject)
            _interactableObject.HideMessage();

        _interactableObject = null;
    }

    public void Resume()
    {
        _isEscPresed = false;
        EscPresed?.Invoke(_isEscPresed);
    }
}
