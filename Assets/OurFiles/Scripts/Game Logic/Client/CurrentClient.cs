using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentClient : MonoBehaviour
{
    [SerializeField] private GameObject _clientPrefab;
    [SerializeField] private DataClient _dataClient;

    private Sprite _clientSprite;
    
    private void Start()
    {
        NextClient();
    }

    private void NextClient()
    {
        if (gameObject.transform.childCount > 0)
            Destroy(gameObject.transform.GetChild(0).gameObject);

        LoadClientIformationFromData();
        InstantiateClient();

    }

    private void LoadClientIformationFromData()
    {
        _clientSprite = _dataClient.clientSprite[Random.Range(0, _dataClient.clientSprite.Count)];
    }

    private void InstantiateClient()
    {
        GameObject client = Instantiate(_clientPrefab, new Vector3(gameObject.transform.position.x,gameObject.transform.position.y-1.15f,0), Quaternion.identity);
        client.transform.SetParent(gameObject.transform);
        client.transform.localScale = new Vector3(500,800,1);

        SetClientInformation(client);
    }

    private void SetClientInformation(GameObject client)
    {
        SpriteRenderer clientImage = client.GetComponent<SpriteRenderer>();
        clientImage.sprite = _clientSprite;
        switch (Random.Range(0, 2))
        {
            case 0:
                clientImage.color = new Color(0,0,1,1);
                break;
            case 1:
                clientImage.color = new Color(0,1,0,1);
                break;
            case 2:
                clientImage.color = new Color(1,0,0,1);
                break;
        }
    }
}
