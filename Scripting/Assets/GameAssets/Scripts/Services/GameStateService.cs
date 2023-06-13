using UnityEngine;
using UniRx;
using Zenject;

namespace Scripting
{
    public class GameStateService : IInitializable
    {
        public readonly ReactiveProperty<int> BestScore = new();
        public readonly ReactiveProperty<int> ItemsCount = new();
        public readonly ReactiveProperty<int> InitialItemsCount = new();
    
        private string BEST_SCORE = "BestScore";

        public void Initialize() => BestScore.Value = PlayerPrefs.GetInt(BEST_SCORE);
        
        public void SetInitialItemsCount(int count) => InitialItemsCount.Value = count;

        public void SetCollectedItemsCount(int count)
        {
            int collected = InitialItemsCount.Value - count;
            ItemsCount.Value = collected;

            if (BestScore.Value >= collected) return;

            PlayerPrefs.SetInt(BEST_SCORE, collected);
            BestScore.Value = collected;
            
            PlayerPrefs.Save();
        }
    }
}
