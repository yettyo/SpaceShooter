using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingSound;
    [SerializeField] [Range(0f, 1f)] float shootingVolume = 1f;

    [Header("Damage")]
    [SerializeField] AudioClip damageSound;
    [SerializeField] [Range(0f, 1f)] float damageVolume = 1f;

    public void PlayShootingSound() {
        PlaySound(shootingSound, shootingVolume);
    }

    public void PlayDamageSound() {
        PlaySound(damageSound, damageVolume);
    }

    void PlaySound(AudioClip sound, float volume) {
        if(sound != null) {
            Vector3 cameraPosition = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(sound, cameraPosition, volume);
        }
    }
}
