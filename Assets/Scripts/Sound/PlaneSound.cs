


using UnityEngine;

public class PlaneSound : MonoBehaviour
{
    public AudioSource shootingAudioSource;
    public AudioSource explosionAudioSource;

    void OnEnable()
    {
        EventManager.Subscribe<GameEvent.PlaneShoot>(PlayShootingSound);
        EventManager.Subscribe<GameEvent.PlaneCrash>(PlayExplosionSound);
        EventManager.Subscribe<GameEvent.Explosion>(PlayExplosionSound); 
    }

    void OnDisable()
    {
        EventManager.Unsubscribe<GameEvent.PlaneShoot>(PlayShootingSound);
        EventManager.Unsubscribe<GameEvent.PlaneCrash>(PlayExplosionSound);
        EventManager.Unsubscribe<GameEvent.Explosion>(PlayExplosionSound); 
    }

    private void PlayShootingSound()
    {
        shootingAudioSource.Play(); 
    }

    private void PlayExplosionSound()
    {
        explosionAudioSource.Play(); 
    }
}
