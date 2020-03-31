using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineToFormula : MonoBehaviour {
    
    private Vector3 startPoint;
    private Vector3 endPoint;
    private LineRenderer activeLine;

    public Text formula;
    private GameObject inputField;

    void Awake() {
        activeLine = ActiveLineChecker.activeLine.GetComponent<LineRenderer>();
        formula = GetComponent<Text>();
        inputField = GameObject.Find("InputField");
    }

    // Update is called once per frame
    void Update() {
        activeLine = ActiveLineChecker.activeLine.GetComponent<LineRenderer>();
        startPoint = activeLine.GetPosition(0);
        endPoint = activeLine.GetPosition(1);
        formula.text = DrawLine.GetFormulaFromVector(startPoint, endPoint);
        //inputField.GetComponent<InputField>().text = DrawLine.GetFormulaFromVector(startPoint, endPoint);
        GameObject.Find("Placeholder").GetComponent<Text>().text = formula.text;
    }
}
