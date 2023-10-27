using Game.Screens;
using Levels;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class GameInstance : MonoBehaviour
    {
        [field: SerializeField] public GameConstants GameConstants { get; private set; }

        [SerializeField] private LoadingScreen _loadingScreen;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);

            Application.targetFrameRate = GameConstants.GameFrameRate;

            LoadScene(GameConstants.FirstSceneIndex);
        }

        public void LoadScene(int sceneIndex)
        {
            StartCoroutine(LoadSceneAsync(sceneIndex));
        }

        private IEnumerator LoadSceneAsync(int sceneIndex)
        {
            _loadingScreen.Show();

            AsyncOperation loadSceneSync = SceneManager.LoadSceneAsync(sceneIndex);

            while (loadSceneSync.isDone == false)
            {
                yield return null;

                _loadingScreen.UpdateProgressText(loadSceneSync.progress);
            }

            BaseLevelInstance levelInstance = FindObjectOfType<BaseLevelInstance>();
            levelInstance?.Init(this);

            _loadingScreen.Hide();
        }
    }
}