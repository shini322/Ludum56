using UnityEngine;

public class AudioService : Singleton<AudioService>
{
    [SerializeField] private AudioSource effectsSource;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioClip musicClip;

    public void PlayOneShot(AudioClip clip)
    {
        effectsSource.PlayOneShot(clip);
    }
    
    public void PlayerMusic()
    {
        musicSource.clip = musicClip;
        musicSource.Play();
    }

    public void ChangeMusicVolume(float volume)
    {
        musicSource.volume = volume;
    }
}