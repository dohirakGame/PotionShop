using System.Collections.Generic;
using UnityEngine;

namespace Game_Logic.Table
{
	public class TableBootsTrap : MonoBehaviour
    {
        [SerializeField] private TablePositions _tablePositions;

		private void Start()
		{
			InitializePositionData();
			_tablePositions.Initialize();
		}

		private void InitializePositionData()
		{
			List<Transform> positions = _tablePositions.GetPositions();
			for (int i = 0; i < positions.Count; i++)
			{
				positions[i].GetComponent<PositionData>().Initialize();
			}
		}
	}
}