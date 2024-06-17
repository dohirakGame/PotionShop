using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Collection.Client;
using Collection.Potion;
using Collection.Element;

public class CollectionTypeChoiceScript : MonoBehaviour
{
    public GameObject collectionGrid;

    public GameObject JSONController;

    public void choosePotions()
    {
        CollectionElementScript[] gridCells = collectionGrid.GetComponent<Transform>().GetComponentsInChildren<CollectionElementScript>();
        GAL_Potions potions = JSONController.GetComponent<GAL_PotionsJSON>().LoadGAL_Potions();
        foreach(CollectionElementScript child in gridCells)
        {
            child.potion = null;
            child.client = null;
            
            //child.gameObject.GetComponent<Transform>().GetComponentsInChildren<TMP_Text>()[0].text = null;
        }
        for(int i = 0;i<potions.potions.Length;i++)
        {
            gridCells[i].potion = potions.potions[i];

        }
    }

    public void chooseClients()
    {
        CollectionElementScript[] gridCells = collectionGrid.GetComponent<Transform>().GetComponentsInChildren<CollectionElementScript>();
        GAL_Clients clients = JSONController.GetComponent<GAL_ClientsJSON>().LoadGAL_Clients();
        foreach(CollectionElementScript child in gridCells)
        {
            child.potion = null;
            child.client = null;
            child.gameObject.GetComponent<Transform>().GetComponentsInChildren<TMP_Text>()[0].text = null;
        }
        for(int i = 0;i<clients.clients.Length;i++)
        {
            gridCells[i].client = clients.clients[i];
        }
    }
}
