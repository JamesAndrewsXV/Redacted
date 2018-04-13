using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text : MonoBehaviour {

	BoxCollider2D textCol;
	Rigidbody2D rb;
	Camera mainCam;
	bool touched;
	Vector2 originalPos;


	public Vector2 minForce;
	public Vector2 maxForce;
	public Vector2 mousePos;
	void Awake() {
		textCol = GetComponent<BoxCollider2D>();
		rb = GetComponent<Rigidbody2D>();
		originalPos = transform.position;
		touched = false;
		mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
	}

	// Update is called once per frame
	void Update() {
		if (!touched && Input.GetMouseButtonDown(0)) {
			float mousePosX = mainCam.ScreenToWorldPoint(Input.mousePosition).x;
			float mousePosY = mainCam.ScreenToWorldPoint(Input.mousePosition).y;
			mousePos = new Vector3(mousePosX, mousePosY, 0);// select distance = 10 units from the camera
			if (textCol.bounds.Contains(mousePos)) {
				rb.bodyType = RigidbodyType2D.Dynamic;
				rb.AddForce(new Vector3(Random.Range(minForce.x, maxForce.x), Random.Range(minForce.y, maxForce.y), 0));
				touched = true;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (touched && other.gameObject.tag == "Player") {
			transform.position = originalPos;
			rb.bodyType = RigidbodyType2D.Static;
			touched = false;
		}
	}
}
