using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public float health = 2;
    public Vector3 spawnPoint = new Vector4(-3.48f, -3.35f, .3f);
    public Transform ground;
    public GameObject deathPanel;
    bool spawned = true;

    public string deathType = "";

    private void Start() {
        spawnPoint = new Vector3(transform.position.x, transform.position.y, transform.localScale.x);
        Debug.Log(spawnPoint);
        deathPanel = GameObject.Find("DeathPanel");
        health = 2;
    }

    void Update() {
        if(health<=0) {
            if(spawned) {
                StartCoroutine(playDeathSound());
                deathPanel.SetActive(true);
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
        health = 2;
        transform.position = new Vector2(spawnPoint.x, spawnPoint.y);
        transform.localScale = new Vector2(spawnPoint.z, spawnPoint.z);
        deathType = "";
        spawned = true;
    }
}
