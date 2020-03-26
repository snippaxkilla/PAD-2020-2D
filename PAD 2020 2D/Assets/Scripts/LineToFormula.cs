using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineToFormula : MonoBehaviour {
    
    private Vector3 startPoint;
    private Vector3 endPoint;
    private LineRenderer activeLine;

    public Text formula;

    void Awake() {
        activeLine = ActiveLineChecker.activeLine.GetComponent<LineRenderer>();
        formula = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update() {
        activeLine = ActiveLineChecker.activeLine.GetComponent<LineRenderer>();
        startPoint = activeLine.GetPosition(0);
        endPoint = activeLine.GetPosition(1);
        formula.text = DrawLine.GetFormulaFromVector(startPoint, endPoint);
    }
}
