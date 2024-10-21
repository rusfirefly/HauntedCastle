using System.Collections.Generic;
using UnityEngine;

public class LevelView : MonoBehaviour
{
    [SerializeField] private Transform _spawnPlayerPosition;
    [SerializeField] private List<GameObject> _objects;
    [SerializeField] private List<Transform> _objectPositions;

    private void Start()
    {
        if (tag != "Hall") 
        { 
            Initialized();
        }

        int numberRoom = LoadScene.Instance.NumberRoom;
        if (tag == "Hall" && numberRoom > 10)
        {
            int scareRandom = Random.Range(0, 3);
            if (scareRandom == 2)
            {
                int indexPosition = Random.Range(0, _objectPositions.Count);
                Instantiate(_objects[0], _objectPositions[indexPosition].position, Quaternion.identity);
            }
        }
    }

    private void Initialized()
    {
        if (_objects.Count == 0) return;

        for (int i = 0; i < _objects.Count; i++)
        {
            int idObject = Random.Range(0, _objects.Count);
            int indexPosition = Random.Range(0, _objectPositions.Count);
            Instantiate(_objects[idObject], _objectPositions[indexPosition].position, Quaternion.identity);
        }
    }

    public Transform PlayerPosition => _spawnPlayerPosition;
}
