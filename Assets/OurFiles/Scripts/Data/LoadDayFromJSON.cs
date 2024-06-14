using Data.JSONStruct;
using UnityEngine;
using System;
using System.IO;

namespace Data
{
	public class LoadDayFromJSON : MonoBehaviour
	{
		[Header("File Name")]
		[SerializeField] private string _fileName = "CurrentDay.json";
		[SerializeField] private CurrentDayJSON _currentDayJSON;

		[SerializeField] private string _loadCurrentDayPath;
		//[SerializeField] private string _loadClientsPath;

		private string _filePath;

		private void Start()
		{
			TestLoad();
		}
		private void TestLoad()
		{
			_filePath = Path.Combine(Application.persistentDataPath, _fileName);
			 
			if (File.Exists(_filePath))
			{
				try
				{

				}
				catch (Exception ex)
				{
					Debug.LogError("Failed to load data from file: " + ex.Message);
					throw;
				}
			}
		}
	}
}
