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
            return _clients2[index];
        }

        public int GetCountClientsInList()
        {
            return _clients2.Count;
        }

        public void LoadFromJSON(List<ClientColors> clients)
        {
            for (int i = 0; i < clients.Count; i++)
            {
                _clients2.Add(new Client());
                _clients2[i].SetMain(clients[i].mainColor);
                _clients2[i].SetAdd(clients[i].additionalColor);
            }
        }
    }
}