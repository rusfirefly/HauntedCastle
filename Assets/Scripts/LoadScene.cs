using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField] private int _nextLevelNumber;

    public void Load()
    {
        StartCoroutine(AsynkLoad());
    }

    private IEnumerator AsynkLoad()
    {
        AsyncOperation asynkLoad = SceneManager.LoadSceneAsync(_nextLevelNumber);

        while (asynkLoad.isDone == false)
        {
            Debug.Log(asynkLoad.progress);
            yield return null;
        }
    }
}
