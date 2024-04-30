using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Game_Logic.CardLogic;

public class PlayerJSON : MonoBehaviour
{
    public Player player;
    [ContextMenu("Load Player")]
    public void LoadPlayer()
    {
        player = JsonUtility.FromJson<Player>(File.ReadAllText(Application.streamingAssetsPath+"/Player.json"));
    }
    [ContextMenu("Save Player")]
    public void SavePlayer()
    {
        File.WriteAllText(Application.streamingAssetsPath+"/Player.json",JsonUtility.ToJson(player,true));
    }

    [System.Serializable]
    public class Player
    {
        public int currentday;
        public int currency;
        public int premium_currency;
        public int experience;
    }
}
