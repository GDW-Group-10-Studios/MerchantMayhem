using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneControl : MonoBehaviour
{
    public GameObject main;
    public GameObject endOfDay;

    public void DayEnd()
    {
        main.SetActive(false);
        endOfDay.SetActive(true);
    }

    public void DayContinue()
    {
        main.SetActive(true);
        endOfDay.SetActive(false);
    }

}
