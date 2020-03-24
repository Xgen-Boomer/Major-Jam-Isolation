using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMODFootstep : MonoBehaviour {
    [FMODUnity.EventRef]
    public string inputsound;
    bool isRunning;
    public float playerSpeed;

    void Update() {
        playerSpeed = .5f / GetComponent<PlayerController>().speedMult;
        if (Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0) {
            isRunning = true;
        } else {
            isRunning = false;
        }
        if (isRunning) {
            if (Input.GetKeyDown(KeyCode.LeftShift)) {
                CancelInvoke("CallFootsteps");
                InvokeRepeating("CallFootsteps", 0, playerSpeed);
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftShift)) {
            CancelInvoke("CallFootsteps");
            InvokeRepeating("CallFootsteps", 0, playerSpeed);
        }
        if (!GetComponent<PlayerController>().isJumpUp || !GetComponent<PlayerController>().isJumpDown) {
            isRunning = false;
        }
    }
    void CallFootsteps() {
        if (isRunning) {
            FMODUnity.RuntimeManager.PlayOneShot(inputsound);
        }
    }
    void Start() {
        playerSpeed = .5f;
        isRunning = false;
        InvokeRepeating("CallFootsteps", 0, playerSpeed);
    }

    void onDisable() {
        isRunning = false;
    }
}

