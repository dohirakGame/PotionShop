using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionData : MonoBehaviour
{
    [SerializeField] private bool _isFree;
    [SerializeField] private float _xPosition;
    [SerializeField] private string _cardColor;
    [SerializeField] private string _cardBonusColor;

	private void Start()
	{
        SetFreeStatus(true);
	}
	public void SetFreeStatus(bool status) => _isFree = status;
    public bool GetFreeStatus() => _isFree;

    public float GetXPosition() => _xPosition;
}
