using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RandomText : MonoBehaviour {

    // variables that can be editted in unity
    public Text formula;
    public Vector3 beginPunt;
    public Vector3 tussenPunt;
    public Vector3 eindPunt;
    public Vector3 doel;

    // privates for use in this class only
    private LineRenderer renderer;

    // Start is called before the first frame update
    void Start() {
        formula = this.GetComponent<Text>();
        renderer = FindObjectOfType<LineRenderer>();
        beginPunt = renderer.GetPosition(1);
        //formula.text = DrawLine.GetFormulaFromVector(beginPunt, eindPunt);
    }

    // Update is called once per frame
    void Update() {
        renderer.SetPosition(1, beginPunt);
        renderer.SetPosition(2, tussenPunt);
        renderer.SetPosition(3, eindPunt);
        renderer.SetPosition(4, doel);
    }
}
