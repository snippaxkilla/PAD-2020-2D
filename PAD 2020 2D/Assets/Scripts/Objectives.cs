using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objectives : MonoBehaviour {

    public static Transform[] objectives;

    void Awake() {
        objectives = new Transform[transform.childCount];
        for (int i = 0; i < objectives.Length; i++) {
            objectives[i] = transform.GetChild(i);
        }
    }
}
