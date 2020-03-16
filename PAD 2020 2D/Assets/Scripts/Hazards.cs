using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazards : MonoBehaviour {

    public static Transform[] hazards;

    void Awake() {
        hazards = new Transform[transform.childCount];
        for (int i = 0; i < hazards.Length; i++) {
            hazards[i] = transform.GetChild(i);
        }
    }    
}
