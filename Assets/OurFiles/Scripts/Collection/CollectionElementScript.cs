using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Collection.Client;
using Collection.Potion;

namespace Collection.Element
{
    public class CollectionElementScript : MonoBehaviour
    {
        public GAL_Potion potion;

        public Gal_Client client;

        public TMP_Text descriptionText;

        public void GAL_Choose()
        {
            if (potion != null)
            {
                descriptionText.text = potion.description;
            }
            else if (client != null)
            {
                descriptionText.text = client.description;
            }
        }
    }
}