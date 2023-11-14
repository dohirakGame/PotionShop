using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Data
{
    public class DataCard : MonoBehaviour
    {
        [Header("����������� ��� �����")]
        public List<Sprite> redCardImage;
        public List<Sprite> greenCardImage;
        public List<Sprite> blueCardImage;
        public List<Sprite> yellowCardImage;
        public List<Sprite> blackCardImage;

        [Header("����������� ��� ���� �����")]
        public List<Sprite> cardTypeImage;

        [Header("����������� ��� ���� ������ �����")]
        public List<Sprite> bonusImage;
    }
}