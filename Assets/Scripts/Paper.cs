
using UnityEngine;

public class Paper : Interactable
{
    private GhostMove _ghostMove;
    private HudHandler _hudHandler;

    private void Start()
    {
        _ghostMove = FindAnyObjectByType<GhostMove>();
        _hudHandler = FindAnyObjectByType<HudHandler>();
    }

    public override void OnInteract()
    {
        Cursor.lockState = CursorLockMode.Confined;
        _hudHandler.ShowMessage();
    }

    private void OnTriggerExit(Collider other)
    {
        if (_hudHandler.IsMessage)
        {
            _hudHandler.HideMessage();
            _ghostMove.Move();
        }
    }
}
