using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class LoadScene : MonoBehaviour, ILoadRoom
{
    private enum SceneID {FinishRoom = 6, StartFinishRoomNumber = 35, StartRoom = 1, RoomTutorial = 7, MainScene = 0}

    public static LoadScene Instance;
    public event Action<int> NewRoom;

    [SerializeField] private List<LevelView> _levelView;
    [SerializeField] private Transform _playerPosition;
    [SerializeField] private Transform _roomPosition;
    [SerializeField] private bool _isMainMenu;

    private IRestart[] restarts;
    private int _levelIndex;
    private int _roomNumber;

    public int NumberRoom=>_roomNumber;
 
    private void Awake()
    {
        if (_isMainMenu) return;

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            _roomNumber = 1;
        }
        else
        {
            if (Instance == this)
            {
                Destroy(gameObject);
            }
        }

        Initialize();

        restarts = FindAllRestaringObjects();
        NewRoom?.Invoke(_roomNumber);
    }

    private void Initialize()
    {
        if (Instance.NumberRoom == (int)SceneID.StartFinishRoomNumber)
        {
            _levelIndex = (int)SceneID.FinishRoom;
            RenderSettings.fogDensity = 0.089f;
            RenderSettings.fogColor = Random.ColorHSV();
        }
        else
        {
           _levelIndex = (Instance.NumberRoom == (int)SceneID.StartRoom) ? (int)SceneID.RoomTutorial : Random.Range(0, _levelView.Count - 2);
        }

        Instantiate(_levelView[_levelIndex], _roomPosition);
        SetNewPositionPlayer();
    }

    public void NextRoom()
    {
        StartCoroutine(AsyncLoad());
        _roomNumber++;
    }

    private void SetNewPositionPlayer()=> _playerPosition.position = _levelView[_levelIndex].PlayerPosition.position;

    private IEnumerator AsyncLoad()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        AsyncOperation asynkLoad = SceneManager.LoadSceneAsync(currentSceneName);

        while (asynkLoad.isDone == false)
        {
            yield return null;
        }


        NewRoom?.Invoke(_roomNumber);
    }

    public void LoadFirstRoom()
    {
        SceneManager.LoadSceneAsync((int)SceneID.StartRoom);
    }

    public void RestartGame()
    {
        Instance._roomNumber = 1;
        
        Debug.Log(restarts.Length);

        foreach (IRestart restart in restarts)
        {
            restart.Restart();
        }

        Time.timeScale = 1;
        LoadFirstRoom();
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void LoadSceneMain() => SceneManager.LoadSceneAsync((int)SceneID.MainScene);

    private IRestart[] FindAllRestaringObjects() => FindObjectsOfType<MonoBehaviour>().OfType<IRestart>().ToArray();
}
