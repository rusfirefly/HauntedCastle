using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public static event Action CloseButton;
    private Interactable _interactableObject;

    public void CheckInteractableKeyInput()
    {
        if (_interactableObject)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _interactableObject.OnInteract();
            }
        }

        if(Input.GetKeyDown(KeyCode.Tab))
        {
            CloseButton.Invoke();
        }
    }

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
}
