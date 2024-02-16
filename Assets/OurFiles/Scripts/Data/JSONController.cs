using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Game_Logic.CardLogic;

public class JSONController : MonoBehaviour
{
    public Player player;
    public DaynClients daynclients;
    public SpecialClients specialclients;

    [ContextMenu("Load Player")]
    public void LoadPlayer()
    {
        player = JsonUtility.FromJson<Player>(File.ReadAllText(Application.streamingAssetsPath+"/Player.json"));
    }
    [ContextMenu("Load Day")]
    public void LoadDay()
    {
        daynclients = JsonUtility.FromJson<DaynClients>(File.ReadAllText(Application.streamingAssetsPath+"/DaynClients.json"));
    }
    [ContextMenu("Load SpecialClients")]
    public void LoadSpecialClients()
    {
        specialclients = JsonUtility.FromJson<SpecialClients>(File.ReadAllText(Application.streamingAssetsPath+"/SpecialClients.json"));
    }

    [ContextMenu("Save Player")]
    public void SavePlayer()
    {
        File.WriteAllText(Application.streamingAssetsPath+"/Player.json",JsonUtility.ToJson(player));
    }
    [ContextMenu("Save Day")]
    public void SaveDay()
    {
        File.WriteAllText(Application.streamingAssetsPath+"/DaynClients.json",JsonUtility.ToJson(daynclients));
    }
    [ContextMenu("Save SpecialClients")]
    public void SaveSpecialClients()
    {
        File.WriteAllText(Application.streamingAssetsPath+"/SpecialClients.json",JsonUtility.ToJson(specialclients));
    }

    [System.Serializable]
    public class Player
    {
        public int currentday;
        public int currency;
        public int experience;
    }
    [System.Serializable]
    public class DaynClients
    {
        public int ammount;
        public CardColor[] colors;
        public int specialID;
        public int mission;
        public int experience;
    }

    [System.Serializable]
    public class SpecialClients
    {
        public int id;
        public Sprite sprite;
        public CardColor request;
    }

}
