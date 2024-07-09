using Data.JSONStruct;
using System;
using System.IO;
using UnityEngine;

namespace Data
{
    public class SaveClientsJSON : MonoBehaviour
    {
        [Header("File Name")]
		[SerializeField] private string _fileName = "DayNClients.json";

        [Header("Data")]
        [SerializeField] private string _saveJSONPath;
        [SerializeField] private DayJSON _dayJson;

		[ContextMenu("SaveDay")]
        public void SaveDay()
        {
            Debug.Log("saved");

            _saveJSONPath = Path.Combine(Application.persistentDataPath, _fileName);

            DayJSON day = new DayJSON
            {
                dayNclients = _dayJson.dayNclients
            };

            string json = JsonUtility.ToJson(day, true);

            try
            {
                File.WriteAllText(_saveJSONPath, json);
            }
            catch (System.Exception e)
            {
				Debug.Log("{GameLog} => [GameCore] - (<color=red>Error</color>) - SaveToFile -> " + e.Message);
			}
        }
    }
}