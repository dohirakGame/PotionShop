using Game_Logic.Client;
using Game_Logic.Deck;
using UI;
using UnityEngine;

namespace Data
{
	public class DataBootstrap : MonoBehaviour
	{
		[SerializeField] private LoadCurrentDayJSON _loadCurrentDayJSON;
		[SerializeField] private LoadClientsJSON _loadClientsJSON;
		[SerializeField] private CreateDay _createDay;

		[SerializeField] private CreateDeck _redCreateDeck;
		[SerializeField] private CreateDeck _greenCreateDeck;
		[SerializeField] private CreateDeck _blueCreateDeck;
		[SerializeField] private CreateDeck _yellowCreateDeck;

		[SerializeField] private TopCard _redDeck;
		[SerializeField] private TopCard _greenDeck;
		[SerializeField] private TopCard _blueDeck;
		[SerializeField] private TopCard _yellowDeck;

		[SerializeField] private TutorialMenu _tutorial;
		private void Start()
		{
			_loadCurrentDayJSON.Initialize();
			_createDay.LoadFromJSON(_loadClientsJSON.Initialize());

			_redCreateDeck.Initialize();
			_greenCreateDeck.Initialize();
			_blueCreateDeck.Initialize();
			_yellowCreateDeck.Initialize();

			_redDeck.Initialize();
			_greenDeck.Initialize();
			_blueDeck.Initialize();
			_yellowDeck.Initialize();

			_tutorial.Initialize();
		}
	}
}