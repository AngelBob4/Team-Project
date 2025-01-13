using System;

namespace Events.Main.CharactersBattle
{
    public class Bar : IBar
    {
        private const int DefaultValue = 0;
        private const int OneValue = 1;

        public event Action UpdatedBar;

        private int _maxValue;
        private int _�urrentValue;
        private bool _isEndlessBar = false;

        public bool IsEndlessBar => _isEndlessBar;
        public int MaxValue => _maxValue;
        public int CurrentValue => _�urrentValue;

        public Bar()
        {
            _isEndlessBar = true;
            _maxValue = DefaultValue;

            SetNewValues(DefaultValue);
        }

        public Bar(int maxValue)
        {
            if (maxValue < DefaultValue)
                throw new ArgumentOutOfRangeException();

            _isEndlessBar = false;

            SetNewValues(maxValue);
        }

        public void ChangeValue(int value, bool isValidationCheck = true)
        {
            SetValues(_�urrentValue + value, isValidationCheck);
        }

        public void AddOneValue()
        {
            ChangeValue(OneValue);
        }

        public void ChangeMaxValue(int value)
        {
            SetMaxValues(_maxValue + value);
        }

        public void ResetValues()
        {
            if (_isEndlessBar == false)
            {
                _�urrentValue = _maxValue;
            }
            else
            {
                _�urrentValue = DefaultValue;
            }
        }

        public void SetNewValues(int value)
        {
            SetMaxValues(value);
            SetValues(value);

            UpdatedBar?.Invoke();
        }

        private void SetValues(int value, bool isValidationCheck = true)
        {
            _�urrentValue = value;

            if (isValidationCheck)
            {
                CheckValues();
            }

            UpdatedBar?.Invoke();
        }

        private void SetMaxValues(int value)
        {
            if (_isEndlessBar)
                return;

            _maxValue = value;

            if (_maxValue < 0)
            {
                _maxValue = 0;
            }

            if (value > 0)
            {
                _�urrentValue += value;
            }
            else
            {
                if (_�urrentValue > _maxValue)
                {
                    _�urrentValue = _maxValue;
                }
            }

            UpdatedBar?.Invoke();
        }

        private void CheckValues()
        {
            if (_maxValue < _�urrentValue && _isEndlessBar == false)
            {
                _�urrentValue = _maxValue;
            }

            if (_�urrentValue < 0)
            {
                _�urrentValue = 0;
            }
        }
    }
}
