using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementSounds : MonoBehaviour {

    public AudioSource JumpSound;
    public AudioSource RunSound;

    public void playJumpSound() {
        if(!JumpSound.isPlaying) {
            JumpSound.Play();
        }
    }

    public void stopJumpSound() {
        if (JumpSound.isPlaying) {
            JumpSound.Stop();
        }
    }

    public void playRunSound() {
        if(!RunSound.isPlaying) {
            RunSound.Play();
        }
    }

    public void stopRunSound() {
        if(RunSound.isPlaying) {
            RunSound.Stop();
        }
    }
}
