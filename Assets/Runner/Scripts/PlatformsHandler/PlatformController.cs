using Runner.Enums;
using Runner.PlayerController;
using Runner.Settings;
using UnityEngine;

namespace Runner.PlatformsHandler
{
    public class PlatformController : MonoBehaviour
    {
        [SerializeField] private Transform _pool;
        [SerializeField] private Transform _startPlatform;
        [SerializeField] private Transform _lastPlatform;

        [SerializeField] private Player _player;
        [SerializeField] private PlatformsCounter _platformsCounter;
        [SerializeField] private EntryPoint _entryPoint;

        private int _totalNumberOfPlatforms;
       
        private int _platformIndex = 0;
        private int _platformsNumber = 2;
        // можно и посчитать через бокс коллайдер
        private float _tileLength = 30;

        private bool _isFinishedLevel = false;

        private void Update()
        {
            if (!_isFinishedLevel && _entryPoint.IsRunnerStarted)
            {
                if (_player.transform.position.z + _platformsNumber * _tileLength > _tileLength * _platformsCounter.Meter)
                {
                    MovePlatform();
                    IncreasePlatformIndex();
                    _platformsCounter.OnPlatformsAmountChanged();

                    if (CheckIfItsTimeForLastPlatform())
                    {
                        EnableLastPlatform();
                    }
                }
            }
        }

        public void InitTotalNumberOfPlatforms(int totalNumberOfPlatforms)
        {
            _totalNumberOfPlatforms = totalNumberOfPlatforms;
        }



        private bool CheckIfItsTimeForLastPlatform()
        {
            return _platformsCounter.Meter >= _totalNumberOfPlatforms ? true : false;
        }

        private void EnableLastPlatform()
        {
            _lastPlatform.transform.position = new Vector3(0, 0, _tileLength * _platformsCounter.Meter);
            _lastPlatform.gameObject.SetActive(true);
            _isFinishedLevel = true;
        }

        private void MovePlatform()
        {
            var newPos = _tileLength * _platformsCounter.Meter;
            Transform movedPlatform = _pool.GetChild(_platformIndex);
            ResetPlatform(movedPlatform, newPos);
        }

        private void ResetPlatform(Transform platform, float newPosZ)
        {
            platform.gameObject.SetActive(false);
            platform.transform.position = new Vector3(0, 0, newPosZ);
            platform.gameObject.SetActive(true);
        }

        private void IncreasePlatformIndex()
        {
            _platformIndex++;

            if (_platformIndex == _pool.childCount)
            {
                _platformIndex = 0;
                _startPlatform.gameObject.SetActive(false);
            }
        }
    }
}
