using Data;
using Game_Logic.Client;
using UnityEngine;

public class DataBootstrap : MonoBehaviour
{
	[SerializeField] private LoadCurrentDayJSON _loadCurrentDayJSON;
	[SerializeField] private LoadClientsJSON _loadClientsJSON;
	[SerializeField] private CreateDay _createDay;
	private void Start()
	{
		_loadCurrentDayJSON.Initialize();
		_createDay.LoadFromJSON(_loadClientsJSON.Initialize());

	}
}
