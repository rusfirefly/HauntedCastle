using TMPro;
using UnityEngine;

public class HudHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text _roomNumber;
    [SerializeField] private GameObject _message;

    public bool IsMessage { get; private set; }

    private void Start()
    {
        HideMessage();
    }

    private void OnEnable()
    {
        if (LoadScene.Instance)
            LoadScene.Instance.NewRoom += OnNewRoom;

        PlayerInput.CloseButton += OnCloseButton;
    }

    private void OnDisable()
    {
        if (LoadScene.Instance)
            LoadScene.Instance.NewRoom -= OnNewRoom;

        PlayerInput.CloseButton += OnCloseButton;
    }

    private void OnCloseButton()
    {
        HideMessage();
    }

    private void OnNewRoom(int numberRoom)
    {
        _roomNumber.text = $"Room: {numberRoom}";
    }

    public void ShowMessage()
    {
        IsMessage = true;
        _message.gameObject.SetActive(true);
    }

    public void HideMessage() 
    {
        IsMessage = false;
        _message.gameObject.SetActive(false); 
    }
    
}
