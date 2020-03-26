using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using UnityEngine;

public class ActiveLineChecker : MonoBehaviour {

    public static Transform[] lines;
    public static GameObject activeLine;

    void Awake() {
        lines = new Transform[transform.childCount];
        for (int i = 0; i < lines.Length; i++) {
            lines[i] = transform.GetChild(i);
        }
        activeLine = lines[0].gameObject;
    }

    void Update() {
        for (int i = 0; i < lines.Length; i++) {
            LineRenderer lineRender = lines[i].GetComponent<LineRenderer>();
            if (lines[i].gameObject != activeLine) {
                lineRender.startColor = Color.red;
                lineRender.endColor = Color.red;
            } else {
                lineRender.startColor = Color.blue;
                lineRender.endColor = Color.blue;
            }
        }
        if (Input.GetKeyDown(KeyCode.Return)) { // go to next line to edit when enter key is pressed
            nextLine();
        } else if (Input.GetKeyDown(KeyCode.Backspace)) { // go to previous line to edit when backspace is pressed
            previousLine();
        }
    }

    void nextLine() { // method that handles going to next line
        if (activeLine == lines[0].gameObject) {
            if (lines[1] != null) activeLine = lines[1].gameObject;
        } else if (activeLine == lines[1].gameObject) {
            if (lines[2] != null) activeLine = lines[2].gameObject;
        } else if (activeLine == lines[2].gameObject) {
            if (lines[3] != null) activeLine = lines[3].gameObject;
        }
    }

    void previousLine() { // method that handles going back to previous line
        if (activeLine == lines[1].gameObject) {
            if (lines[0] != null) activeLine = lines[0].gameObject;
        } else if (activeLine == lines[2].gameObject) {
            if (lines[1] != null) activeLine = lines[1].gameObject;
        } else if (activeLine == lines[3].gameObject) {
            if (lines[2] != null) activeLine = lines[2].gameObject;
        }
    }
}
