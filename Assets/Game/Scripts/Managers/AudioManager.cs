using Game.Scripts.Extra;
using UnityEngine;

public class AudioManager : Singelton<AudioManager>
{

    [Header("Audio Settings")] 
    public AudioSource musicSource;
    public AudioSource sfxSource;



    private void Awake()
    {
        base.Awake();
      
            DontDestroyOnLoad(gameObject);
     
    }

    public void PlayMusic(AudioClip musicClip)
    {
        musicSource.clip = musicClip;
        musicSource.Play();
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    public void PlaySoundEffect(AudioClip sfxClip)
    {
        sfxSource.PlayOneShot(sfxClip);
    }

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void SetSfxVolume(float volume)
    {
        sfxSource.volume = volume;
    }
}
