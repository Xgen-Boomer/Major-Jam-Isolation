using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMODJump : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string inputsound;
    public bool isJumping = false;
    public float jumpForce;

    void CallJump() {
        if((GetComponent<PlayerController>().isIdle && GetComponent<PlayerController>().isRunning) || !GetComponent<PlayerController>().isJumpUp ||
            !GetComponent<PlayerController>().isJumpDown) {
            FMODUnity.RuntimeManager.PlayOneShot(inputsound);
        }
    }
    void Start() {
        isJumping = false;
        InvokeRepeating("CallJump", 0, jumpForce);
    }

    void onDisable() {
        isJumping = false;
    }
}
