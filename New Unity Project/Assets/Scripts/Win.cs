using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Win : MonoBehaviour {

	public float timeToLose;
	public Text timer;


	void Start() {
		StartCoroutine(LoseTimer());
	}

	void Update() {
		timer.text = Time.time.ToString();
	}

	IEnumerator LoseTimer() {
		yield return new WaitForSeconds(timeToLose);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		Score.IncrementCensorerWins();
	}


	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			Score.IncrementPlayerWins();
		}
	}
}
