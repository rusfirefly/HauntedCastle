using UnityEngine;

public class ScareView : MonoBehaviour, IScare
{
    [SerializeField] private MeshRenderer _faceImage;
    [SerializeField] private MeshRenderer _backImage;

    public void Show()
    {
        SetVisibleTexture(true);
    }

    public void Hide()
    {
        SetVisibleTexture(false);
    }

    private void SetVisibleTexture(bool visible)
    {
        _faceImage.enabled = visible;
        _backImage.enabled = visible;
    }
}
