using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMODJump : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string inputsound;
    bool isJumping;
    public float jumpForce;

    void Update()
    {
        if (Input.GetAxis("Vertical") > 0f || Input.GetAxis("Vertical") < -0f)
        {
            isJumping = true;

        }
        else if (Input.GetAxis("Vertical") == 0)
        {
            isJumping = false;
        }
    }
    void CallJump()
    {
        if (isJumping == true)
        {
            FMODUnity.RuntimeManager.PlayOneShot(inputsound);
        }
    }
    void Start()
    {
        InvokeRepeating("CallJump", 0, jumpForce);
    }

    void onDisable()
    {
        isJumping = false;
    }
}
