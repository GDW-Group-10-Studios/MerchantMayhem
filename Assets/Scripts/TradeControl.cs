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
    private int suppliers;
    private int lastSupplier = -1;




    public void NewCustomer()
    {
        suppliers = newDay.GetSuppliers();
        if (suppliers >= 0)
        {
            tradePanel.SetActive(false);
            nextCustomerButton.interactable = true;
            nextDayButton.SetActive(false);
            if (lastSupplier < 7)
            {
                lastSupplier++;
                tradeScript.NewSupplier(lastSupplier);
            }
            else
            {
                lastSupplier = 0;
                tradeScript.NewSupplier(lastSupplier);
            }
            customersText.text = suppliers.ToString();
        }
        else
        { 
            customers = newDay.GetCustomers();
            if (customers > 0)
            {

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
    }

    public void Trade()
    {

    }




}
