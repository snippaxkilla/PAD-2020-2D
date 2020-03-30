using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour {

    public static Transform[] pipes;

    void Awake() {
        pipes = new Transform[transform.childCount];
        for (int i = 0; i < pipes.Length; i++) {
            pipes[i] = transform.GetChild(i);
        }
    }
}
