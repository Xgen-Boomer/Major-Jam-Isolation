using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMODDeath : MonoBehaviour {
    [FMODUnity.EventRef]
    public string inputsound;
    public bool isDead;
    public float playerSpeed;

    void Update() {
        
    }
    void CallFootsteps() {
        if (isDead) {
            FMODUnity.RuntimeManager.PlayOneShot(inputsound);
            isDead = false;
        }
    }
    void Start() {
        playerSpeed = .5f;
        isDead = false;
        InvokeRepeating("CallFootsteps", 0, playerSpeed);
    }

    void onDisable() {
        isDead = false;
    }
}

