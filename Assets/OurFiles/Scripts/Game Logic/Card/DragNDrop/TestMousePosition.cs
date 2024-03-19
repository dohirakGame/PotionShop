using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMousePosition : MonoBehaviour
{
	public float posX;
	private void Update()
	{
		posX = Input.mousePosition.x;
	}
}
