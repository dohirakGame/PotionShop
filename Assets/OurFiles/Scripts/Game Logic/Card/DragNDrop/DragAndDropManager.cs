using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDropManager : MonoBehaviour
{
	[SerializeField] private Collider _currentCollider;

	private Camera _mainCamera;
	private Plane _dragPlane;
	private bool _inputStart;
	private Vector2 _offset;

	private int _layerMask;

	private void Start()
	{
		_mainCamera = Camera.main;
		_layerMask = 1 << 7;
	}

	private void Update()
	{
#if UNITY_EDITOR
		if (Input.GetMouseButtonDown(0)) SelectPart();
		if (Input.GetMouseButtonUp(0)) Drop();
#endif

		if (Input.touchCount > 0)
		{
			var touch = Input.GetTouch(0);

			if (touch.phase == TouchPhase.Began) SelectPart();
			if (touch.phase == TouchPhase.Ended) Drop();
		}

		DragAndDropObject();
	}

	private void SelectPart()
	{
		RaycastHit hit;

		Ray cameraRay = _mainCamera.ScreenPointToRay(Input.mousePosition);
		// Physics.Raycast(cameraRay, out hit, 10f, LayerMask.GetMask("Card"))
		if (Physics.Raycast(cameraRay, out hit, _layerMask))
		{
			_currentCollider = hit.collider;
			_dragPlane = new Plane(_mainCamera.transform.forward, _currentCollider.transform.position);
			float planeDistance;
			_dragPlane.Raycast(cameraRay, out planeDistance);
			_offset = _currentCollider.transform.position - cameraRay.GetPoint(planeDistance);
		}
	}

	private void DragAndDropObject()
	{
		if (_currentCollider == null) return;

		Ray cameraRay = _mainCamera.ScreenPointToRay(Input.mousePosition);

		float planeDistance;
		_dragPlane.Raycast(cameraRay, out planeDistance);

		_currentCollider.transform.position = cameraRay.GetPoint(planeDistance);

		// Момент для ограничения движения объекта
		/*if (_currentCollider.transform.position.x < 0.5f)
		{
			_currentCollider.transform.position = new Vector2(0.5f, _currentCollider.transform.position.y);
		}*/
	}

	private void Drop()
	{
		if (_currentCollider == null) return;

		Debug.Log("layer = " + _layerMask.ToString());

		RaycastHit hit;

		Ray cameraRay = _mainCamera.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(cameraRay, out hit, _layerMask))
		{
			if (hit.collider.CompareTag("Table")) Debug.Log("TableTrue");
			Vector2 newPosition = hit.transform.position;

			_currentCollider.transform.position = newPosition;
		}
		else
		{
			Debug.Log("TableFalse");
			Vector2 deckPosition = _currentCollider.transform.parent.transform.position;

			_currentCollider.transform.position = deckPosition;
		}
		_currentCollider = null;
	}
}
