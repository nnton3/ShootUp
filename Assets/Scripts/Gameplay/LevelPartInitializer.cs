using UnityEngine;
using System.Collections.Generic;

namespace Assets.Scripts.Gameplay
{
    public class LevelPartInitializer : MonoBehaviour
    {
        [SerializeField] private List<Coin> _coins;

        public void Init(ICoinCounter counter)
        {
            _coins.ForEach(c => c.Inject(counter));
        }
    }
}
