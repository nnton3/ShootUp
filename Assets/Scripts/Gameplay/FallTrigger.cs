using System;
using UnityEngine;

namespace Assets.Scripts.Gameplay
{
    public class FallTrigger : MonoBehaviour, IFallTrigger
    {
        public event Action OnGunFall;
        private readonly string _gunTag = "Gun";
        private float _height;
        private Camera _cam;
        private Vector3 _pos;

        private void Awake()
        {
            _cam = Camera.main;
            _height = 1 / (_cam.WorldToViewportPoint(new Vector3(1f, 1f, 0f)).y - 0.5f);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == _gunTag)
            {
                Debug.Log($"gun fall");
                OnGunFall?.Invoke();
            }
        }

        private void FixedUpdate()
        {
            _pos = _cam.transform.position;
            _pos.y -= _height / 2f;
            transform.position = _pos;
        }
    }
}
