using UnityEngine;
using System;
using System.IO;

namespace Data
{
	public class LoadCurrentDayJSON : MonoBehaviour
	{
		[Header("File Name")]
		[SerializeField] private string _fileName = "CurrentDay.json";
		[SerializeField] private CurrentDayJSON _currentDayJSON;

		public void Initialize()
		{
			LoadJSON();
		}
		private void LoadJSON()
		{
			string _filePath = Path.Combine(Application.persistentDataPath, _fileName);
			 
			if (File.Exists(_filePath))
			{
				try
				{
					string json = File.ReadAllText(_filePath);
					_currentDayJSON = JsonUtility.FromJson<CurrentDayJSON>(json);
				}
				catch (Exception ex)
				{
					Debug.LogError("Failed to load data from file: " + ex.Message);
					throw;
				}
			}
		}

		public int GetCurrentDay()
		{
			return _currentDayJSON.currentDay;
		}
	}
}
