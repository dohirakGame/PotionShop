using System.IO;
using UnityEngine;

namespace Data
{
	public class SaveCurrentDayJSON : MonoBehaviour
	{
		[SerializeField] private string _fileName = "CurrentDay.json";
		[SerializeField] private string _savePath;

		public void SaveDay(int dayNumber)
		{
			_savePath = Path.Combine(Application.persistentDataPath, _fileName);
			CurrentDayJSON dayJson = new CurrentDayJSON
			{
				currentDay = dayNumber
			};

			string json = JsonUtility.ToJson(dayJson, true);

			try
			{
				File.WriteAllText(_savePath, json);
			}
			catch (System.Exception e)
			{
				Debug.Log("{GameLog} => [GameCore] - (<color=red>Error</color>) - SaveToFile -> " + e.Message);
			}
		}
	}
}