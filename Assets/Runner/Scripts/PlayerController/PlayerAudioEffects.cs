using System.Collections.Generic;
using UnityEngine;

namespace Runner.PlayerController
{
    public class PlayerAudioEffects : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private List<AudioClip> _clips;
       
        public void PlayAudioEffect(int index)
        {
            _audioSource.PlayOneShot(_clips[index]);
        }
    }
}
