using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [field:SerializeField] public InteractiveView InteractiveView { get; private set; }
    [SerializeField, TextArea(3,10)] private string _message;

    public void Initizlize()
    {
        InteractiveView.Inizialize(_message);
    }

    public abstract void OnInteract();

    public void ShowMessage()
    {
        SetVisibleText(true);
    }

    public void HideMessage()
    {
        SetVisibleText(false);
    }

    private void SetVisibleText(bool visible) => InteractiveView.SetVisible(visible); 

    
}
