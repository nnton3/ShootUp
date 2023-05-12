using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Gameplay
{
    public class LevelGeneration : MonoBehaviour
    {
        [SerializeField] private GameObject[] _lvlPartPrefs;
        [SerializeField] private Transform _cameraPivot;
        [SerializeField] private Transform _lvlPartsParent;
        private List<GameObject> _partsList = new List<GameObject>();
        private Vector3 _lvlPivot;
        private float _lvlPartStep;
        private ICoinCounter _counter;

        public void Inject(ICoinCounter counter)
        {
            _counter = counter;
        }

        private void Awake()
        {
            _lvlPartStep = 1 / (Camera.main.WorldToViewportPoint(new Vector3(1f, 1f, 0f)).x - 0.5f);

            for (int i = 0; i < 3; i++)
                SpawnPart();
        }

        private void SpawnPart()
        {
            var pref = Instantiate(
                _lvlPartPrefs[Random.Range(0, _lvlPartPrefs.Length)],
                _lvlPivot, Quaternion.identity, _lvlPartsParent);
            pref.GetComponent<LevelPartInitializer>().Init(_counter);
            _partsList.Add(pref);
            _lvlPivot.y += _lvlPartStep;
        }

        private void FixedUpdate()
        {
            if (_lvlPivot.y - _cameraPivot.position.y < _lvlPartStep)
                SpawnPart();
        }
    }
}