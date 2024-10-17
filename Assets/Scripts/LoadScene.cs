using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField] private int _currentLevelNumber;

    public void Load()
    {
        StartCoroutine(AsynkLoad());
    }

    private IEnumerator AsynkLoad()
    {
        AsyncOperation asynkLoad = SceneManager.LoadSceneAsync(_currentLevelNumber++);

        while (asynkLoad.isDone == false)
        {
            Debug.Log(asynkLoad.progress);
            yield return null;
        }
    }
}
