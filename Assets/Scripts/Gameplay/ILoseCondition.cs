using System;

namespace Assets.Scripts.Gameplay
{
    public interface ILoseCondition
    {
        event Action OnPlayerLose;
    }
}
