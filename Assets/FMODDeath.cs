using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMODDeath : MonoBehaviour {
    [FMODUnity.EventRef]
    public string inputsound;
    bool isDead;
    public float playerSpeed;

    void Update() {
        if(GetComponent<PlayerHealth>().health==0) {
            isDead = true;
        } else {
            isDead = false;
        }
    }
    void CallFootsteps() {
        if (isDead) {
            FMODUnity.RuntimeManager.PlayOneShot(inputsound);
        }
    }
    void Start() {
        playerSpeed = .5f;
        isDead = false;
        InvokeRepeating("CallFootsteps", 0, .5f);
    }

    void onDisable() {
        isDead = false;
    }
}

