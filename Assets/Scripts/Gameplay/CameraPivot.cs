using UnityEngine;

namespace Assets.Scripts.Gameplay
{
    public class CameraPivot : MonoBehaviour
    {
        [SerializeField] private Transform _gun;
        private Vector3 _pos;

        private void FixedUpdate()
        {
            if (_gun.position.y > transform.position.y)
            {
                _pos = transform.position;
                _pos.y = _gun.position.y;
                transform.position = _pos;
            }
        }
    }
}