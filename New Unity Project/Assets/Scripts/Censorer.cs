using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Censorer : MonoBehaviour {

	public float flipTimer;

	public GameObject textParent;

	private bool canFlip = true;

	// Update is called once per frame
	void Update() {
		if (canFlip && Input.GetMouseButtonDown(1)) {
			canFlip = false;
			StartCoroutine(FlipTime());
			if (textParent.transform.rotation.eulerAngles.y == 180) {
				textParent.transform.rotation = Quaternion.Euler(0, 0, 0);
			} else {
				textParent.transform.rotation = Quaternion.Euler(0, 180, 0);
			}
		}
	}

	IEnumerator FlipTime() {
		yield return new WaitForSeconds(flipTimer);
		canFlip = true;
	}
}
