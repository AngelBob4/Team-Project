using System;

namespace Events.Main.CharactersBattle
{
    public class Bar : IBar
    {
        private const int DefaultValue = 0;
        private const int OneValue = 1;

        public event Action UpdatedBar;

        private int _maxValue;
        private int _ñurrentValue;
        private bool _isEndlessBar = false;

        public bool IsEndlessBar => _isEndlessBar;
        public int MaxValue => _maxValue;
        public int CurrentValue => _ñurrentValue;

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
            SetValues(_ñurrentValue + value, isValidationCheck);
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
                _ñurrentValue = _maxValue;
            }
            else
            {
                _ñurrentValue = DefaultValue;
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
            _ñurrentValue = value;

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
                _ñurrentValue += value;
            }
            else
            {
                if (_ñurrentValue > _maxValue)
                {
                    _ñurrentValue = _maxValue;
                }
            }

            UpdatedBar?.Invoke();
        }

        private void CheckValues()
        {
            if (_maxValue < _ñurrentValue && _isEndlessBar == false)
            {
                _ñurrentValue = _maxValue;
            }

            if (_ñurrentValue < 0)
            {
                _ñurrentValue = 0;
            }
        }
    }
}
