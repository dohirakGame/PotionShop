using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDay : MonoBehaviour
{
    [SerializeField] private List<Client> _clients;

    public Client GetClient(int index)
    {
        return _clients[index];
    }

    public int CountClientsInList()
    {
        return _clients.Count;
    }

}
