using System.Collections.Generic;
using UnityEngine;

namespace Game_Logic.Client
{
    public class CreateDay : MonoBehaviour
    {
        [SerializeField] private List<Client> _clients;
        [SerializeField] private List<Client> _clientsJSON;

        public Client GetClient(int index)
        {
            return _clients[index];
        }

        public int GetCountClientsInList()
        {
            return _clients.Count;
        }

        private void LoadFromJSON()
        {

        }
    }
}