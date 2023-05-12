using System;
using UnityEngine;

namespace Assets.Scripts.Gameplay
{
    public class FallLoseCondition : ILoseCondition
    {
        public event Action OnPlayerLose;

        public void Inject(IFallTrigger fallTrigger)
        {
            fallTrigger.OnGunFall += () => OnPlayerLose?.Invoke();
        }
    }
}