using System;

namespace Assets.Scripts.Gameplay
{
    public interface ICoinCounter
    {
        event Action<int> OnCoinCountUpdate;
        void CollectCoin();
        int GetCoinCount();
    }
}