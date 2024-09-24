using Data;
using UnityEngine;

namespace UI
{
    public class TutorialMenu : MonoBehaviour
    {
        [SerializeField] private GameObject _tutorialPanel;
        public void CloseTutorial()
        {
            _tutorialPanel.SetActive(false);
        }

		public void Initialize()
		{
			if (FindObjectOfType<LoadCurrentDayJSON>().GetCurrentDay() != 1)
            {
                CloseTutorial();
            }
		}
	}
}