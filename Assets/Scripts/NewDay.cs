using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewDay : MonoBehaviour
{
    public int Day = 1;
    public void StartDay()
    {

    }

    private bool RainCheck()
        // returns bool value with 25% chance of being true for the rain system
    {
        int RandNum = Random.Range(1, 4);
        if (RandNum == 1 ) 
        {
            return true;
        }
        else 
        { 
            return false; 
        }
    }

}
