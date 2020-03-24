using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMODFootstep : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string inputsound;
    bool isRunning;
    public float playerSpeed;

    void Update ()
	{
        if (Input.GetAxis ("Vertical") >= 0.01f || Input.GetAxis ("Horizontal") >= 0.01f || Input.GetAxis ("Vertical") <= -0.01f || Input.GetAxis ("Horizontal") <= -0.01f)
		{
            isRunning = true;

        }
        else if (Input.GetAxis ("Vertical") == 0 || Input.GetAxis ("Horizontal") == 0)
		{
            isRunning = false;
        }
  }
    void CallFootsteps ()
	{
        if (isRunning == true)
		{
            FMODUnity.RuntimeManager.PlayOneShot(inputsound);
        }
	}
    void Start ()
	{
        InvokeRepeating("CallFootsteps", 0, playerSpeed);
	}

    void onDisable ()
	{
        isRunning = false;
    }
}

