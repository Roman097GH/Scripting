using UnityEngine;
using UnityEngine.SceneManagement;

namespace TopDown
{
    public class GameOverPanel : MonoBehaviour
    {
        private void Start()
        {
            Time.timeScale = 0;
        }

        public void RestartGame()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}