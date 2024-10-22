using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class LoadScene : MonoBehaviour, ILoadRoom
{
    public static LoadScene Instance;
    public event Action<int> NewRoom;

    [SerializeField] private List<LevelView> _levelView;
    [SerializeField] private Transform _playerPosition;
    [SerializeField] private Transform _roomPosition;
    [SerializeField] private bool _isMainMenu;

    private int _levelIndex;
    private int _roomNumber;
    private int _finishRoomIndex = 6;
    private int _startFinushRoom = 3;
    private int _startRoom = 1;
    private int _roomTutorialIndex = 7;

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
        NewRoom?.Invoke(_roomNumber);
    }

    private void Initialize()
    {
        if (Instance.NumberRoom == _startFinushRoom)
        {
            _levelIndex = _finishRoomIndex;
        }
        else
        {
            _levelIndex = (Instance.NumberRoom == _startRoom) ? _roomTutorialIndex : Random.Range(0, _levelView.Count - 2);
        }

        Instantiate(_levelView[_levelIndex], _roomPosition);
        Debug.Log(_levelView[_levelIndex].name);
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
        SceneManager.LoadSceneAsync(_startRoom);
    }
}
