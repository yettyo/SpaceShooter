using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteScroller : MonoBehaviour
{
    [SerializeField] Vector2 movementSpeed;
    Vector2 offset;
    Material material;

    void Awake() {
        material = GetComponent<SpriteRenderer>().material;
    }

    void Update()
    {
        offset = movementSpeed * Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}
