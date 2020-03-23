using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float playerSpeed = 1f;
    public float jumpForce = 4f;

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
        isJumping = false;
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        rb.velocity = new Vector2(playerSpeed * Input.GetAxisRaw("Horizontal"), rb.velocity.y);
    }

    void Update() {
        onGround = Physics2D.OverlapCircle(feet.position, checkRadius, ground);

        if(Input.GetAxisRaw("Horizontal")>0) {
            transform.localScale = new Vector3(.1f, .1f, 1);
        } else if(Input.GetAxisRaw("Horizontal") < 0) {
            transform.localScale = new Vector3(-.1f, .1f, 1);
        }

        if(onGround && Input.GetAxisRaw("Vertical") > 0) {
            isJumping = true;
            jumpCount = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }

        if(Input.GetAxisRaw("Vertical")>0 && isJumping) {
            if(jumpCount > 0) {
                rb.velocity = jumpForce * Vector2.up;
                jumpCount -= Time.deltaTime;
            } else {
                isJumping = false;
            }
        }

        if(Input.GetAxisRaw("Vertical")>0) {
            isJumping = false;
        }
    }
}
