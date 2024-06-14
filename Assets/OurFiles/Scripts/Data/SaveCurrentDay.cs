using System.IO;
using UnityEngine;

namespace Data
{
	public class SaveCurrentDay : MonoBehaviour
	{
		[SerializeField] private string _savePath;
		[SerializeField] private string _fileName = "CurrentDay.json";

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
				Debug.Log("file is writen");
				File.WriteAllText(_savePath, json);
			}
			catch (System.Exception e)
			{
				Debug.Log("{GameLog} => [GameCore] - (<color=red>Error</color>) - SaveToFile -> " + e.Message);
			}
		}
	}
}