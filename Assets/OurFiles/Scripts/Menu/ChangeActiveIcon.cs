using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
	public class ChangeActiveIcon : MonoBehaviour
    {
        [Header("Цвета")]
        [SerializeField] private Color _unselected;
        [SerializeField] private Color _selected;

        [Header("Объекты")]
        [SerializeField] private GameObject _lastSelected;
		private void Start()
		{
            SelectNew();
		}
		public void ChangeColor(GameObject icon)
        {
            UnselectOld();
            SetObject(icon);
            SelectNew();
        }        

        private void SetObject(GameObject icon)
        {
            _lastSelected = icon;
        }
        private void UnselectOld()
        {
            _lastSelected.GetComponent<Image>().color = _unselected;
            _lastSelected.GetComponent<RectTransform>().localScale = new Vector2(1f, 1f);
        }
        private void SelectNew()
        {
            _lastSelected.GetComponent <Image>().color = _selected;
            _lastSelected.GetComponent<RectTransform>().localScale = new Vector2(1.3f, 1.3f);
        }
    }
}