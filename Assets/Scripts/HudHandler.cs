using TMPro;
using UnityEngine;

public class HudHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text _roomNumber;
    [SerializeField] private GameObject _message;
    [SerializeField] private GameObject _gameOver;
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _winMenu;
    [SerializeField] private HudPresenter _presenter;

    public bool IsMessage { get; private set; }

    private void Start()
    {
        _presenter.Inittialize(this);
        HideMessage();
    }

    public void SetNewRoomText(int numberRoom)=>_roomNumber.text = $"Room: {numberRoom}";

    public void ShowMessage()
    {
        SetVisiblePaperMessage(true);
    }

    public void HideMessage() 
    {
        SetVisiblePaperMessage(false);
    }
    
    public void SetVisibleGameOverMessage(bool visible) => _gameOver.gameObject.SetActive(visible);

    public void SetVisibleMenu(bool visible)=> _menu.gameObject.SetActive(visible);
    
    public void SetVisibleWinGame(bool visible)=> _winMenu.gameObject.SetActive(visible);

    private void SetVisiblePaperMessage(bool visible)
    {
        IsMessage = visible;
        _message.gameObject.SetActive(visible);
    }
}
