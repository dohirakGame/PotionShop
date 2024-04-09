using UnityEngine;

public class SwipeMenu : MonoBehaviour
{
	[SerializeField] private GameObject _backgroundController;

	private float _screenWidth;
	private int _screenID;

	private void Start()
	{
		ScreenOnStart();
	}

	private void OnMouseDown()
	{
		Debug.Log("down");
		SwipeDetection.SwipeEvent += OnSwipe;
	}
	private void OnMouseUp()
	{
		Debug.Log("up");
		SwipeDetection.SwipeEvent -= OnSwipe;
	}
	private void OnSwipe(Vector2 direction)
	{
		Debug.Log(direction);
		if (direction == Vector2.right && _screenID > -1)
		{
			Debug.Log("right");
			_screenID++;
			SwipeScreen();
		}
		if (direction == Vector2.left && _screenID < 1)
		{
			Debug.Log("left");
			_screenID--;
			SwipeScreen();
		}
    }

	private void ScreenOnStart()
	{
		_screenWidth = Screen.width;
		_screenID = 0;
		SwipeScreen();
	}
	private void SwipeScreen()
	{
		_backgroundController.transform.localPosition = new Vector2(-_screenWidth * _screenID, _backgroundController.transform.localPosition.y);
	}
}
