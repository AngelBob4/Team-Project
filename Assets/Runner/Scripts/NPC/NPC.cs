using Runner.Enums;
using UnityEngine;

namespace Runner.NonPlayerCharacters
{
    public class NPC : MonoBehaviour
    {
        [SerializeField] protected NPCTypes _type;
        [SerializeField] protected int _value;

        public NPCTypes Type => _type;
        public int Value => _value;
    }
}