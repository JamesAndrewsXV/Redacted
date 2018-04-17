using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	static int playerWins = 0;
	static int censorerWins = 0;

	public Text playerWinsUI;
	public Text censorerWinsUI;

	void Update() {
		playerWinsUI.text = "Player wins: " + playerWins.ToString();
		censorerWinsUI.text = "Censorer wins: " + censorerWins.ToString();
	}

	public static void IncrementPlayerWins() {
		playerWins++;
	}

	public static void IncrementCensorerWins() {
		censorerWins++;
	}
}
