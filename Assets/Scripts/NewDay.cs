using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewDay : MonoBehaviour
{
    public GameObject DayText;

    public int day = 0;
    public float customers = 0f;
    public bool raining = false;
    public void StartDay()
    {
        // Check if end of month
        if (day >= 30)
        {
            // Call Game End Func In Future
        }
        else
        {
            // increase day and get amount of customers
            day ++;
            
            customers = Random.Range(3f, 6f);
            
            // Check for rain if yes divide customers by 2 if odd add 0.5
            if (raining)
            {
                if (customers%2 == 0)
                {
                    customers = customers/2;
                }
                else
                {
                    customers = customers / 2 + 0.5f;
                }

                // Call func to display rain card
                Debug.Log("Rain");
                raining = RainCheck();
            }
            else
            {


                // Call event Func here

                // Display sun if no rain or clould if rain next day
                raining = RainCheck();
                if (raining)
                {
                    Debug.Log("Cloud");
                    // Call func to display cloud card
                }
                else
                {
                    Debug.Log("Sun");
                    // Call func to display sun card
                }
            }

        }

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
