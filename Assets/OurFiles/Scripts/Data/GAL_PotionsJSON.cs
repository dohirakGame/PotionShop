using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Game_Logic.CardLogic;

namespace Collection.Potion
{
    public class GAL_PotionsJSON : MonoBehaviour
    {
        public GAL_Potions galpotions;

        [ContextMenu("Load GAL_Potions")]
        public GAL_Potions LoadGAL_Potions()
        {
            galpotions = JsonUtility.FromJson<GAL_Potions>(File.ReadAllText(Application.streamingAssetsPath+"/GAL_Potions.json"));
            return galpotions;
        }

        [ContextMenu("Save GAL_Potions")]
        public void SaveGAL_Potions()
        {
            File.WriteAllText(Application.streamingAssetsPath+"/GAL_Potions.json",JsonUtility.ToJson(galpotions,true));
        }
    }
    [System.Serializable]
    public class GAL_Potions
    {
        public GAL_Potion[] potions;
    }
    [System.Serializable]
    public class GAL_Potion
    {
        public bool state;
        public string description;        
    }
}