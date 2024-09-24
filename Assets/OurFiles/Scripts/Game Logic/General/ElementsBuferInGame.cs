using Game_Logic.Table;
using TMPro;
using UnityEngine;

namespace Game_Logic.General
{
	public class ElementsBuferInGame : MonoBehaviour
    {
        [Header("Static components")]
        [SerializeField] private Canvas _mainCanvas;
        [SerializeField] private Canvas _settingsCanvas;

        [Header("Scripts on other objects")]
        [SerializeField] private PointsController _pointsController;
        [SerializeField] private ScoresController _scoresController;

        [Header("Text panels")]
        [SerializeField] private TextMeshProUGUI _pointsText;
        [SerializeField] private TextMeshProUGUI _scoresText;

        [Header("Canvas")]
        [SerializeField] private GameObject _canvasForPause;
        [SerializeField] private GameObject _canvasForReward;

        public Canvas GetMainCanvas() => _mainCanvas;
        public PointsController GetPointsController() => _pointsController;
        public ScoresController GetScoresController() => _scoresController;
        public TextMeshProUGUI GetPointsText() => _pointsText;
        public TextMeshProUGUI GetScoresText() => _scoresText;

        public GameObject GetPauseCanvas() => _canvasForPause;
        public void GetLoseCanvas()
        {
            _canvasForReward?.SetActive(true);
            _canvasForReward.GetComponent<RewardMenu>()?.ShowLoseOption();
        }
        public void GetWinCanvas()
        {
            _canvasForReward?.SetActive(true);
            _canvasForReward.GetComponent<RewardMenu>()?.ShowWinOption();
        }
    }
}