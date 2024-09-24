using UnityEngine;
using UnityEngine.UI;

namespace Menu {
    public enum MusicStatus
    {
        MusicOn,
        MusicOff
    }
    public enum SoundStatus
    {
        SoundOn,
        SoundOff
    }
    public enum SettingsStatus
    {
        Show,
        Hide
    }
    public class ElementsBuferInMenu : MonoBehaviour
    {
        [Header("Sprites")]
        [SerializeField] private Sprite _soundOnIcon;
        [SerializeField] private Sprite _soundOffIcon;
        [SerializeField] private Sprite _musicOnIcon;
        [SerializeField] private Sprite _musicOffIcon;

        [Header("Image Fields")]
        [SerializeField] private Image _soundIcon;
        [SerializeField] private Image _musicIcon;

        [Header("Canvas")]
        [SerializeField] private Canvas _settingsCanvas;

        public void ChangeSettingsCanvasStatus(SettingsStatus status)
        {
            if (status == SettingsStatus.Show)
            {
                _settingsCanvas.gameObject.SetActive(true);
            }
            else
            {
                _settingsCanvas.gameObject.SetActive(false);
            }
        }

        public void ChangeSoundIcon(SoundStatus status)
        {
            if (status == SoundStatus.SoundOn)
            {
                _soundIcon.sprite = _soundOnIcon;
            }
            else
            {
				_soundIcon.sprite = _soundOffIcon;
			}
		}
        public void ChangeMusicIcon(MusicStatus status)
        {
            if (status == MusicStatus.MusicOn)
            {
                _musicIcon.sprite = _musicOnIcon;
            }
            else
            {
                _musicIcon.sprite = _musicOffIcon;
            }
        }
    }
}