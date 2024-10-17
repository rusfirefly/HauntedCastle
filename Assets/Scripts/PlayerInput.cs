
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
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
