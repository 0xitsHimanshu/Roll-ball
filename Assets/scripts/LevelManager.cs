    using UnityEngine.SceneManagement;
    using UnityEngine.UI;
    using UnityEngine;
    using System.Collections;
    using System.Threading.Tasks;

    public class LevelManager : MonoBehaviour
    {
        public static LevelManager Instance;
        [SerializeField] GameObject _loadCanvas;
        [SerializeField] Slider _progressIcon;
        //private float Target;
        void Awake()
        {
             if (Instance == null)//Checking for the instance if instance is not null then its not gonna delete when the another scene is loaded
            {
                 Instance = this;
                 DontDestroyOnLoad(gameObject);
            } else
                {
                    Destroy(gameObject);
                }
        }

        public void LoadScene(string sceneName)
        {
            StartCoroutine(LoadSceneAsynchronously(sceneName));

        }

        IEnumerator LoadSceneAsynchronously(string sceneName)
        {
            AsyncOperation scene = SceneManager.LoadSceneAsync(sceneName);
            _loadCanvas.SetActive(true);
            while (!scene.isDone)
            {
                _progressIcon.value = scene.progress;
                yield return null;
            }
            _loadCanvas.SetActive(false);
        }

}
