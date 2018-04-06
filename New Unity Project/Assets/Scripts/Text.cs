using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text : MonoBehaviour {

    BoxCollider2D textCol;
    Rigidbody2D rb;
    Camera mainCam;

    public Vector2 minForce;
    public Vector2 maxForce;

    void Awake() {
        textCol = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Debug.Log(mainCam.ScreenToWorldPoint(Input.mousePosition));
            if (textCol.bounds.Contains(mainCam.ScreenToWorldPoint(Input.mousePosition))) {
                Debug.Log("here");
                rb.bodyType = RigidbodyType2D.Dynamic;
                rb.AddForce(new Vector2(Random.Range(minForce.x, maxForce.x), Random.Range(minForce.y, maxForce.y)));
            }
        }
    }
}
