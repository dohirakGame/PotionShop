using UnityEngine;
using UnityEngine.EventSystems;

public class UIItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
	private CanvasGroup _canvasGroup;
	private Canvas _mainCanvas;
	private RectTransform _rectTransfrom;

	private void Start()
	{
		_canvasGroup = GetComponent<CanvasGroup>();
		_rectTransfrom = GetComponent<RectTransform>();
		_mainCanvas = GetComponentInParent<Canvas>();
	}
	public void OnBeginDrag(PointerEventData eventData)
	{
		/*var slotTransform = _rectTransfrom.parent;
		slotTransform.SetAsLastSibling();*/
		_canvasGroup.blocksRaycasts = false;
	}

	public void OnDrag(PointerEventData eventData)
	{
		_rectTransfrom.anchoredPosition += eventData.delta/_mainCanvas.scaleFactor;
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		/*var slotTransform = _rectTransfrom.parent;
		slotTransform.SetAsFirstSibling();*/
		transform.localPosition = Vector3.zero;
		_canvasGroup.blocksRaycasts = true;
	}
}
