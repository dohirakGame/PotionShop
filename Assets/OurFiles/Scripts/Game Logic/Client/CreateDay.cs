using Data.JSONStruct;
using System.Collections.Generic;
using UnityEngine;

namespace Game_Logic.Client
{
    public class CreateDay : MonoBehaviour
    {
        [SerializeField] private List<Client> _clients;
        [SerializeField] private List<Client> _clients2;
        [SerializeField] private List<ClientColors> _clientsJSON;

        public Client GetClient(int index)
        {
            return _clients[index];
        }

        public int GetCountClientsInList()
        {
            return _clients.Count;
        }

        public void LoadFromJSON(List<ClientColors> clients)
        {
            for (int i = 0; i < clients.Count; i++)
            {
                _clients.Add(new Client());
                _clients[i].SetMain(clients[i].mainColor);
                _clients[i].SetAdd(clients[i].additionalColor);
            }
        }
    }
}