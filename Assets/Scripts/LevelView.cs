using System.Collections.Generic;
using UnityEngine;

public class LevelView : MonoBehaviour
{
    private enum ScareVisible { Show, Hide};

    [SerializeField] private Transform _spawnPlayerPosition;
    [SerializeField] private List<GameObject> _objects;
    [SerializeField] private List<Transform> _objectPositions;
    private int _startScareLevel = 5;

    private void Start()
    {
        int numberRoom = LoadScene.Instance.NumberRoom;

        if(tag != "Hall")
        {
            Initialized();
        }

        if (tag == "Hall" && numberRoom > _startScareLevel)
        {
            ScareVisible scareRandom = (ScareVisible)Random.Range(0, 2);

            if (scareRandom == ScareVisible.Show)
            {
                int indexPosition = Random.Range(0, _objectPositions.Count);
                Instantiate(_objects[0], _objectPositions[indexPosition].position, Quaternion.identity);
            }
        }
    }

    private void Initialized()
    {
        if (_objects.Count == 0) return;

        for (int i = 0; i < _objectPositions.Count; i++)
        {
            int idObject = Random.Range(0, _objects.Count);
            Instantiate(_objects[idObject], _objectPositions[i].position, Quaternion.identity);
        }
    }

    public Transform PlayerPosition => _spawnPlayerPosition;
}
