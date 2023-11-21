using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Data
{
    public class DataCard : MonoBehaviour
    {
        [Header("Изображения под цвета")]
        public List<Sprite> redCardImage;
        public List<Sprite> redItemImage;

        public List<Sprite> greenCardImage;
		public List<Sprite> greenItemImage;

		public List<Sprite> blueCardImage;
		public List<Sprite> blueItemImage;

		public List<Sprite> yellowCardImage;
		public List<Sprite> yellowItemImage;

		public List<Sprite> blackCardImage;
		public List<Sprite> blackItemImage;

		[Header("Изображения под цвет карты")]
        public List<Sprite> cardTypeImage;

        [Header("Изображения под цвет бонуса карты")]
        public List<Sprite> bonusImage;
    }
}