using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interscene : MonoBehaviour {

    public static bool retryLevel = false;

    void Awake() {
        DontDestroyOnLoad(this);
    }
}
