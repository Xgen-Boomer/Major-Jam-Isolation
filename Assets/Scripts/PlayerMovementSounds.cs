using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementSounds : MonoBehaviour {

    public AudioSource JumpSound;
    public AudioSource RunSound;
    public AudioSource[] feetSounds;

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

    public IEnumerator playRunSound() {
        if (!feetSounds[0].isPlaying && !feetSounds[1].isPlaying) {
            feetSounds[Random.Range(0, 2)].Play();
            yield return new WaitForSeconds(.15f);
            feetSounds[Random.Range(0, 2)].Play();
        }
    }

    public void stopRunSound() {
        if(feetSounds[0].isPlaying) {
            feetSounds[0].Stop();
        }
        if (feetSounds[1].isPlaying) {
            feetSounds[1].Stop();
        }
    }
}
