using UnityEngine;

namespace Assets.Scripts.Gameplay
{
    public class Coin : MonoBehaviour
    {
        private readonly string _gunTag = "Gun";
        private ICoinCounter _counter;

        public void Inject(ICoinCounter counter)
        {
            _counter = counter;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == _gunTag)
            {
                _counter.CollectCoin();
                Destroy(gameObject);
            }
        }
    }
}