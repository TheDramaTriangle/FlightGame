using UnityEngine;

public class MusicSound : MonoBehaviour
{
    public AudioSource musicAudioSource;

    void OnEnable()
    {
        EventManager.Subscribe<GameEvent.GameStart>(PlayMusicSound);
    }

    void OnDisable()
    {
        EventManager.Unsubscribe<GameEvent.GameStart>(PlayMusicSound);
    }

    private void PlayMusicSound()
    {
        musicAudioSource.loop = true; 
        musicAudioSource.Play();
    }
}
