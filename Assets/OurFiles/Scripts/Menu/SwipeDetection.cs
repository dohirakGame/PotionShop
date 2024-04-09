using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
	public static event OnSwipeInput SwipeEvent;
	public delegate void OnSwipeInput(Vector2 direction);

	private Vector2 _tapPosition;
	private Vector2 _swipeDelta;

	private float _deadZone;

	[SerializeField] private GameObject _backgroundController;

	private bool _isMobile;

	private void Start()
	{
		_isMobile = Application.isMobilePlatform;
		_deadZone = Screen.width / 3;
	}
	private void Update()
	{
		if (!_isMobile)
		{
			if (Input.GetMouseButtonDown(0))
			{
				_tapPosition = Input.mousePosition;
				_swipeDelta = Vector2.zero;
			}
            else
            {
                 if (Input.GetMouseButtonUp(0))
				{
					EndSwipe();
					ResetSwipe();
				}
            }
        }
		else
		{
			if (Input.touchCount > 0)
			{
				if (Input.GetTouch(0).phase == TouchPhase.Began) 
				{
					_tapPosition = Input.GetTouch(0).position;
					_swipeDelta = Vector2.zero;
				}
				else if (Input.GetTouch(0).phase == TouchPhase.Canceled || Input.GetTouch(0).phase == TouchPhase.Ended)
				{
					EndSwipe();
					ResetSwipe();
				}
			}
		}
		CheckSwipe();
	}

	private void CheckSwipe()
	{

			if (!_isMobile && Input.GetMouseButton(0))
			{
				Vector2 xPositionBackground = _backgroundController.transform.localPosition;
				xPositionBackground.x = Input.mousePosition.x - _tapPosition.x;
				_backgroundController.transform.localPosition = xPositionBackground;

				_swipeDelta = (Vector2)Input.mousePosition - _tapPosition;
			}
			else if (Input.touchCount > 0)
			{
				Vector2 xPositionBackground = _backgroundController.transform.localPosition;
				xPositionBackground.x = Input.touches[0].position.x - _tapPosition.x;
				_backgroundController.transform.localPosition = xPositionBackground;

				_swipeDelta = Input.GetTouch(0).position - _tapPosition;
			}
	}
	private void EndSwipe()
	{
		if (_swipeDelta.magnitude > _deadZone)
		{
			if (SwipeEvent != null)
			{
				SwipeEvent(_swipeDelta.x > 0 ? Vector2.right : Vector2.left);
			}
		}
	}
	private void ResetSwipe()
	{
		_tapPosition = Vector2.zero;
		_swipeDelta = Vector2.zero;
	}
}
