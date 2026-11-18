using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Shooting SFX")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0,1)] float shootingVolume;

    [Header("Hit SFX")]
    [SerializeField] AudioClip HitClip;
    [SerializeField][Range(0, 1)] float HitVolume;

    public void PlayShootingSFX()
    {
        PlayAudioClip(shootingClip, shootingVolume);
    }

    public void PlayHitSFX()
    {
        PlayAudioClip(HitClip, HitVolume);
    }

    public void PlayAudioClip(AudioClip clip, float volume)
    {
        if (clip != null)
        {
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, volume);
        }
    }
}
