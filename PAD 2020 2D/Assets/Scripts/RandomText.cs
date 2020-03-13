using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomText : MonoBehaviour {

    public Text formula;
    public Vector3 beginPunt;
    public Vector3 eindPunt;

    // private ints for calculation
    private int randomCoefficient;
    private int startPos;
    private string randomOperator;
    private LineRenderer renderer;

    // Start is called before the first frame update
    void Start() {
        formula = this.GetComponent<Text>();
        renderer = FindObjectOfType<LineRenderer>();
        beginPunt = new Vector3(-8, 4, 0);
        formula.text = DrawLine.GetFormulaFromVector(beginPunt, eindPunt);
    }

    // Update is called once per frame
    void Update() {
        // draw line from data
        // vul lengte in voor x
        renderer.SetPosition(0, beginPunt);
        renderer.SetPosition(1, eindPunt);
    }
}
