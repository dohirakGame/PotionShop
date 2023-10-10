using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentClient : MonoBehaviour
{
    [SerializeField] private GameObject _clientPrefab;
    [SerializeField] private GameObject _reqPrefab;
    [SerializeField] private DataClient _dataClient;

    private Sprite _clientSprite;
    private Sprite _reqSprite;

    private Req _main;
    private Req _added;

    
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
        // Добавить выбор спрайтов, если решим отдельные спрайты на цвета делать
        _reqSprite = _dataClient.requestSprite[0];
    }

    private void InstantiateClient()
    {
        GameObject client = Instantiate(_clientPrefab, new Vector3(gameObject.transform.position.x,gameObject.transform.position.y-1.15f,0), Quaternion.identity);
        GameObject mainReq = Instantiate(_reqPrefab, new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,0), Quaternion.identity);
        GameObject addReq = Instantiate(_reqPrefab, new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,0), Quaternion.identity);
        mainReq.transform.localScale = new Vector3(100,100,1);
        addReq.transform.localScale = new Vector3(80,80,1);
        mainReq.transform.SetParent(client.transform);
        addReq.transform.SetParent(client.transform);
        mainReq.transform.Translate(-200f, 500f, 1f);
        addReq.transform.Translate(-80f, 500f, 1f);
        client.transform.SetParent(gameObject.transform);
        client.transform.localScale = new Vector3(500,800,1);

        SetClientInformation(client,mainReq,addReq);
    }

    private void SetClientInformation(GameObject client, GameObject mainReq, GameObject addReq)
    {
        // Нужно будет переписать весь блок - вылгядит не очень
        SpriteRenderer clientImage = client.GetComponent<SpriteRenderer>();
        SpriteRenderer mainImage = mainReq.GetComponent<SpriteRenderer>();
        SpriteRenderer addImage = addReq.GetComponent<SpriteRenderer>();
        clientImage.sprite = _clientSprite;
        mainImage.sprite = _reqSprite;
        addImage.sprite = _reqSprite;
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
        Client reqs = this.GetComponent<CreateDay>().GetClient(Random.Range(0, 8));
        switch (reqs.GetMain())
        {
            case Req.Red:
                mainImage.color = new Color(1,0,0,1);
                _main = Req.Red;
                break;
            case Req.Green:
                mainImage.color = new Color(0,1,0,1);
                _main = Req.Green;
                break;
            case Req.Blue:
                mainImage.color = new Color(0,0,1,1);
                _main = Req.Blue;
                break;
            case Req.Yellow:
                mainImage.color = new Color(1,1,0,1);
                _main = Req.Yellow;
                break;
            case Req.Black:
                mainImage.color = new Color(0,0,0,1);
                _main = Req.Black;
                break;
        }
        switch (reqs.GetAdd())
        {
            case Req.Red:
                addImage.color = new Color(1,0,0,1);
                _added = Req.Red;
                break;
            case Req.Green:
                addImage.color = new Color(0,1,0,1);
                _added = Req.Green;
                break;
            case Req.Blue:
                addImage.color = new Color(0,0,1,1);
                _added = Req.Blue;
                break;
            case Req.Yellow:
                addImage.color = new Color(1,1,0,1);
                _added = Req.Yellow;
                break;
            case Req.Black:
                addImage.color = new Color(0,0,0,1);
                _added = Req.Black;
                break;
        }
    }

    public Req GetMain() => _main;
    public Req GetAdded() => _added;
}
