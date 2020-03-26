using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public float health = 2;
    public Vector3 spawnPoint = new Vector4(-3.48f, -3.35f, .3f);
    public Transform ground;
    public GameObject deathPanel;
    bool spawned = true;
    public Animator deathPanelAnimator;

    public string deathType = "";

    private void Start() {
        spawnPoint = new Vector3(transform.position.x, transform.position.y, transform.localScale.x);
        health = 2;
    }

    void Update() {
        if(health<=0) {
            if(spawned) {
                deathPanel.SetActive(true);
                deathPanelAnimator.SetBool("Dead", true);
                StartCoroutine(playDeathSound());
                spawned = false;
            }
        }
        if(transform.position.y<ground.position.y-10) {
            health = 0;
            deathType = "Fell into the abyss.";
        }
    }

    public void hurtPlayer() {
        health--;
    }

    IEnumerator playDeathSound() {
        GetComponent<FMODDeath>().isDead = true;
        yield return new WaitForSeconds(.85f);
    }

    public void resetPlayer() {
        deathPanelAnimator.SetBool("Dead", false);
        health = 2;
        transform.position = new Vector2(spawnPoint.x, spawnPoint.y);
        transform.localScale = new Vector2(spawnPoint.z, spawnPoint.z);
        deathType = "";
        spawned = true;
    }
}
