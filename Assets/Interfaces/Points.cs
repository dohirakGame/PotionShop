using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Points
{
    int Points {get; set;}
    
    public void Modify(int value)
    {
        Points+= value;
    }

    public void SendScore()
    {
        GameObject.Find("Score").GetComponent<Scores>().Modify(Points);
    }
}
