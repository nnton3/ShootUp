using TMPro;
using UnityEngine;

namespace Assets.Scripts.Gameplay
{
    public class CoinCountView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _view;

        public void Inject(ICoinCounter coinCounter)
        {
            coinCounter.OnCoinCountUpdate += UpdateView;
        }

        private void UpdateView(int value)
        {
            _view.text = value.ToString();
        }
    }
}