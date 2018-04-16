using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text : MonoBehaviour {

	static int totalClicked = 0;

	BoxCollider2D textCol;
	Rigidbody2D rb;
	Camera mainCam;
	bool touched;
	Vector2 originalPos;
	Quaternion originalRot;

	GameObject plane;
	public GameObject redaction;


	public Vector2 minForce;
	public Vector2 maxForce;
	public Vector2 mousePos;
	void Awake() {
		totalClicked = 0;
		textCol = GetComponent<BoxCollider2D>();
		rb = GetComponent<Rigidbody2D>();
		originalPos = transform.position;
		originalRot = transform.rotation;
		touched = false;
		mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
	}

	// Update is called once per frame
	void Update() {
		if (!touched && Input.GetMouseButtonDown(0)) {
			float mousePosX = mainCam.ScreenToWorldPoint(Input.mousePosition).x;
			float mousePosY = mainCam.ScreenToWorldPoint(Input.mousePosition).y;
			mousePos = new Vector3(mousePosX, mousePosY, 0);// select distance = 10 units from the camera
			if (textCol.bounds.Contains(mousePos) && totalClicked < 3) {
				totalClicked++;
				rb.bodyType = RigidbodyType2D.Dynamic;
				rb.AddForce(new Vector3(Random.Range(minForce.x, maxForce.x), Random.Range(minForce.y, maxForce.y), 0));
				touched = true;

				plane = Instantiate(redaction);

				plane.transform.position = new Vector3(rb.gameObject.transform.position.x, rb.gameObject.transform.position.y, rb.gameObject.transform.position.z);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (touched && other.gameObject.tag == "Player") {
			totalClicked--;
			if (totalClicked < 0) {
				totalClicked = 0;
			}
			transform.position = originalPos;
			transform.rotation = originalRot;
			rb.bodyType = RigidbodyType2D.Static;
			touched = false;
			Destroy(plane);
		}
	}
}

