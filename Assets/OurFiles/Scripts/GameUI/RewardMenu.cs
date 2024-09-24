using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RewardMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _titleText;
    [SerializeField] private TextMeshProUGUI _rewardText;
    public void ShowWinOption()
    {
        _titleText.text = string.Format("День пройден");
        _rewardText.text = string.Format("Награда: 50");
    }

    public void ShowLoseOption()
    {
        _titleText.text = string.Format("День не пройден");
        _rewardText.text = string.Format("Награда: 5");
	}
}
