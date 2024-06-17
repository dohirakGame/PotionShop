using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Game_Logic.CardLogic;

namespace Collection.Client
{
    public class GAL_ClientsJSON : MonoBehaviour
    {
        public GAL_Clients galclients;

        [ContextMenu("Load GAL_Clients")]
        public GAL_Clients LoadGAL_Clients()
        {
            galclients = JsonUtility.FromJson<GAL_Clients>(File.ReadAllText(Application.streamingAssetsPath+"/GAL_Clients.json"));
            return galclients;
        }

        [ContextMenu("Save GAL_Clients")]
        public void SaveGAL_Clients()
        {
            File.WriteAllText(Application.streamingAssetsPath+"/GAL_Clients.json",JsonUtility.ToJson(galclients,true));
        }
    }
    [System.Serializable]
    public class GAL_Clients
    {
        public Gal_Client[] clients;
    }
    [System.Serializable]
    public class Gal_Client
    {
        public bool state;
        public string description;        
    }
}