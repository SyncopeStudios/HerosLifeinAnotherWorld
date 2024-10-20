using Game.Scripts.Extra;
using UnityEngine;

public class AudioManager : Singelton<AudioManager>
{
    [Header("Audio Settings")] 
    public AudioSource musicSource;
    public AudioSource sfxSource;

    private void Awake()
    {
        base.Awake(); // Ensure the Singleton is properly initialized
        DontDestroyOnLoad(gameObject);
    }

    public void PlayMusic(AudioClip musicClip)
    {
        if (musicSource != null)
        {
            musicSource.clip = musicClip;
            musicSource.Play();
        }
        else
        {
            Debug.LogWarning("Music source is null, cannot play music.");
        }
    }

    public void StopMusic()
    {
        if (musicSource != null)
        {
            musicSource.Stop();
        }
        else
        {
            Debug.LogWarning("Music source is null, cannot stop music.");
        }
    }

    public void StopSFXSound()
    {
        if (sfxSource != null)
        {
            sfxSource.Stop();
        }
        else
        {
            Debug.LogWarning("SFX source is null, cannot stop sound effect.");
        }
    }

    public void PlaySoundEffect(AudioClip sfxClip)
    {
        if (sfxSource != null)
        {
            if (sfxSource.clip != sfxClip) // Avoid overwriting the same clip
            {
                sfxSource.clip = sfxClip;
                sfxSource.Play();
            }
        }
        else
        {
            Debug.LogWarning("SFX source is null, cannot play sound effect.");
        }
    }

    public void SetMusicVolume(float volume)
    {
        if (musicSource != null)
        {
            musicSource.volume = volume;
        }
        else
        {
            Debug.LogWarning("Music source is null, cannot set volume.");
        }
    }

    public void SetSfxVolume(float volume)
    {
        if (sfxSource != null)
        {
            sfxSource.volume = volume;
        }
        else
        {
            Debug.LogWarning("SFX source is null, cannot set volume.");
        }
    }
}
