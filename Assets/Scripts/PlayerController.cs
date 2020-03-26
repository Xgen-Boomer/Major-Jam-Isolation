using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float playerSpeed = 1f;
    public float jumpForce = 4f;

    public float speedMult = 1;

    public float playerScale = 1f;

    public float jumpCount;
    public float jumpTime = .2f;

    public bool isIdle = true;
    public bool isRunning = true;
    public bool isJumpUp = true;
    public bool isJumpDown = true;

    public bool isJumping = false;

    public float checkRadius = .025f;
    [SerializeField]
    LayerMask ground;
    public bool onGround = true;
    [SerializeField]
    Transform feet;
    Rigidbody2D rb;

    void Start() {
        isIdle = false;
        playerScale = transform.localScale.x;
        isJumping = false;
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        rb.velocity = new Vector2(playerSpeed * speedMult * Input.GetAxisRaw("Horizontal"), rb.velocity.y);
    }

    void Update() {
        if(GetComponent<PlayerHealth>().health<=0) {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            isIdle = true;
            isRunning = true;
            isJumpUp = true;
            isJumpDown = true;
            GetComponent<FMODJump>().isJumping = false;
            GetComponent<FMODFootstep>().isRunning = false;
        } else {
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        onGround = Physics2D.OverlapCircle(feet.position, checkRadius, ground);

        if (Input.GetAxisRaw("Horizontal") > 0) {
            transform.localScale = new Vector3(playerScale, playerScale, 1);
        } else if (Input.GetAxisRaw("Horizontal") < 0) {
            transform.localScale = new Vector3(-playerScale, playerScale, 1);
        }

        if(Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0) {
            if(isIdle && onGround) {
                GetComponent<RobotAnimation>().goIdle();
            }
        }

        if (onGround && Input.GetAxisRaw("Horizontal") != 0) {
            if(isRunning) {
                GetComponent<RobotAnimation>().goRun();
            }
            if (Input.GetKey(KeyCode.LeftShift)) {
                speedMult = 2;
            } else {
                speedMult = 1;
            }
        } else {
            speedMult = 1;
        }

        if (rb.velocity.y < 0) {
            rb.velocity -= rb.gravityScale * Vector2.up * playerScale / 3;
        }

        if (onGround && Input.GetAxisRaw("Vertical") > 0) {
            isJumping = true;
            jumpCount = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
            if(isJumpUp) {
                GetComponent<RobotAnimation>().goJumpUp();
            }
        }

        if (Input.GetAxisRaw("Vertical") > 0 && isJumping) {
            if (jumpCount > 0) {
                rb.velocity = jumpForce * Vector2.up;
                jumpCount -= Time.deltaTime;
            } else {
                isJumping = false;
            }
        }

        if(rb.velocity.y<0) {
            if(isJumpDown && !isJumpUp) {
                GetComponent<RobotAnimation>().goJumpDown();
            }
        }

        if (Input.GetAxisRaw("Vertical") > 0) {
            isJumping = false;
        }
    }
}
