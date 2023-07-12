using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{   
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifeTime = 5f;
    [SerializeField] float firingRate = 0.2f;
    Coroutine firingCoroutine;

    public bool isFiring;
    void Start()
    {
        
    }
    void Update()
    {
        Fire();
    }

    void Fire() {
        if(isFiring) {
            firingCoroutine = StartCoroutine(FireContinuously());
        } else {
            StopCoroutine(firingCoroutine);
        }
    }

    IEnumerator FireContinuously() {
        while(true) {
            GameObject instance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Destroy(instance, projectileLifeTime);
            yield return new WaitForSeconds(firingRate);
        }
    }
}
