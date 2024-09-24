using UnityEngine;

namespace Menu
{
    public class SoundSettings : MonoBehaviour
    {
        private bool _turnedOnSound;
        private bool _turnedOnMusic;

		private void Start()
		{
			_turnedOnSound = true;
            _turnedOnMusic = true;
		}
        public void ChangeSoundStatus()
        {
			if (_turnedOnSound)
			{
				_turnedOnSound = false;
				FindObjectOfType<ElementsBuferInMenu>().ChangeSoundIcon(SoundStatus.SoundOff);
			}
			else
			{
				_turnedOnSound = true;
				FindObjectOfType<ElementsBuferInMenu>().ChangeSoundIcon(SoundStatus.SoundOn);
			}
		}
		public void ChangeMusicStatus()
        {
            if (_turnedOnMusic)
            {
                _turnedOnMusic = false;
                FindObjectOfType<ElementsBuferInMenu>().ChangeMusicIcon(MusicStatus.MusicOff);
            }
            else
            {
                _turnedOnMusic = true;
                FindObjectOfType<ElementsBuferInMenu>().ChangeMusicIcon(MusicStatus.MusicOn);
			}
		}
    }
}