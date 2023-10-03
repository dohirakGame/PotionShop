using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestStateChange : MonoBehaviour
{
	private void Start()
	{
		CurrentState currentStateInDeck = new CurrentState(new StateInDeck());

		currentStateInDeck.InDeck();
	}
}
