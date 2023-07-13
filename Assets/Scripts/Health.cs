using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{   
    [SerializeField] bool isPlayer;
    [SerializeField] int health = 100;
    [SerializeField] int score = 50;
    [SerializeField] ParticleSystem hitEffect;
    CameraShake cameraShake;
    [SerializeField] bool applyCameraShake;

    AudioPlayer audioPlayer;
    ScoreKeeper scoreKeeper;


    void Awake() {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if(damageDealer != null) {
            TakeDamage(damageDealer.GetDamage());
            PlayHitEffect();
            audioPlayer.PlayDamageSound();
            ShakeCamera();
            damageDealer.Hit();
        }
    }

    public int getHealth() {
        return health;
    }

    void TakeDamage(int damage) {
        health -= damage;
        if(health <= 0) {
            Die();
        }
    }

    void PlayHitEffect() {
        if(hitEffect != null) {
            ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }

    void ShakeCamera() {
        if (cameraShake != null && applyCameraShake) {
            cameraShake.Play();
        }
    }

    void Die() {
        if(!isPlayer) {
            scoreKeeper.ModifyScore(score);
        }
        Destroy(gameObject);
    }
}
