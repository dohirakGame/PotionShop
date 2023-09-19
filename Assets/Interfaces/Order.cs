using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Order
{
    public void Check_Score(){
        if(GameObject.Find("Score").GetComponent<Scores>().Score > 0)
        {
            return true;
        }else
        {
            return false;
        }
        
    }
}
