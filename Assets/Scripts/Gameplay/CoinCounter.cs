using System;

namespace Assets.Scripts.Gameplay
{
    public class CoinCounter : ICoinCounter
    {
        private int _coinsCount;

        event Action<int> ICoinCounter.OnCoinCountUpdate
        {
            add => onCoinCountUpdate += value;
            remove => onCoinCountUpdate -= value;
        }
        private Action<int> onCoinCountUpdate;

        public void CollectCoin()
        {
            _coinsCount++;
            onCoinCountUpdate?.Invoke(_coinsCount);
        }
        public int GetCoinCount() => _coinsCount;
    }
}