using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OurCameraFollow : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start() {
		gameObject.transform.position = player.transform.position;
	}

	// Update is called once per frame
	void Update() {
		gameObject.transform.position = Vector2.Lerp(gameObject.transform.position, player.transform.position, Time.time);
		gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -10);
	}
}
