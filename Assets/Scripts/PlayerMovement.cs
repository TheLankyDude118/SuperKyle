using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D solidObj;
    private BoxCollider2D collision;
    private Animator anim;
    private SpriteRenderer sprite;

    private float moveX = 0;
    [SerializeField] private float moveSpeed = 7;
    [SerializeField] private float jumpSpeed = 5;

    [SerializeField] private LayerMask jumpableGround;

    private enum MoveType {idle, running, jumping, falling}

    public CameraControl cam;

    // Start is called before the first frame update
    private void Start()
    {
        solidObj = GetComponent<Rigidbody2D>();
        collision = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");

        solidObj.velocity = new Vector2(moveX * moveSpeed, solidObj.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            solidObj.velocity = new Vector2(solidObj.velocity.x, jumpSpeed);
        }

        UpdateAnimation();

    }

    private void UpdateAnimation()
    {
        MoveType type;

        if (moveX > 0)
        {
            type = MoveType.running;
                sprite.flipX = false;
        }
        else if (moveX < 0)
        {
            type = MoveType.running;
            sprite.flipX = true;
        }
        else
        {
            type = MoveType.idle;
        }

        if (solidObj.velocity.y > 0.1)
        {
            type = MoveType.jumping;
        }
        else if (solidObj.velocity.y < -0.1)
        {
            type = MoveType.falling;
        }

        anim.SetInteger("type", (int)type);
    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(collision.bounds.center, collision.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);            // (position, size, rotation, offset direction, offset amount, collision layer to detect)
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CamLock"))
        {
            cam.movingCam = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CamLock"))
        {
            cam.movingCam = true;
        }
    }
}
