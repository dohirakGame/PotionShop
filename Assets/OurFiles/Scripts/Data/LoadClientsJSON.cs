using System.IO;
using System;
using UnityEngine;
using Data.JSONStruct;
using System.Collections.Generic;
using TMPro;

namespace Data
{
	public class LoadClientsJSON : MonoBehaviour
	{
		[Header("File Name")]
		[SerializeField] private string _fileName = "DayNClients.json";
		[SerializeField] private List<ClientColors> _dayClients;

		public List<ClientColors> Initialize()
		{
			LoadClients();
			return _dayClients;
		}
		private int GetCurrentDay()
		{
			return gameObject.GetComponent<LoadCurrentDayJSON>().GetCurrentDay();
		}
		private void LoadClients()
		{
			string _filePath = Path.Combine(Application.persistentDataPath, _fileName);
			if (File.Exists(_filePath))
			{
				try
				{
					string json = File.ReadAllText(_filePath);
					DayJSON dayJSON = JsonUtility.FromJson<DayJSON>(json);

					ClientsCurrentDay(dayJSON);
				}
				catch (Exception ex)
				{
					Debug.LogError("Failed to load data from file: " + ex.Message);
					throw;
				}
			}
		}

		private void ClientsCurrentDay(DayJSON dayJSON)
		{
			for (int i = 0; i < dayJSON.dayNclients.Count; i++)
			{
				if (dayJSON.dayNclients[i].dayID == GetCurrentDay())
				{
					for (int j = 0; j < dayJSON.dayNclients[i].guests.Count; j++)
					{
						_dayClients.Add(dayJSON.dayNclients[i].guests[j]);
					}
					return;
				}
			}
		}
	}
}