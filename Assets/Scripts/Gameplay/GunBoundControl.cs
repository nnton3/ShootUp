using UnityEngine;

namespace Assets.Scripts.Gameplay
{
    public class GunBoundControl : MonoBehaviour
    {
        private float _width;
        private Vector3 _pos;

        private void Awake()
        {
            _width = 1 / (Camera.main.WorldToViewportPoint(new Vector3(1f, 1f, 0f)).x - 0.5f);
        }

        private void FixedUpdate()
        {
            if (Mathf.Abs(transform.position.x) > _width / 2f)
            {
                _pos = transform.position;
                _pos.x = _width / 2f * Mathf.Sign(-_pos.x);
                transform.position = _pos;
            }
        }
    }
}