using System;
using UnityEngine;

namespace Assets.Scripts.Gameplay
{
    public class GunMover : MonoBehaviour
    {
        [SerializeField] private float _power = 5f;
        [SerializeField] private Vector2 _centerOfMass = new Vector2(-0.5f, 0.5f);
        private Rigidbody2D _rb;
        private Vector3 _pos;
        private bool _isActive;
        private bool _playerLose;

        public void Inject(ILoseCondition loseCondition)
        {
            loseCondition.OnPlayerLose += () => _playerLose = true;
        }

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _rb.centerOfMass = _centerOfMass;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && !_playerLose)
                Shoot();
        }

        private void Shoot()
        {
            if (!_isActive)
            {
                _rb.bodyType = RigidbodyType2D.Dynamic;
                _isActive = true;
            }

            _pos = transform.position;
            _pos = transform.TransformDirection(Vector3.up);
            var direction = _pos.normalized * _power;
            _rb.velocity = direction;
        }

        private void ResetScene()
        {
            UnityEngine
                .SceneManagement
                .SceneManager
                .LoadScene(
                    UnityEngine
                    .SceneManagement
                    .SceneManager
                    .GetActiveScene()
                    .name);
        }
    }
}