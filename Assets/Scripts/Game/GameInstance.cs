using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInstance : MonoBehaviour
{
    [field: SerializeField] public GameConstants GameConstants { get; private set; }

    private void Awake()
    {
        Application.targetFrameRate = GameConstants.GameFrameRate;

        LoadScene(GameConstants.FirstSceneIndex);
    }

    public void LoadScene(int sceneIndex)
    {
        StartCoroutine(LoadSceneAsync(sceneIndex));
    }

    private IEnumerator LoadSceneAsync(int sceneIndex)
    {
        AsyncOperation loadSceneSync = SceneManager.LoadSceneAsync(sceneIndex);

        while (loadSceneSync.isDone == false)
        {
            yield return null;
        }
    }
}
