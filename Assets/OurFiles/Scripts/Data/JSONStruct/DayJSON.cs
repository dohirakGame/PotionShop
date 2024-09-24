using Game_Logic.CardLogic;
using System.Collections.Generic;

namespace Data.JSONStruct
{
    [System.Serializable]
	public struct DayJSON
    {
        public List<DayNClients> dayNclients;
    }

    [System.Serializable]
    public struct DayNClients
    {
        public int dayID;
        public List<ClientColors> guests;
    }

    [System.Serializable]
    public struct DayNCards
    {
        public int dayID;
		//List<Card> cards;
		public List<CardProperties> cardsProperties;
	}

	[System.Serializable]
    public struct CardProperties
    {
        public List<Card> cards;
    }

    [System.Serializable]
    public struct ClientColors
    {
        public CardColor mainColor;
        public CardColor additionalColor;
    }
    /*public struct DayJSON
    {
        public DaynClients daynclients;

        [ContextMenu("Load Day")]
        public void LoadDay()
        {
            daynclients = JsonUtility.FromJson<DaynClients>(File.ReadAllText(Application.streamingAssetsPath + "/DaynClients.json"));
        }
        [ContextMenu("Save Day")]
        public void SaveDay()
        {


            File.WriteAllText(Application.streamingAssetsPath + "/DaynClients.json", JsonUtility.ToJson(daynclients, true));
        }
        [System.Serializable]
        public struct DaynClients
        {
            public int ammount;
            public Client[] guests;
            public int specialID;
            public int mission;
            public int experience;
        }
        [System.Serializable]
        public struct Client
        {
            public CardColor main;
            public CardColor add;
        }
    }*/
}