using UnityEngine;

public class AudioService : Singleton<AudioService>
{
    [SerializeField] private AudioSource effectsSource;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioClip musicClip;
    [SerializeField] private AudioClip placeCellClip;

    public void PlayPlaceCellClip()
    {
        effectsSource.PlayOneShot(placeCellClip);
    }

    public void PlayOneShot( AudioClip clip )
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