using Runner.PlayerController;
using UnityEngine;

namespace Runner.NonPlayerCharacters
{
    public class Soul : NPC
    {
        [SerializeField] private int _soulsAmount;

        public int SoulsAmount => _soulsAmount;
    }
}
