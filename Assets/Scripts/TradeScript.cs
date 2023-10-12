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

    [SerializeField] GameObject[] regularTradesOp1Left;
    [SerializeField] GameObject[] regularTradesOp2Left;
    [SerializeField] GameObject[] regularTradesOp1Right;
    [SerializeField] GameObject[] regularTradesOp2Right;

    [SerializeField] TMP_Text TLNum;
    [SerializeField] TMP_Text TRNum;
    [SerializeField] TMP_Text BLNum;
    [SerializeField] TMP_Text BRNum;

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

    public static int[] Values = new int[] {5,5,5,5,5,5,5,5,25};

    public void ValuesInit()
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

    }
    public void RegularTrade()
    {

        Op1Button.interactable = true;
        Op2Button.interactable = true;

        foreach (GameObject Icon in regularTradesOp1Left)
        {
            Icon.SetActive(false);
        }
        foreach (GameObject Icon in regularTradesOp1Right)
        {
            Icon.SetActive(false);
        }
        foreach (GameObject Icon in regularTradesOp2Left)
        {
            Icon.SetActive(false);
        }
        foreach (GameObject Icon in regularTradesOp2Right)
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

        regularTradesOp1Left[tradeOp1].SetActive(true);
        regularTradesOp1Right[0].SetActive(true);
        regularTradesOp2Left[tradeOp2].SetActive(true);
        regularTradesOp2Right[0].SetActive(true);

        TLNum.text = tradeOp1Price.ToString();
        TRNum.text = tradeOp1Cost.ToString();

        BLNum.text = tradeOp2Price.ToString();
        BRNum.text = tradeOp2Cost.ToString();

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
            Debug.Log("OP 1  " + tradeOp2Scaled.ToString());
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
            Debug.Log("OP 2  " + tradeOp1Scaled.ToString());
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
