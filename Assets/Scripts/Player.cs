using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Joystick joystick;
    private float padding = 0.5f;
    private BoxCollider2D boxCollider;
    Vector2 minBounds;
    Vector2 maxBounds;

    Shooter shooter;
    void Awake() {
        shooter = GetComponent<Shooter>();
    }
    void Start()
    {
        initBounds();
        boxCollider = GetComponent<BoxCollider2D>();

        this.FixedUpdateAsObservable()
            .Subscribe(_ =>
            {
                Vector2 movement = new Vector2(joystick.Horizontal, joystick.Vertical);
                transform.Translate(movement * speed * Time.deltaTime);
                Vector2 newPosition = new Vector2();
                newPosition.x = Mathf.Clamp(transform.position.x, minBounds.x + padding, maxBounds.x - padding);
                newPosition.y = Mathf.Clamp(transform.position.y, minBounds.y + padding, maxBounds.y - padding);
                transform.position = newPosition;
            });
    }

    void initBounds() {
        Camera cam = Camera.main;
        minBounds = cam.ScreenToWorldPoint(new Vector2(0, 0));
        maxBounds = cam.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    //When player presses down on the screen, the player should fire projectiles.
    //Lean Touch
    void Update()
    {
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began) {
                //if touch is on GUI, don't fire
                if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject(touch.fingerId)) {
                    return;
                }
                shooter.isFiring = true;
            }
            else if (touch.phase == TouchPhase.Ended) {
                shooter.isFiring = false;
            }
        }
    }
}
