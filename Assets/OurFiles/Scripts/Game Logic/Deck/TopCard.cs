using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CreateDeck))]

public class TopCard : MonoBehaviour
{
    [SerializeField] private GameObject _cardPrefab;
    [SerializeField] private DataCard _dataCard;
    [SerializeField] private CreateDeck _createDeck;

    private Sprite _cardImage;
    private Sprite _cardColorImage;
    private Sprite _bonusImage;
	private int _bonusPosition;
    private int _point;

	private void OnValidate()
	{
		_dataCard = FindObjectOfType<DataCard>();
        _createDeck = gameObject.GetComponent<CreateDeck>();
	}

	private void Start()
	{
		FlipCardOnTopDeck();
	}

	public void FlipTest() => FlipCardOnTopDeck();
	private void FlipCardOnTopDeck()
	{
		if (_createDeck.CountCardsInList() > 0)
		{
			// Для тестов
			if (gameObject.transform.childCount > 0)
				Destroy(gameObject.transform.GetChild(0).gameObject);

			LoadCardInformationFromData();
			InstantiateCardOnTopDeck();
		}
	}

    // Нужно будет потом изменить под выбор конкретной карты
    private void LoadCardInformationFromData()
    {
        int cardIndex = Random.Range(0, _createDeck.CountCardsInList());
        Card card = _createDeck.GetCard(cardIndex);

        Debug.Log(cardIndex);

        LoadImage(card);
        LoadColor(card);
        LoadBonus(card);
        LoadPoint(card);
    }

	// Загрузка информации с выбранной карты
    private void LoadImage(Card card)
    {
        int countImage;
        switch (card.GetColor())
        {
            case CardColor.Red:
				countImage = Random.Range(0, _dataCard.redCardImage.Count);
				_cardImage = _dataCard.redCardImage[countImage];
				break;
            case CardColor.Green:
				countImage = Random.Range(0, _dataCard.greenCardImage.Count);
				_cardImage = _dataCard.greenCardImage[countImage];
				break;
            case CardColor.Blue:
				countImage = Random.Range(0, _dataCard.blueCardImage.Count);
				_cardImage = _dataCard.blueCardImage[countImage];
				break;
            case CardColor.Yellow:
				countImage = Random.Range(0, _dataCard.yellowCardImage.Count);
				_cardImage = _dataCard.yellowCardImage[countImage];
				break;
            case CardColor.Black:
				countImage = Random.Range(0, _dataCard.blackCardImage.Count);
				_cardImage = _dataCard.blackCardImage[countImage];
				break;
        }
    }
    private void LoadColor(Card card)
    {
        switch (card.GetColor())
        {
            case CardColor.Red:
				foreach (Sprite item in _dataCard.cardTypeImage)
				{
					if (item.name == "Red")
					{
                        Debug.Log($"RedDeck = {item.name}");
						_cardColorImage = item;
					}
				}
				break;
            case CardColor.Green:
				foreach (Sprite item in _dataCard.cardTypeImage)
				{
					if (item.name == "Green")
					{
						Debug.Log($"GreenDeck = {item.name}");
						_cardColorImage = item;
					}
				}
				break;
            case CardColor.Blue:
				foreach (Sprite item in _dataCard.cardTypeImage)
				{
					if (item.name == "Blue")
					{
						Debug.Log($"BlueDeck = {item.name}");
						_cardColorImage = item;
					}
				}
				break;
            case CardColor.Yellow:
				foreach (Sprite item in _dataCard.cardTypeImage)
				{
					if (item.name == "Yellow")
					{
						Debug.Log($"YellowDeck = {item.name}");
						_cardColorImage = item;
					}
				}
				break;
            case CardColor.Black:
                foreach (Sprite item in _dataCard.cardTypeImage)
                {
                    if (item.name == "Black")
                    {
						Debug.Log($"BlackDeck = {item.name}");
						_cardColorImage = item;
                    }
                }
                break;
            default:
                Debug.Log("Ошибка в цвете");
                break;
        }
    }
    private void LoadBonus(Card card)
    {
        switch (card.GetBonusColor())
        {
            case BonusColor.Red:
				foreach (Sprite item in _dataCard.bonusImage)
				{
					if (item.name == "Red")
					{
						Debug.Log($"RedDeck = {item.name}");
						_bonusImage = item;
					}
				}
				break;
            case BonusColor.Green:
				foreach (Sprite item in _dataCard.bonusImage)
				{
					if (item.name == "Green")
					{
						Debug.Log($"RedDeck = {item.name}");
						_bonusImage = item;
					}
				}
				break;
            case BonusColor.Blue:
				foreach (Sprite item in _dataCard.bonusImage)
				{
					if (item.name == "Blue")
					{
						Debug.Log($"RedDeck = {item.name}");
						_bonusImage = item;
					}
				}
				break;
            case BonusColor.Yellow:
				foreach (Sprite item in _dataCard.bonusImage)
				{
					if (item.name == "Yellow")
					{
						Debug.Log($"RedDeck = {item.name}");
						_bonusImage = item;
					}
				}
				break;
            case BonusColor.Black:
				foreach (Sprite item in _dataCard.bonusImage)
				{
					if (item.name == "Black")
					{
						Debug.Log($"RedDeck = {item.name}");
						_bonusImage = item;
					}
				}
				break;
        }

		switch (card.GetBonus())
		{
			case CardBonus.Left:
				_bonusPosition = 2;
				break;
			case CardBonus.Center:
				_bonusPosition = 3;
				break;
			case CardBonus.Right:
				_bonusPosition = 4;
				break;
		}
    }
    private void LoadPoint(Card card)
    {
        _point = card.GetPoint();
    }

	// Создание карты сверху колоды и передача туда загруженной информации
    private void InstantiateCardOnTopDeck()
    {
        GameObject card = Instantiate(_cardPrefab, gameObject.transform.position, Quaternion.identity);
        card.transform.SetParent(gameObject.transform);
        card.transform.localScale = transform.localScale;

        SetCardInformation(card);
    }
    private void SetCardInformation(GameObject card)
    {
		card.GetComponent<Image>().sprite = _cardImage;
        card.transform.GetChild(0).GetComponent<Image>().sprite = _cardColorImage;
        card.transform.GetChild(_bonusPosition).GetComponent<Image>().sprite = _bonusImage;
        card.transform.GetChild(1).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = _point.ToString();
    }
}
