using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;



/**
 * How to use
 * 1. Load and parse data.
 *    factory.LoadDragonBonesData("DragonBonesDataPath");
 *    factory.LoadTextureAtlasData("TextureAtlasDataPath");
 *    
 * 2. Build armature.
 *    armatureComponent = factory.BuildArmatureComponent("armatureName");
 * 
 * 3. Play animation.
 *    armatureComponent.animation.Play("animationName");
 */


public class RobotAnimation : MonoBehaviour
{

    private UnityArmatureComponent armatureComponent;
    // Start is called before the first frame update
    void Start()
    {
        armatureComponent = transform.GetComponentInChildren<UnityArmatureComponent>();
        armatureComponent.animation.FadeIn ("idle", 0.25f, -1);
    }

    void Update() {
        armatureComponent.animation.timeScale = GetComponent<PlayerController>().speedMult;
    }

    public void goIdle() {
        armatureComponent.animation.FadeIn("idle", .25f, -1);
        GetComponent<FMODJump>().isJumping = false;
        GetComponent<PlayerController>().isIdle = false;
        GetComponent<PlayerController>().isRunning = true;
        GetComponent<PlayerController>().isJumpUp = true;
        GetComponent<PlayerController>().isJumpDown = true;
    }

    public void goRun() {
        armatureComponent.animation.FadeIn("RunPlace", .25f, -1);
        GetComponent<FMODJump>().isJumping = false;
        GetComponent<PlayerController>().isIdle = true;
        GetComponent<PlayerController>().isRunning = false;
        GetComponent<PlayerController>().isJumpUp = true;
        GetComponent<PlayerController>().isJumpDown = true;
    }

    public void goJumpUp() {
        armatureComponent.animation.FadeIn("JumpUp", .25f, 1);
        GetComponent<FMODJump>().isJumping = true;
        GetComponent<PlayerController>().isIdle = true;
        GetComponent<PlayerController>().isRunning = true;
        GetComponent<PlayerController>().isJumpDown = true;
        GetComponent<PlayerController>().isJumpUp = false;
    }

    public void goJumpDown() {
        armatureComponent.animation.FadeIn("JumpDown", .25f, 1);
        GetComponent<FMODJump>().isJumping = true;
        GetComponent<PlayerController>().isIdle = true;
        GetComponent<PlayerController>().isRunning = true;
        GetComponent<PlayerController>().isJumpUp = true;
        GetComponent<PlayerController>().isJumpDown = false;
    }
}
