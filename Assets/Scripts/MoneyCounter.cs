using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyCounter : MonoBehaviour
{
    [SerializeField] Text TextMoney;

    static private int moneyCounter;

    static public int getMoneyCounter()
    {
        return moneyCounter;
    }

    static public void setMoneyCounter(int money)
    {
        moneyCounter += money;
        PlayerPrefs.SetInt("Money", moneyCounter);
    }
    
    void Start()
    {   
        moneyCounter = PlayerPrefs.GetInt("Money");
    }
    
    void Update()
    {
        TextMoney.text = moneyCounter.ToString();
    }
}
