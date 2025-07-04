using System;
using UnityEngine;

namespace Events.Main.CharactersBattle
{
    public class Bar : IBar
    {
        private const int DefaultValue = 0;
        private const int OneValue = 1;

        public event Action UpdatedBar;
        public event Action<int> DamagBar;

        private int _maxValue;
        private int _˝urrentValue;
        private bool _isEndlessBar = false;

        public bool IsEndlessBar => _isEndlessBar;
        public int MaxValue => _maxValue;
        public int CurrentValue => _˝urrentValue;

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
            if(value < 0)
            {
                if(Math.Abs(value) > CurrentValue)
                {
                    value = -CurrentValue;
                }

                DamagBar?.Invoke(value);
            }

            SetValues(_˝urrentValue + value, isValidationCheck);
        }

        public void AddOneValue()
        {
            ChangeValue(OneValue);
        }

        public virtual void SetValueDefault()
        {
            SetValues(DefaultValue);
        }

        public void ChangeMaxValue(int value)
        {
            if (value > 0)
            {
                _˝urrentValue += value;
            }

            SetMaxValues(_maxValue + value);
        }

        public void ResetValues()
        {
            if (_isEndlessBar == false)
            {
                _˝urrentValue = _maxValue;
            }
            else
            {
                _˝urrentValue = DefaultValue;
            }
        }

        public void SetNewValues(int value)
        {
            SetMaxValues(value);
            SetValues(value);
        }

        public void SetValues(int value, bool isValidationCheck = true)
        {
            _˝urrentValue = value;

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

            if (_˝urrentValue > _maxValue)
            {
                _˝urrentValue = _maxValue;
            }

            UpdatedBar?.Invoke();
        }

        private void CheckValues()
        {
            if (_maxValue < _˝urrentValue && _isEndlessBar == false)
            {
                _˝urrentValue = _maxValue;
            }

            if (_˝urrentValue < 0)
            {
                _˝urrentValue = 0;
            }
        }
    }
}