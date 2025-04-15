using Runner.PlayerController;
using Runner.ScriptableObjects;
using Runner.Settings;
using UnityEngine;

namespace Runner.PlatformsHandler
{
    public class PlatformsController : MonoBehaviour
    {
        [SerializeField] private PlatformsCounter _platformsCounter;
        [SerializeField] private PlatformsSpawner _platformsSpawner;
        [SerializeField] private PlatformsMover _platformsMover;
       
        [SerializeField] private Player _player;
        [SerializeField] private LevelController _levelController;

        private void Update()
        {
            if (_levelController.IsRunnerStarted)
            {
                _platformsMover.MovePlatfroms(_player, _platformsCounter);
            }
        }

        public void InitPlatforms(AllRunnerSettings currentRunnerSettings, int platformsAmount)
        {
            _platformsSpawner.InitPlatformsViews(currentRunnerSettings);
            _platformsSpawner.InitPlatformsPrefabsAmount(7, 5);
            _platformsSpawner.SpawnAllTypesOfPlatforms();
            _platformsMover.InitTotalNumberOfPlatforms(platformsAmount);
        }

        public void CombinePlatformMeshes()
        {

        }

        public void StartGameProcess()
        {
            _platformsSpawner.ActivatePlatformVariants();
        }

        // ������������� ��������
        // ����� ��������
        // ������� �����
        // ������ ��������

        // ������������ : �������� ��������, ������ ��������, ���� �� ��������� ��������� ���������
    }
}