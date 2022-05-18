using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region Singleton
    public static AudioManager instance;
    private void Awake()
    {
        instance = this;
        source = GetComponent<AudioSource>();
    }
    #endregion

    [System.Serializable]
    public class Sound
    {
        public string name;
        public AudioClip clip;
    }

    private AudioSource source;
    public List<Sound> sounds;
    public static void PlayMusic(string name)
    {
        foreach (Sound sound in instance.sounds) 
        {
            if (sound.name.Equals(name))
            {
                instance.source.clip = sound.clip;
                instance.source.Play();
            }
        }
    }
    public static void PlaySfx(string name)
    {
        foreach (Sound sound in instance.sounds) 
        {
            if (sound.name.Equals(name))
            {
                instance.source.PlayOneShot(sound.clip);
            }
        }
    }
}