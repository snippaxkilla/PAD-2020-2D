using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawLine : MonoBehaviour {

    private LineRenderer renderer;
    private Vector2 mousePos;
    private Vector2 startMousePos;

    [SerializeField]
    private Text formula;

    // Start is called before the first frame update
    void Start() {
        renderer = GetComponent<LineRenderer>(); // get the component from unity
        renderer.positionCount = 5; // set amount of positions
        renderer.SetPosition(0, new Vector3(-8, 4, 0f));
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) { // when mouse button is pressed
            startMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButton(0)) { // when button is released
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            renderer.SetPosition(1, new Vector3(startMousePos.x, startMousePos.y, 0f));
            renderer.SetPosition(2, new Vector3(mousePos.x, mousePos.y, 0f));
            formula.text = GetFormulaFromVector(startMousePos, mousePos);
        }
    }

    public static string GetFormulaFromVector(Vector2 startMousePos, Vector2 mousePos) {
        string formule = "";
        // algebra
        // y = ax + b, where a = dy / dx
        if (startMousePos != mousePos) {
            float dy = mousePos.y - startMousePos.y;
            float dx = mousePos.x - startMousePos.x;
            float coefficient = dy / dx;
            // use mousePos for y & x, multiply coefficient by x and subtract result from y, that way you have b.
            float startPoint = 0f;
            float ax = coefficient * mousePos.x;
            startPoint = mousePos.y - ax;
            string mathOperator = (startPoint > 0 ? " +" : "");
            float roundedStart = Mathf.Ceil(startPoint);
            formule = roundedStart != 0 ? coefficient.ToString("F1") + "x" + mathOperator + Mathf.Ceil(startPoint) : coefficient.ToString("F1") + "x";
        } else {
            formule = "Geen formule";
        }
        return formule;
    }

    public static string GetFormulaFromVector(Vector3 startMousePos, Vector3 mousePos) {
        return GetFormulaFromVector(new Vector2(startMousePos.x, startMousePos.y), new Vector2(mousePos.x, mousePos.y));
    }
}
