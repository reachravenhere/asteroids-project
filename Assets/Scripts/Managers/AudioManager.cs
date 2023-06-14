using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;

    public AudioSource soundEffectSource;


    public List<SoundEntry> sounds = new List<SoundEntry>();


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }

    public void PlaySound(string soundName)
    {
        
        for (int i = 0;i <sounds.Count; i++)
        {

            if (sounds[i].name == soundName)
            {
                soundEffectSource.PlayOneShot(sounds[i].clip);
                break;
            }
        }
    }

    [System.Serializable]
    public class SoundEntry
    {
        public string name;
        public AudioClip clip;
    }

}
