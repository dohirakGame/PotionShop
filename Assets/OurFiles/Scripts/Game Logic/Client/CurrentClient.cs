using Data;
using UnityEngine;
using UnityEngine.UI;
using Game_Logic.CardLogic;
using Game_Logic.Progression;
using Game_Logic.General;

namespace Game_Logic.Client
{
	public class CurrentClient : MonoBehaviour
    {
        [SerializeField] private GameObject _clientPrefab;
        [SerializeField] private GameObject _reqPrefab;
        [SerializeField] private DataClient _dataClient;
        [SerializeField] private LevelController _levelController;

        private CardColor _main;
        private CardColor _added;

        private int _currentclient;

        private void Start()
        {
            _currentclient = 0;
            NextClient();
        }

        public void NextClient()
        {
            if (_currentclient < gameObject.GetComponent<CreateDay>().GetCountClientsInList())
            {
                if (gameObject.transform.childCount > 0) Destroy(gameObject.transform.GetChild(0).gameObject);
                InstantiateClient();
                _currentclient++;
            }
            else
            {
                FindObjectOfType<ElementsBufer>().GetWinCanvas();
            }
        }

        private void InstantiateClient()
        {
            GameObject client = Instantiate(_clientPrefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity);
            client.transform.SetParent(gameObject.transform);
            client.transform.localScale = new Vector3(1, 1, 1);
            client.transform.localPosition = new Vector3(transform.position.x, transform.position.y - 600f, 0);

            SetClientInformation(client);
        }

        private void SetClientInformation(GameObject client)
        {
            // Нужно будет переписать весь блок - вылгядит не очень
            Image clientImage = client.GetComponent<Image>();
            Image mainImage = client.transform.GetChild(0).GetComponent<Image>();
            Image addImage = client.transform.GetChild(1).GetComponent<Image>();

            clientImage.sprite = _dataClient.clientSprite[Random.Range(0, _dataClient.clientSprite.Count)];

            Client reqs = this.GetComponent<CreateDay>().GetClient(_currentclient);
            switch (reqs.GetMain())
            {
                case CardColor.Red:
                    mainImage.sprite = _dataClient.requestSprite[0];
                    _main = CardColor.Red;
                    break;
                case CardColor.Green:
					mainImage.sprite = _dataClient.requestSprite[1];
					_main = CardColor.Green;
                    break;
                case CardColor.Blue:
					mainImage.sprite = _dataClient.requestSprite[2];
					_main = CardColor.Blue;
                    break;
                case CardColor.Yellow:
                    mainImage.sprite = _dataClient.requestSprite[3];
                    _main = CardColor.Yellow;
                    break;
                case CardColor.Black:
                    mainImage.sprite = _dataClient.requestSprite[4];
                    _main = CardColor.Black;
                    break;
            }
            switch (reqs.GetAdd())
            {
                case CardColor.Red:
                    addImage.sprite = _dataClient.requestSprite[0];
                    _added = CardColor.Red;
                    break;
                case CardColor.Green:
                    addImage.sprite = _dataClient.requestSprite[1];
                    _added = CardColor.Green;
                    break;
                case CardColor.Blue:
                    addImage.sprite = _dataClient.requestSprite[2];
                    _added = CardColor.Blue;
                    break;
                case CardColor.Yellow:
                    addImage.sprite = _dataClient.requestSprite[3];
                    _added = CardColor.Yellow;
                    break;
                case CardColor.Black:
                    addImage.sprite = _dataClient.requestSprite[4];
                    _added = CardColor.Black;
                    break;
            }
        }

        public CardColor GetMain() => _main;
        public CardColor GetAdded() => _added;
    }
}