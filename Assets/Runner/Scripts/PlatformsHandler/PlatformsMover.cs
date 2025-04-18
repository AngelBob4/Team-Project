using Runner.PlayerController;
using UnityEngine;

namespace Runner.PlatformsHandler
{
    public class PlatformsMover : MonoBehaviour
    {
        private const float _tileLength = 30;
        // можно и посчитать через бокс коллайдер

        [SerializeField] private Transform _pool;
        [SerializeField] private Transform _startPlatform;
        [SerializeField] private Transform _lastPlatform;

        private int _totalNumberOfPlatforms;
        private int _platformIndex = 0;
        private int _platformsNumber = 2;

        private bool _isFinishedLevel = false;

        public void MovePlatfroms(Player player, PlatformsCounter counter)
        {
            if (!_isFinishedLevel)
            {
                if (player.transform.position.z + _platformsNumber * _tileLength > _tileLength * counter.Meter)
                {
                    MovePlatform(counter);
                    IncreasePlatformIndex();
                    counter.OnPlatformsAmountChanged();

                    if (CheckIfItsTimeForLastPlatform(counter))
                    {
                        EnableLastPlatform(counter);
                    }
                }
            }
        }

        public void InitTotalNumberOfPlatforms(int totalNumberOfPlatforms)
        {
            _totalNumberOfPlatforms = totalNumberOfPlatforms;
        }

        private bool CheckIfItsTimeForLastPlatform(PlatformsCounter counter)
        {
            return counter.Meter >= _totalNumberOfPlatforms ? true : false;
        }

        private void EnableLastPlatform(PlatformsCounter counter)
        {
            _lastPlatform.transform.position = new Vector3(0, 0, _tileLength * counter.Meter);
            _lastPlatform.gameObject.SetActive(true);
            _isFinishedLevel = true;
        }

        private void MovePlatform(PlatformsCounter counter)
        {
            var newPos = _tileLength * counter.Meter;
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
