using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;

public class JoystickMove : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Joystick joystick;
    private BoxCollider2D boxCollider;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();

        this.FixedUpdateAsObservable()
            .Subscribe(_ =>
            {
                Vector2 movement = new Vector2(joystick.Horizontal, joystick.Vertical);
                transform.Translate(movement * speed * Time.deltaTime);
            });
    }
}
