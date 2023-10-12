using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TradeControl: MonoBehaviour
{
    [SerializeField] TMP_Text customersText;
    [SerializeField] TradeScript tradeScript;
    [SerializeField] Button nextCustomerButton;
    [SerializeField] GameObject nextDayButton;

    [SerializeField] GameObject tradePanel;
    [SerializeField] NewDay newDay;

    private int customers;

    public void NewCustomer()
    {
        customers = newDay.GetCustomers();

        if (customers > 0)
        {
            nextCustomerButton.interactable = true;
            nextDayButton.SetActive(false);

            customersText.text = customers.ToString();

            tradePanel.SetActive(false);

            tradeScript.RegularTrade();
        }
        else if (customers <= 0)
        {
            nextDayButton.SetActive(true);
            nextCustomerButton.interactable = false;

            customersText.text = customers.ToString();

            tradePanel.SetActive(false);

            tradeScript.RegularTrade();
        }
    }

    public void Trade()
    {

    }




}
