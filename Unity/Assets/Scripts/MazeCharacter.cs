using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class MazeCharacter : MonoBehaviour
{
    Vector2 movementDirection;

    public float currentSpeed = 1;

    public float normalSpeed = 3;

    public float effectTime = 5;

    [SerializeField]
    Sprite normalSprite;

    SpriteRenderer spriteRenderer;

    //void Move()
    //{
    //    movementDirection.x = CrossPlatformInputManager.GetAxisRaw("Horizontal");
    //    movementDirection.y = CrossPlatformInputManager.GetAxisRaw("Vertical");

    //    movementDirection.x = movementDirection.x != 0 ? 1 * Mathf.Sign(movementDirection.x) : 0;
    //    movementDirection.y = movementDirection.y != 0 ? 1 * Mathf.Sign(movementDirection.y) : 0;

    //    Debug.Log(movementDirection);

    //    Vector3 movement = new Vector3(movementDirection.x, movementDirection.y, 0);
    //    movement *= Time.deltaTime;
    //    movement *= speed;

    //    transform.Translate(movement);
    //}

    public void Move()
    {
        Vector3 movement = new Vector3(movementDirection.x, movementDirection.y, 0);

        movement *= Time.deltaTime;
        movement *= currentSpeed;

        transform.Translate(movement);
    }

    public void SetEffect(float speed, Sprite effectSprite)
    {
        currentSpeed = speed;

        spriteRenderer.sprite = effectSprite;

        Invoke("ClearEffect", effectTime);
    }

    void ClearEffect()
    {
        currentSpeed = normalSpeed;

        spriteRenderer.sprite = normalSprite;
    }

    public void ClearMovement()
    {
        movementDirection = Vector2.zero;
    }

    public void MoveHorizontal(float input)
    {
        movementDirection = new Vector2(input, 0);
    }

    public void MoveVertical(float input)
    {
        movementDirection = new Vector2(0, input);
    }

    private void Start()
    {
        movementDirection = Vector2.zero;

        currentSpeed = normalSpeed;

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
#if UNITY_EDITOR
        //debug
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        movementDirection = new Vector2(horizontal, vertical);
#endif

        Move();
    }
}
