using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public abstract class CardState
{
	protected CurrentState _currentState;

	public void SetContext(CurrentState currentState)
	{
		this._currentState = currentState;
	}

	public abstract void Handle1();

	public abstract void Handle2();

	public abstract void Handle3();
}
