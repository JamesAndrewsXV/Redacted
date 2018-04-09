using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text : MonoBehaviour {

    BoxCollider2D textCol;
    Rigidbody2D rb;
    Camera mainCam;

    public Vector2 minForce;
    public Vector2 maxForce;
    public Vector2 mousePos;
    void Awake() {
        textCol = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            float mousePosX = mainCam.ScreenToWorldPoint(Input.mousePosition).x;
            float mousePosY = mainCam.ScreenToWorldPoint(Input.mousePosition).y;
            mousePos = new Vector3(mousePosX, mousePosY, 0);// select distance = 10 units from the camera
            Debug.Log(mainCam.ScreenToWorldPoint(mousePos));
            if (textCol.bounds.Contains(mousePos)) {
                Debug.Log("here");
                rb.bodyType = RigidbodyType2D.Dynamic;
                rb.AddForce(new Vector3(Random.Range(minForce.x, maxForce.x), Random.Range(minForce.y, maxForce.y), 0));
            }
        }
    }
}
