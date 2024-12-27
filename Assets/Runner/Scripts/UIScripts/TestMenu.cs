using Runner.Settings;
using UnityEngine;

namespace RunnerUI
{
    public class TestMenu : MonoBehaviour
    {
        [SerializeField] private EntryPoint _entryPoint;
        [SerializeField] private GameObject _testMenuView;

        public void NewGameButtonPressed()
        {
            // ������� �����
            // ������� ����� �������(���,������,�������)
            // ������� ������ ��� ������ � ���������:
            // �����: � ����������� �� ���� � ����� ����� ����� ��������� �����, � � ������ ������ ���� ���������� ��� ��
            // �� ��������:
            // ������, ������, ���������� ������

            _entryPoint.InitAllSettingsForRunner();
            _testMenuView.SetActive(false);
        }
    }
}
