using UnityEngine;

namespace DefaultNamespace
{
    [System.Serializable]
    public class SoundEffect
    {
        public string Name;
        public AudioClip Clip;
        public float Volume;

        [HideInInspector] 
        public AudioSource Source;
    }
}