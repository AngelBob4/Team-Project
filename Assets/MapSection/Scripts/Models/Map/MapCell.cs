using System;
using System.Collections.Generic;
using Events.Main.Events;
using UnityEngine;

namespace MapSection.Models
{
    public class MapCell
    {
        private List<int> _nextAvailableCellsIndexes;
        private readonly EventsType _type;
        private readonly PositionOnMap _position;
        private readonly int _index;
        private bool _isAvailable = false;
        private bool _isActivated = false;

        public event Action Activated;
        public event Action Deactivated;
        public event Action PlayerArriviedToCell;

        public List<int> NextAvailableCellsIndexes => new(_nextAvailableCellsIndexes);
        public EventsType Type => _type;
        public PositionOnMap Position => _position;
        public int Index => _index;
        public bool IsAvailable => _isAvailable;
        public bool IsActivated => _isActivated;

        public MapCell(EventsType type, int x, int y, int index, List<int> nextAvailableCellsIndexes = null, bool isAvailable = false, bool isActivated = false)
        {
            _nextAvailableCellsIndexes = new List<int>();
            _position = new PositionOnMap(x, y);
            _type = type;
            _index = index;

            _isAvailable = isAvailable;
            _isActivated = isActivated;

            //if (_isAvailable)
            //{
            //    Debug.Log("Load True!!!!!!!!!!!!!!!");
            //}

            if (nextAvailableCellsIndexes != null)
            {
                foreach (int cellsIndexes in nextAvailableCellsIndexes)
                {
                    _nextAvailableCellsIndexes.Add(cellsIndexes);
                }
            }
        }

        public void AddRoadToNextCell(MapCell cell)
        {
            _nextAvailableCellsIndexes.Add(cell.Index);
            cell.SetAvailable();
        }

        public void ActivateCell()
        {
            Activated?.Invoke();
        }

        public void DeactivateCell()
        {
            Deactivated?.Invoke();
        }

        public void PlayerArriviedToThisCell()
        {
            _isActivated = true;
            PlayerArriviedToCell?.Invoke();
        }

        public void SetAvailable()
        {
            _isAvailable = true;
        }
    }

    public struct PositionOnMap
    {
        private readonly int x;
        private readonly int y;

        public int X => x;
        public int Y => y;

        public PositionOnMap(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}