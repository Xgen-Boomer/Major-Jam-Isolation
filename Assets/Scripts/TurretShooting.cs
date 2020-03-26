using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShooting : MonoBehaviour {

    GameObject robot;
    Camera cam;
    public bool onScreen;
    public float onScreenMarginX = .1f;
    public GameObject bulletPrefab;
    public GameObject bullets;
    public GameObject shootPoint;

    void Start() {
        bullets = GameObject.Find("Bullets");
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        robot = GameObject.Find("Robot");
        InvokeRepeating("ShootPlayer", 2, 1);
    }

    void Update() {
        Vector3 screenPoint = cam.WorldToViewportPoint(transform.position);
        onScreen = screenPoint.z > 0 && screenPoint.x > 0 - onScreenMarginX && screenPoint.x < 1 + onScreenMarginX && screenPoint.y > 0 && screenPoint.y < 1;

        if (onScreen) {
            transform.LookAt(new Vector2(robot.transform.position.x, robot.transform.position.y + 2), Vector2.right);
            if (transform.rotation.x < -90 || transform.rotation.x > 0) {
                transform.localScale = new Vector3(transform.localScale.x, -1, 1);
            } else {
                transform.localScale = new Vector3(transform.localScale.x, 1, 1);
            }
        }
    }

    void ShootPlayer() {
        if(onScreen) {
            Debug.Log(-transform.localRotation.y);
            GameObject b = Instantiate(bulletPrefab, shootPoint.transform, true);
            Destroy(b, 10);
        }
    }
}
