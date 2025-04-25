

using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    public AudioSource shootingAudioSource;
    public AudioSource musicAudioSource;
    public AudioSource explosionAudioSource;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMusicSound()
    {
        musicAudioSource.loop = true; 
        musicAudioSource.Play();
    }

    public void PlayShootingSound()
    {
        shootingAudioSource.Play(); 
    }

    public void PlayExplosionSound()
    {
        explosionAudioSource.Play(); 
    }
}
