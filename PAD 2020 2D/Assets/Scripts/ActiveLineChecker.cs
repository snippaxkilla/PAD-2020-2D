using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using UnityEngine;
using UnityEngine.UI;

public class ActiveLineChecker : MonoBehaviour {

    public static Transform[] lines;
    public static GameObject activeLine;

    private GameObject inputText; // get input field text
    private string newFormula; // formula form input field
    private int lineLength; // length of line for calculation

    void Awake() {
        lines = new Transform[transform.childCount];
        for (int i = 0; i < lines.Length; i++) {
            lines[i] = transform.GetChild(i);
        }
        activeLine = lines[0].gameObject;
        inputText = GameObject.Find("Text");
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
        newFormula = inputText.GetComponent<Text>().text;
        switch (activeLine.name) {
            case "LineDrawer":
                lineLength = 5;
                break;
            case "Waypoints1T2":
                lineLength = 6;
                break;
            case "Waypoints2T3":
                lineLength = 10;
                break;
            case "GoalLine":
                lineLength = 4;
                break;
            default:
                lineLength = 5;
                Debug.Log("Incorrect active line name!");
                break;
        }
        // TODO parse formula
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

    public string[] parseFormula(string formula) {

        // TODO CHECK FOR NORMAL LETTERS

        string[] content = new string[15]; // get the contents in the form or -1x, -, 3 when formula is -1x - 3
        if (formula.Contains("*")) { // form: -1*x-3 or -1 * x - 3 or -1*x - 3
            if (formula.Contains(" * ")) {
                formula.Replace(" * ", "");
            } else if (formula.Contains("* ")) {
                formula.Replace(" *", "");
            } else if (formula.Contains("* ")) {
                formula.Replace("* ", "");
            } else {
                formula.Replace("*", "");
            }
        }
        if (formula.Contains(" ")) { // with this form in mind: -1x - 3
            content = formula.Split(' ');
            if (content.Length != 3) {
                if (content.Length == 2) {
                    if (content[0].Contains("x") && !content[0].EndsWith("x")) {
                        string secondValue = content[1];
                        int xIndex = content[0].IndexOf('x');
                        string newValue = content[0].Substring(xIndex);
                        content[1] = newValue;
                        content[2] = secondValue;
                    } else if (content[1].StartsWith("-") || content[1].StartsWith("+")) {
                        char[] secondValue = content[1].ToCharArray(0, content[1].Length);


                    }
                }
            }
        } else { // form: -1x-3

        }
        return content;
    }
}
