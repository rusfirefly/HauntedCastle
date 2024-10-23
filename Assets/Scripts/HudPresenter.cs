using System;
using UnityEngine;

[RequireComponent(typeof(HudHandler))]
public class HudPresenter: MonoBehaviour
{
    private HudHandler _hudHandler;

    public void Inittialize(HudHandler hudHandler)
    {
        _hudHandler = hudHandler;
    }

    private void OnValidate()
    {
        _hudHandler ??= GetComponent<HudHandler>();
    }

    private void OnEnable()
    {
        if (LoadScene.Instance)
        {
            LoadScene.Instance.NewRoom += OnNewRoom;
        }

        PlayerInput.MainMenu += OnMainMenu;
        FirstPersonController.DeathPlayer += OnDeathPlayer;
        FinishHandler.Finish += OnFinish;
    }

    private void OnMainMenu()
    {
        Cursor.lockState = CursorLockMode.Confined;
        _hudHandler.SetVisibleMenu(true);
    }

    private void OnDisable()
    {
        if (LoadScene.Instance)
        {
            LoadScene.Instance.NewRoom -= OnNewRoom;
        }

        PlayerInput.MainMenu -= OnMainMenu;
        FirstPersonController.DeathPlayer -= OnDeathPlayer;
        FinishHandler.Finish -= OnFinish;
    }

    private void OnFinish()
    {
        Time.timeScale = 0;
        _hudHandler.SetVisibleWinGame(true);
    }

    private void OnDeathPlayer()
    {
        if (_hudHandler)
        {
            //Time.timeScale = 0;
            _hudHandler.SetVisibleGameOverMessage(true);
        }
    }

    private void OnNewRoom(int numberRoom) => _hudHandler.SetNewRoomText(numberRoom);
}
