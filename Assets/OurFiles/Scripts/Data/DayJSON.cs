using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Game_Logic.CardLogic;

public class DayJSON : MonoBehaviour
{
    public DaynClients daynclients;
    [ContextMenu("Load Day")]
    public void LoadDay()
    {
        daynclients = JsonUtility.FromJson<DaynClients>(File.ReadAllText(Application.streamingAssetsPath+"/DaynClients.json"));
    }
    [ContextMenu("Save Day")]
    public void SaveDay()
    {
        File.WriteAllText(Application.streamingAssetsPath+"/DaynClients.json",JsonUtility.ToJson(daynclients,true));
    }
    [System.Serializable]
    public class DaynClients
    {
        public int ammount;
        public Client[] guests;
        public int specialID;
        public int mission;
        public int experience;
    }
    [System.Serializable]
    public class Client
    {
        public CardColor main;
        public CardColor add;
    }
}
