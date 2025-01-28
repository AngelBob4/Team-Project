using Runner.Settings;
using UnityEngine;

namespace Runner.UI
{
    public class TestMenu : MonoBehaviour
    {
        [SerializeField] private EntryPoint _entryPoint;
        [SerializeField] private GameObject _testMenuView;

        public void NewGameButtonPressed()
        {
            //1 - ������ �����, ���������� ��������� ����� : ������, ������, ������ � � � (���� �� ���: 0 - ��������, 1 - ���)
            //2 - ���������� ������
            //3 - ���������� �������� �� ������ 
            //4 - ���������� ����� � ������
            // ? ������ � �������

            _entryPoint.InitAllSettingsForRunner(1, 7, 15, 4);
            _entryPoint.StartRunner();
            _testMenuView.SetActive(false);
        }
    }
}
