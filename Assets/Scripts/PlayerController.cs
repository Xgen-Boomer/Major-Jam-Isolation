using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float playerSpeed = 1f;
    public float jumpForce = 4f;

    public float playerScale = 1f;

    public float jumpCount;
    public float jumpTime = .2f;

    public bool isJumping = false;

    public float checkRadius = .025f;
    [SerializeField]
    LayerMask ground;
    public bool onGround = true;
    [SerializeField]
    Transform feet;
    Rigidbody2D rb;

    void Start() {
        playerScale = transform.localScale.x;
        isJumping = false;
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        rb.velocity = new Vector2(playerSpeed * Input.GetAxisRaw("Horizontal"), rb.velocity.y);
    }

    void Update() {
        onGround = Physics2D.OverlapCircle(feet.position, checkRadius, ground);

        if (Input.GetAxisRaw("Horizontal") > 0) {
            transform.localScale = new Vector3(playerScale, playerScale, 1);
        } else if (Input.GetAxisRaw("Horizontal") < 0) {
            transform.localScale = new Vector3(-playerScale, playerScale, 1);
        }

        if (onGround && Input.GetAxisRaw("Horizontal") != 0) {
            StartCoroutine(GetComponent<PlayerMovementSounds>().playRunSound());
            //GetComponent<>
        } else {
            GetComponent<PlayerMovementSounds>().stopRunSound();
        }

        if (rb.velocity.y < 0) {
            rb.velocity -= rb.gravityScale * Vector2.up * playerScale / 3;
        }

        if (onGround && Input.GetAxisRaw("Vertical") > 0) {
            isJumping = true;
            jumpCount = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
            GetComponent<PlayerMovementSounds>().playJumpSound();
        } else if (onGround) {
            GetComponent<PlayerMovementSounds>().stopJumpSound();
        }

        if (Input.GetAxisRaw("Vertical") > 0 && isJumping) {
            if (jumpCount > 0) {
                rb.velocity = jumpForce * Vector2.up;
                jumpCount -= Time.deltaTime;
            } else {
                isJumping = false;
            }
        }

        if (Input.GetAxisRaw("Vertical") > 0) {
            isJumping = false;
        }
    }
}
