using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuySkills : MonoBehaviour
{
    // Start is called before the first frame update
    public void BuyJump()
    {
        if (PlayerPrefs.GetInt("Money") >= 200)
        {
            PlayerPrefs.SetFloat("Jump", PlayerPrefs.GetFloat("Jump") * 2.0f); ;
            MoneyCounter.setMoneyCounter(-200);
        }
    }

    public void BuySpeed()
    {
        if (PlayerPrefs.GetInt("Money") >= 100)
        {
            PlayerPrefs.SetFloat("Speed", PlayerPrefs.GetFloat("Speed") * 2.0f); ;
            MoneyCounter.setMoneyCounter(-100);
        }
    }
}
