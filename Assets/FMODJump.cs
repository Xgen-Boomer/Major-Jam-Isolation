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
        if((!GetComponent<PlayerController>().isJumpUp && GetComponent<Rigidbody2D>().velocity.y-.01f>0)) {
            StartCoroutine(callJumpSounds());
        }
    }
    void Start() {
        isJumping = false;
        InvokeRepeating("CallJump", 0, jumpForce);
    }

    void onDisable() {
        isJumping = false;
    }

    IEnumerator callJumpSounds() {
        FMODUnity.RuntimeManager.PlayOneShot(inputsound);
        yield return new WaitForSeconds(.835f);
        FMODUnity.RuntimeManager.PlayOneShot(inputsound);
    }
}
