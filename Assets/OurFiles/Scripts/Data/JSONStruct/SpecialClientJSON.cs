using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Game_Logic.CardLogic;

public class SpecialClientJSON : MonoBehaviour
{
    public SpecialClients specialclients;

    [ContextMenu("Load SpecialClients")]
    public void LoadSpecialClients()
    {
        specialclients = JsonUtility.FromJson<SpecialClients>(File.ReadAllText(Application.streamingAssetsPath+"/SpecialClients.json"));
    }

    [ContextMenu("Save SpecialClients")]
    public void SaveSpecialClients()
    {
        File.WriteAllText(Application.streamingAssetsPath+"/SpecialClients.json",JsonUtility.ToJson(specialclients,true));
    }

    [System.Serializable]
    public class SpecialClients
    {
        public int id;
        public Sprite sprite;
        public CardColor request;
    }
}
