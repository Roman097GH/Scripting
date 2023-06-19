using UniRx;
using UnityEngine;
using Zenject;

namespace TopDown
{
    public class MainUI : MonoBehaviour
    {
        [SerializeField, HideInInspector] private GamePanel _gamePanel;
        [SerializeField, HideInInspector] private GameOverPanel _gameOverPanel;

        private GameplayController _gameplayController;

        [Inject]
        private void Construct(GameplayController gameplayController)
        {
            _gameplayController = gameplayController;
        }

        private void OnValidate()
        {
            _gamePanel = GetComponentInChildren<GamePanel>();
            _gameOverPanel = GetComponentInChildren<GameOverPanel>(true);
        }

        private void OnEnable()
        {
            // наблюдение за изменениямиями пока не удалится
            _gameplayController.GameState.TakeUntilDestroy(this).Subscribe(TogglePanels);
        }

        private void TogglePanels(EGameState eGameState)
        {
            _gamePanel.gameObject.SetActive(eGameState == EGameState.GameActive);
            _gameOverPanel.gameObject.SetActive(eGameState == EGameState.GameOver);
        }
    }
}