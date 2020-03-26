using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public float health = 2;
    public GameObject spawnPoint;
    public Transform ground;
    public GameObject deathPanel;
    bool spawned = true;

    public string deathType = "";

    private void Start() {
        deathPanel = GameObject.Find("DeathPanel");
        spawnPoint = GameObject.Find("PlayerSpawnPoint");
        health = 2;
    }

    void Update() {
        if(health<=0) {
            if(spawned) {
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
        yield return new WaitForSeconds(1.5f);
    }

    public void resetPlayer() {
        deathType = "";
        transform.position = spawnPoint.transform.position;
        health = 2;
        spawned = true;
    }
}
