using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
	public class MenuScript : MonoBehaviour
    {
        public void Play()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        public void SettingsCanvasShow()
        {
            FindObjectOfType<ElementsBuferInMenu>().ChangeSettingsCanvasStatus(SettingsStatus.Show);
        }
        public void SettingsCanvasHide()
        {
			FindObjectOfType<ElementsBuferInMenu>().ChangeSettingsCanvasStatus(SettingsStatus.Hide);
		}
		public void QuitGame()
        {
            Application.Quit();
        }

        public void ToMenu()
        {
            SceneManager.LoadScene(0);
        }
        public void LevelSelect(int level)
        {
            SceneManager.LoadScene(level);
        }

    }
}