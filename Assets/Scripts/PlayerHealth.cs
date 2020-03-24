using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public float health = 2;
    public Transform spawnPoint;
    public Transform ground;

    private void Start() {
        health = 2;
    }

    void Update() {
        if(health<=0) {
            transform.position = spawnPoint.position;
            health = 2;
        }
        if(transform.position.y<ground.position.y-10) {
            health = 0;
        }
    }

    public void hurtPlayer() {
        health--;
    }
}
