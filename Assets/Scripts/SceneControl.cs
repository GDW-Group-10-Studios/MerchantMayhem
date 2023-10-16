using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneControl : MonoBehaviour
{
    [SerializeField] TradeScript tradeScript;
    public GameObject main;
    public GameObject rules;
    public GameObject credits;
    public GameObject mainMenu;
    public GameObject endOfDay;
    public GameObject endScreen;


    public void Rules()
    {
        mainMenu.SetActive(false);
        rules.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Credits()
    {
        mainMenu.SetActive(false);
        credits.SetActive(true);
    }
    public void menu()
    {
        rules.SetActive(false);
        main.SetActive(false);
        endOfDay.SetActive(false);
        endScreen.SetActive(false);
        mainMenu.SetActive(true);
        credits.SetActive(false);
    }
    public void End()
    {
        endOfDay.SetActive(false);
        endScreen.SetActive(true);
    }
    public void Start()
    {
        main.SetActive(false);
        mainMenu.SetActive(true);
        endScreen.SetActive(false);
        endOfDay.SetActive(false);
    }

    public void DayEnd()
    {
        mainMenu.SetActive(false);
        main.SetActive(false);
        endOfDay.SetActive(true);
    }

    public void DayContinue()
    {
        main.SetActive(true);
        endOfDay.SetActive(false);
    }
    public void DayStart()
    {
        mainMenu.SetActive(false);
        main.SetActive(false);
        endOfDay.SetActive(true);
        tradeScript.initValues();
    }

}
