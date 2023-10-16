using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.Examples;
using UnityEngine;

public class NewDay : MonoBehaviour
{
    [SerializeField] GameObject win;
    [SerializeField] GameObject loseRent;
    [SerializeField] GameObject LoseAssassin;


    [SerializeField] SceneControl sceneControl;
    [SerializeField] TradeScript tradeScript;
    [SerializeField] TradeControl tradeControl;


    [SerializeField] TMP_Text dayText;
    [SerializeField] TMP_Text dayTextMain;

    [SerializeField] TMP_Text customersText;
    [SerializeField] TMP_Text suppliersText;

    [SerializeField] GameObject CloudCardObj;
    [SerializeField] GameObject SunCardObj;
    [SerializeField] GameObject RainCardObj;

    [SerializeField] GameObject CaravanCardObj;
    [SerializeField] GameObject NoEventCardObj;
    [SerializeField] GameObject EventCardFlipedObj;

    public static bool extraCustomers = false;
    public static bool gameOver = false;
    public static int day = 0;
    public static int customers = 0;
    public static int suppliers = 0;
    public static bool raining = false;
    public static int lastEvent = 0;

    private void Start()
    {
        tradeScript.ValuesRefresh();
        StartDay();
    }

    public int GetSuppliers()
    {
        suppliers--;
        return suppliers;
    }

    public void GameWin()
    {
        win.SetActive(true);
        loseRent.SetActive(false);
        LoseAssassin.SetActive(false);
    }
    public void GameLose(int reason)
    {
        if (reason == 0)
        {
            win.SetActive(false);
            loseRent.SetActive(true);
            LoseAssassin.SetActive(false);
        }
        else if (reason == 1)
        {
            win.SetActive(false);
            LoseAssassin.SetActive(true);
        }
    }

    public void StartDay()
    {
        // Check if end of month
        if (day >= 30 || gameOver)
        {
            sceneControl.End();
            if (gameOver)
            {
                GameLose(1);
            }
            if (tradeScript.RentCheck())
            {
                GameWin();
            }
            else
            {
                GameLose(0);
            }
        }
        else
        {
            // increase day and get amount of customers
            day ++;
            dayText.text = ("Day "+ day.ToString());
            dayTextMain.text = ("Day " + day.ToString());

            customers = Random.Range(3, 7);
            
            // Check for rain if yes divide customers by 2 if odd add 0.5
            if (raining)
            {
                if (customers%2 != 0)
                {
                    customers++;
                }
                customers /= 2;
                

                RainCard();
                BlankEventCard();
                raining = RainCheck();
            }
            else
            {
                // if not raining

                // Check for caravan
                if (EventCheck() && lastEvent >= 3)
                {
                    lastEvent = 0;
                    customers = customers * 2;
                    CaravanCard();
                }
                else
                {
                    lastEvent++;
                    NoEventCard();
                }


                // Display sun if no rain or clould if rain next day
                raining = RainCheck();
                if (raining)
                {
                    CloudCard();
                }
                else
                {
                    SunCard();
                }
            }


            if (extraCustomers)
            {
                customers *= 2;
                extraCustomers = false;
            }
            customersText.text = customers.ToString();
            // Suppliers 2-4 per day

            suppliers = Random.Range(2,5);
            suppliersText.text = suppliers.ToString();
            tradeControl.NewCustomer();
            

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

    private bool EventCheck()
    // returns bool value with 25% chance of being true for the rain system
    {
        int RandNum = Random.Range(1, 5);
        if (RandNum == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Infuencer()
    {
        extraCustomers = true;
    }

    public void Assassin()
    {
        gameOver = true;
    }

    // Weather Card Functions
    private void SunCard()
    {
        SunCardObj.SetActive(true);
        CloudCardObj.SetActive(false);
        RainCardObj.SetActive(false);

    }
    private void RainCard()
    {
        SunCardObj.SetActive(false);
        CloudCardObj.SetActive(false);
        RainCardObj.SetActive(true);
    }
    private void CloudCard()
    {
        SunCardObj.SetActive(false);
        CloudCardObj.SetActive(true);
        RainCardObj.SetActive(false);
    }

    // Event Card Functions
    private void CaravanCard()
    {
        CaravanCardObj.SetActive(true);
        NoEventCardObj.SetActive(false);
        EventCardFlipedObj.SetActive(false);
    }

    private void NoEventCard()
    {
        CaravanCardObj.SetActive(false);
        NoEventCardObj.SetActive(true);
        EventCardFlipedObj.SetActive(false);
    }
    private void BlankEventCard()
    {
        CaravanCardObj.SetActive(false);
        NoEventCardObj.SetActive(false);
        EventCardFlipedObj.SetActive(true);
    }


    public int GetCustomers()
    {
        customers--;
        return customers;
    }

}
