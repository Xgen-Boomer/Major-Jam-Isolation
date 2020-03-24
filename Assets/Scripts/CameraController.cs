using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    GameObject robot;

    void Start() {
        robot = GameObject.Find("Robot");
    }

    void Update() {
        transform.position = new Vector3(robot.transform.position.x, 5.33f, -10f);
    }
}
