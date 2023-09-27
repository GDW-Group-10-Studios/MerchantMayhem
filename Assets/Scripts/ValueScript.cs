using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ValueScript : MonoBehaviour
{

    [SerializeField]
    private TMP_Text _text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetValue(/*int value*/)  //TEMP
    {
        int value = Random.Range(0, 99); //TEMP
        _text.text = value.ToString();
    }


}
