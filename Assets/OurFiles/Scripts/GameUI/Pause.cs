using Game_Logic.General;
using UnityEngine;

namespace UI
{
    public class Pause : MonoBehaviour
    {
        [SerializeField] private ElementsBuferInGame _elementsBufer;

        public void SetPauseInGame()
        {
            _elementsBufer.GetPauseCanvas().SetActive(true);
        }
    }
}