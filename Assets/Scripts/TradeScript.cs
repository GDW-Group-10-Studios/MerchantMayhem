using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class TradeScript : MonoBehaviour
{
    [SerializeField] GameObject Warning;
    [SerializeField] TMP_Text WarningText;

    [SerializeField] GameObject infuText;
    [SerializeField] GameObject cheat;

    [SerializeField] NewDay newDay;

    [SerializeField] TMP_Text[] StockText;

    [SerializeField] GameObject[] Art;

    [SerializeField] Button Op1Button;
    [SerializeField] Button Op2Button;

    [SerializeField] Button NextCustomer;

    [SerializeField] GameObject[] TradesOp1Left;
    [SerializeField] GameObject[] TradesOp2Left;
    [SerializeField] GameObject[] TradesOp1Right;
    [SerializeField] GameObject[] TradesOp2Right;

    [SerializeField] TMP_Text TLNum;
    [SerializeField] TMP_Text TRNum;
    [SerializeField] TMP_Text BLNum;
    [SerializeField] TMP_Text BRNum;

    [SerializeField] TMP_Text Name;

    [SerializeField] GameObject[] selectedTradeTop;
    [SerializeField] GameObject[] selectedTradeBottom;

    [SerializeField] TMP_Text topNum;
    [SerializeField] TMP_Text bottomNum;

    [SerializeField] GameObject tradePanel;

    public static int tradeOp1;
    public static int tradeOp2;

    public static int tradeOp1Scaled;
    public static int tradeOp2Scaled;

    public static int tradeOp1Cost;
    public static int tradeOp2Cost;

    public static int tradeOp1Price;
    public static int tradeOp2Price;

    public static int tradeOp1Item;
    public static int tradeOp2Item;

    public static int selectedOp;
    public static int customer;
    public static int customertype;

    public static int[] Values = new int[15] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};

    private string[] suppliersNames = new string[8] { "Farmer", "Miner", "Butcher", "Baker", "Brewer", "Jeweler", "Tanner", "BlackSmith" };
    private string[] specialNames = new string[] { "Grandma", "Time traveler", "Wizard", "Warrior", "Wanderer", "Assassin", "Rich Guy", "Influencer", "Delinquent", "Robber" };
    private string[] specialText = new string[] { "50% Chance Of Doubling Customers On Next Day", "50% chance Of Being Arrested On Next Day", "Repair Damage Caused"};
    // identifier for non normal trades: 1 regular item trip price. 2 double customers next day. 3 Force Trade. 4 50/50 lose game.
    private int[] special = new int[] { 0,0,0,0,0,4,1,2,3,3};

    private int[] suppliersL1Cost = new int[8] { 1, 1, 1, 1, 1, 4, 3, 4};
    private int[] suppliersL2Cost = new int[8] { 1, 1, 1, 3, 4, 0, 0, 4};
    private int[] suppliersR1Cost = new int[8] { 1, 1, 1, 1, 1, 1, 1, 1};
    private int[] suppliersR2Cost = new int[8] { 1, 1, 1, 1, 1, 0, 0, 1};

    private int[] suppliersL1Item = new int[8] { 12, 12, 12, 8, 8, 10, 9, 11};
    private int[] suppliersL2Item = new int[8] { 12, 12, 12, 8, 12, 10, 9, 11};
    private int[] suppliersR1Item = new int[8] { 4, 6, 1, 0, 3, 12, 10, 14 };
    private int[] suppliersR2Item = new int[8] { 2, 7, 5, 9, 13, 12, 10, 11 };

    private int[] specialL1Cost = new int[] {1, 1, 1, 1, 2, 1, 1, 1, 15, 25};
    private int[] specialL2Cost = new int[] {0, 0, 1, 1, 1, 0, 1, 0, 0, 0};
    private int[] specialR1Cost = new int[] {12, 15, 12, 20, 6, 40, 6, 0, 0, 0};
    private int[] specialR2Cost = new int[] {0, 0, 4, 20, 12, 0, 6, 0, 0, 0};

    private int[] specialL1Item = new int[] {13, 15, 17, 15, 0, 18, 12, 12, 12, 12};
    private int[] specialL2Item = new int[] {13, 15, 10, 18, 14, 18, 12, 12, 12, 12};
    private int[] specialR1Item = new int[10] {8,8,8,8,8,8,8,8,8,8};
    private int[] specialR2Item = new int[10] {8,8,8,8,8,8,8,8,8,8};


    public void initValues()
    {
        for (int i = 0; i < 9; i++)
        {
            if (i < 4)
            {
                Values[i] = Random.Range(4, 9);
            }
            else if (i < 8)
            {
                Values[i] = Random.Range(2, 6);
            }
            else if (i == 8)
            {
                Values[8] = Random.Range(5, 50);
            }
        }

        if (Random.Range(0, 2) == 0)
        {
            Values[Random.Range(9, 15)]++;
        }
        Values[Random.Range(9, 15)]++;

        ValuesRefresh();
        newDay.StartDay();
    }

    public void increase() // TEMP CHEAT CODE
    {
        for (int i = 0; i < Values.Length; i++)
        {
            Values[i] += 1;
        }
        ValuesRefresh();
    }

    public void Cheat()
    {
        cheat.SetActive(true);
    }

    public void ValuesRefresh()
    {
        
        StockText[0].text = Values[0].ToString();
        StockText[1].text = Values[1].ToString();
        StockText[2].text = Values[2].ToString();
        StockText[3].text = Values[3].ToString();
        StockText[4].text = Values[4].ToString();
        StockText[5].text = Values[5].ToString();
        StockText[6].text = Values[6].ToString();
        StockText[7].text = Values[7].ToString();
        StockText[8].text = Values[8].ToString();
        StockText[9].text = Values[9].ToString();
        StockText[10].text = Values[10].ToString();
        StockText[11].text = Values[11].ToString();
        StockText[12].text = Values[12].ToString();
        StockText[13].text = Values[13].ToString();
        StockText[14].text = Values[14].ToString();

    }

    public bool RentCheck()
    {
        if (Values[8] >= 400)
        {
            return true;
        }
        else 
        {
            return false; 
        }
    }

    public void NewSpecial(int specialCustomer)
    {
        foreach (GameObject Icon in Art)
        {
            Icon.SetActive(false);
        }

        Art[specialCustomer + 10].SetActive(true);

        customer = specialCustomer;
        customertype = 1;
  
        if (specialCustomer == 5 ) 
        {
            Warning.SetActive(true);
            WarningText.text = specialText[1];
        }
        else if (specialCustomer == 8)
        {
            Warning.SetActive(true);
            WarningText.text = specialText[2];
        }
        else
        {
            Warning.SetActive(false);
            WarningText.text = "";
        }

        if (special[specialCustomer] == 2)
        {
            Warning.SetActive(true);
            WarningText.text = specialText[0];

            Op1Button.interactable = true;
            Op2Button.interactable = false;


            foreach (GameObject Icon in TradesOp1Left)
            {
                Icon.SetActive(false);
            }
            foreach (GameObject Icon in TradesOp1Right)
            {
                Icon.SetActive(false);
            }
            foreach (GameObject Icon in TradesOp2Left)
            {
                Icon.SetActive(false);
            }
            foreach (GameObject Icon in TradesOp2Right)
            {
                Icon.SetActive(false);
            }
            

            tradeOp1 = Random.Range(13, 19);
            tradeOp2 = tradeOp1;

            tradeOp1Item = specialR1Item[specialCustomer];
            tradeOp1Cost = specialR1Cost[specialCustomer];
            tradeOp2Item = specialR2Item[specialCustomer];
            tradeOp2Cost = specialR2Cost[specialCustomer];

            tradeOp1Price = specialL1Cost[specialCustomer];
            tradeOp2Price = specialL2Cost[specialCustomer];

            TradesOp1Left[tradeOp1].SetActive(true);
            TradesOp1Right[tradeOp1Item].SetActive(true);
            TradesOp2Left[tradeOp2].SetActive(true);
            TradesOp2Right[tradeOp2Item].SetActive(true);

            TLNum.text = tradeOp1Price.ToString();
            TRNum.text = tradeOp1Cost.ToString();

            BLNum.text = tradeOp2Price.ToString();
            BRNum.text = tradeOp2Cost.ToString();

            Name.text = specialNames[specialCustomer];
        }
        else if (special[specialCustomer] == 1)
        {
            Op1Button.interactable = true;
            Op2Button.interactable = true;
            

            foreach (GameObject Icon in TradesOp1Left)
            {
                Icon.SetActive(false);
            }
            foreach (GameObject Icon in TradesOp1Right)
            {
                Icon.SetActive(false);
            }
            foreach (GameObject Icon in TradesOp2Left)
            {
                Icon.SetActive(false);
            }
            foreach (GameObject Icon in TradesOp2Right)
            {
                Icon.SetActive(false);
            }

            tradeOp1 = Random.Range(0, 12);
            tradeOp2 = Random.Range(0, 12);

            tradeOp1Item = specialR1Item[specialCustomer];
            tradeOp1Cost = specialR1Cost[specialCustomer];
            tradeOp2Item = specialR2Item[specialCustomer];
            tradeOp2Cost = specialR2Cost[specialCustomer];

            tradeOp1Price = specialL1Cost[specialCustomer];
            tradeOp2Price = specialL2Cost[specialCustomer];

            TradesOp1Left[tradeOp1].SetActive(true);
            TradesOp1Right[tradeOp1Item].SetActive(true);
            TradesOp2Left[tradeOp2].SetActive(true);
            TradesOp2Right[tradeOp2Item].SetActive(true);

            TLNum.text = tradeOp1Price.ToString();
            TRNum.text = tradeOp1Cost.ToString();

            BLNum.text = tradeOp2Price.ToString();
            BRNum.text = tradeOp2Cost.ToString();

            Name.text = specialNames[specialCustomer];
        }
        else
        {
            if (special[customer] == 3)
            {

                NextCustomer.interactable = false;

            }

            Op1Button.interactable = true;
            if (specialL2Cost[specialCustomer] != 0)
            {
                Op2Button.interactable = true;
            }
            else
            {
                Op2Button.interactable = false;
            }


            foreach (GameObject Icon in TradesOp1Left)
            {
                Icon.SetActive(false);
            }
            foreach (GameObject Icon in TradesOp1Right)
            {
                Icon.SetActive(false);
            }
            foreach (GameObject Icon in TradesOp2Left)
            {
                Icon.SetActive(false);
            }
            foreach (GameObject Icon in TradesOp2Right)
            {
                Icon.SetActive(false);
            }

            tradeOp1 = specialL1Item[specialCustomer];
            tradeOp2 = specialL2Item[specialCustomer];

            tradeOp1Item = specialR1Item[specialCustomer];
            tradeOp1Cost = specialR1Cost[specialCustomer];
            tradeOp2Item = specialR2Item[specialCustomer];
            tradeOp2Cost = specialR2Cost[specialCustomer];

            tradeOp1Price = specialL1Cost[specialCustomer];
            tradeOp2Price = specialL2Cost[specialCustomer];

            TradesOp1Left[tradeOp1].SetActive(true);
            TradesOp1Right[tradeOp1Item].SetActive(true);
            TradesOp2Left[tradeOp2].SetActive(true);
            TradesOp2Right[tradeOp2Item].SetActive(true);

            TLNum.text = tradeOp1Price.ToString();
            TRNum.text = tradeOp1Cost.ToString();

            BLNum.text = tradeOp2Price.ToString();
            BRNum.text = tradeOp2Cost.ToString();

            Name.text = specialNames[specialCustomer];
        }
    }


    public void NewSupplier(int supplier)
    {
        Warning.SetActive(false);
        WarningText.text = "";
        customertype = 2;
        customer = 0;
        Op1Button.interactable = true;
        if (suppliersL2Cost[supplier] != 0)
        {
            Op2Button.interactable = true;
        }
        else 
        { 
            Op2Button.interactable = false; 
        }
        

        foreach (GameObject Icon in TradesOp1Left)
        {
            Icon.SetActive(false);
        }
        foreach (GameObject Icon in TradesOp1Right)
        {
            Icon.SetActive(false);
        }
        foreach (GameObject Icon in TradesOp2Left)
        {
            Icon.SetActive(false);
        }
        foreach (GameObject Icon in TradesOp2Right)
        {
            Icon.SetActive(false);
        }
        foreach (GameObject Icon in Art)
        {
            Icon.SetActive(false);
        }

        Art[supplier + 2].SetActive(true);

        tradeOp1 = suppliersL1Item[supplier];
        tradeOp2 = suppliersL2Item[supplier];

        tradeOp1Item = suppliersR1Item[supplier];
        tradeOp1Cost = suppliersR1Cost[supplier];
        tradeOp2Item = suppliersR2Item[supplier];
        tradeOp2Cost = suppliersR2Cost[supplier];

        tradeOp1Price = suppliersL1Cost[supplier];
        tradeOp2Price = suppliersL2Cost[supplier];

        TradesOp1Left[tradeOp1].SetActive(true);
        TradesOp1Right[tradeOp1Item].SetActive(true);
        TradesOp2Left[tradeOp2].SetActive(true);
        TradesOp2Right[tradeOp2Item].SetActive(true);

        TLNum.text = tradeOp1Price.ToString();
        TRNum.text = tradeOp1Cost.ToString();

        BLNum.text = tradeOp2Price.ToString();
        BRNum.text = tradeOp2Cost.ToString();

        Name.text = suppliersNames[supplier];
    }

    public void RegularTrade()
    {

        Warning.SetActive(false);
        WarningText.text = "";
        customertype = 0;
        customer = 0;
        Op1Button.interactable = true;
        Op2Button.interactable = true;

        foreach (GameObject Icon in TradesOp1Left)
        {
            Icon.SetActive(false);
        }
        foreach (GameObject Icon in TradesOp1Right)
        {
            Icon.SetActive(false);
        }
        foreach (GameObject Icon in TradesOp2Left)
        {
            Icon.SetActive(false);
        }
        foreach (GameObject Icon in TradesOp2Right)
        {
            Icon.SetActive(false);
        }
        foreach (GameObject Icon in Art)
        {
            Icon.SetActive(false);
        }

        Art[Random.Range(0, 2)].SetActive(true);

        tradeOp1 = Random.Range(0, 12);
        tradeOp2 = Random.Range(0, 12);

        tradeOp1Item = 8;
        tradeOp1Cost = 2;
        tradeOp2Item = 8;
        tradeOp2Cost = 2;

        tradeOp1Price = 1;
        tradeOp2Price = 1;

        TradesOp1Left[tradeOp1].SetActive(true);
        TradesOp1Right[tradeOp1Item].SetActive(true);
        TradesOp2Left[tradeOp2].SetActive(true);
        TradesOp2Right[tradeOp2Item].SetActive(true);

        TLNum.text = tradeOp1Price.ToString();
        TRNum.text = tradeOp1Cost.ToString();

        BLNum.text = tradeOp2Price.ToString();
        BRNum.text = tradeOp2Cost.ToString();

        Name.text = "Villager";
    }

    public void SelectTradeOp1()
    {
        selectedOp = 1;
        tradePanel.SetActive(true);
        foreach (GameObject Icon in selectedTradeTop)
        {
            Icon.SetActive(false);
        }
        foreach (GameObject Icon in selectedTradeBottom)
        {
            Icon.SetActive(false);
        }

        tradeOp1Scaled = tradeOp1;

        if (tradeOp1 <= 7)
        {
            if (tradeOp1 % 2 != 0)
            {
                tradeOp1Scaled --;
            }
            tradeOp1Scaled /= 2;
        }
        else
        {
            tradeOp1Scaled -= 4;
        }

        selectedTradeTop[tradeOp1Scaled].SetActive(true);
        selectedTradeBottom[tradeOp1Item].SetActive(true);

        topNum.text = ("-" + tradeOp1Price.ToString());
        bottomNum.text = ("+" + tradeOp1Cost.ToString());
    }

    public void SelectTradeOp2()
    {
        selectedOp = 2;
        tradePanel.SetActive(true);
        foreach (GameObject Icon in selectedTradeTop)
        {
            Icon.SetActive(false);
        }
        foreach (GameObject Icon in selectedTradeBottom)
        {
            Icon.SetActive(false);
        }

        tradeOp2Scaled = tradeOp2;

        if (tradeOp2 <= 7)
        {
            if (tradeOp2 % 2 != 0)
            {
                tradeOp2Scaled --;
            }
            tradeOp2Scaled /= 2;
        }
        else
        {
            tradeOp2Scaled -= 4;
        }

        selectedTradeTop[tradeOp2Scaled].SetActive(true);
        selectedTradeBottom[tradeOp2Item].SetActive(true);

        topNum.text = ("-" + tradeOp2Price.ToString());
        bottomNum.text = ("+" + tradeOp2Cost.ToString());
    }

    public void CompleteTrade()
    {
        if (selectedOp == 1)
        {
            if (Values[tradeOp1Scaled] >= tradeOp1Price || special[customer] == 3)
            {
                if (special[customer] == 3)
                {
                    
                    NextCustomer.interactable = true;
                    
                }
                if (special[customer] == 2)
                {
                    if (Random.Range(0, 2) == 0)
                    {
                        newDay.Infuencer();
                    }
                }
                if (special[customer] == 4)
                {
                    if (Random.Range(0, 2) == 0)
                    {
                        newDay.Assassin();
                    }
                }
                if (customertype != 2)
                {
                    Op1Button.interactable = false;
                }
                Values[tradeOp1Scaled] -= tradeOp1Price;
                Values[tradeOp1Item] += tradeOp1Cost;

                StockText[tradeOp1Scaled].text = Values[tradeOp1Scaled].ToString();
                StockText[tradeOp1Item].text = Values[tradeOp1Item].ToString();

                tradePanel.SetActive(false);
            }
            else
            {
                //Error Prompt in future
            }
        }
        else if (selectedOp == 2)
        {
            if (Values[tradeOp2Scaled] >= tradeOp2Price || special[customer] == 3)
            {
                if (customertype != 2)
                {
                    Op2Button.interactable = false;
                }
                Values[tradeOp2Scaled] -= tradeOp2Price;
                Values[tradeOp2Item] += tradeOp2Cost;

                StockText[tradeOp2Scaled].text = Values[tradeOp2Scaled].ToString();
                StockText[tradeOp2Item].text = Values[tradeOp2Item].ToString();

                tradePanel.SetActive(false);
            }
            else
            {
                //Error Prompt in future
            }
        }
    }

}
