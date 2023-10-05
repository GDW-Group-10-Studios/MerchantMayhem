using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DayScript : MonoBehaviour
{

    [SerializeField]
    private TMP_Text _text;

    public void SetValue(int value)
    {
        _text.text = ("DAY " + value.ToString());
    }


}
