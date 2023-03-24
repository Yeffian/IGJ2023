using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public SoundEffect[] sounds;
    
    private void Awake()
    {
        DontDestroyOnLoad(this);
        
        foreach (var sound in sounds)
        {
            sound.Source = gameObject.AddComponent<AudioSource>();
            sound.Source.clip = sound.Clip;
            sound.Source.volume = sound.Source.volume;
        }
    }

    public void PlaySound(string name)
    {
        SoundEffect sound = sounds.FirstOrDefault(s => s.Name == name);
        sound.Source.Play();
    }
}
