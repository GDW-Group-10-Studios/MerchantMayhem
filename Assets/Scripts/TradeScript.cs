using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TradeScript : MonoBehaviour
{
    [SerializeField] TMP_Text[] StockText;

    [SerializeField] Button Op1Button;
    [SerializeField] Button Op2Button;

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

    public static int[] Values = new int[15] {5,5,5,5,5,5,5,5,25,0,0,0,0,0,0};

    private string[] suppliersNames = new string[8] { "Farmer", "Miner", "Butcher", "Baker", "Brewer", "Jeweler", "Tanner", "BlackSmith" };
    private int[] suppliersL1Cost = new int[8] { 1, 1, 1, 1, 1, 4, 3, 4};
    private int[] suppliersL2Cost = new int[8] { 1, 1, 1, 3, 4, 0, 0, 4};
    private int[] suppliersR1Cost = new int[8] { 1, 1, 1, 1, 1, 1, 1, 1};
    private int[] suppliersR2Cost = new int[8] { 1, 1, 1, 1, 1, 0, 0, 1};

    private int[] suppliersL1Item = new int[8] { 12, 12, 12, 8, 8, 10, 9, 11};
    private int[] suppliersL2Item = new int[8] { 12, 12, 12, 8, 12, 10, 9, 11};
    private int[] suppliersR1Item = new int[8] { 4, 6, 1, 0, 3, 12, 10, 14 };
    private int[] suppliersR2Item = new int[8] { 2, 7, 5, 9, 13, 12, 10, 11 };

    public void increase() // TEMP CHEAT CODE
    {
        for (int i = 0; i < Values.Length; i++)
        {
            Values[i] += 1;
        }
        ValuesRefresh();
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


    public void NewSupplier(int supplier)
    {
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
            if (Values[tradeOp1Scaled] >= tradeOp1Price)
            {
                Op1Button.interactable = false;
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
            if (Values[tradeOp2Scaled] >= tradeOp2Price)
            {
                Op2Button.interactable = false;
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
