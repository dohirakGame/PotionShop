using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game_Logic.CardLogic
{
	public class CurrentState
	{
		private CardState _state = null;

		public CurrentState(CardState state)
		{
			this.TransitionTo(state);
		}

		// �������� ��������� �������� ������ ��������� �� ����� ����������.
		public void TransitionTo(CardState state)
		{
			Debug.Log("State is change");
			this._state = state;
			this._state.SetContext(this);
		}

		// �������� ���������� ����� ������ ��������� �������� �������
		// ���������.
		public void InDeck()
		{
			this._state.Handle1();
			this._state.Handle2();
			this._state.Handle3();
		}

		public void OnTable()
		{
			this._state.Handle2();
		}

		public void BeforeCreate()
		{
			this._state.Handle3();
		}
	}
}