using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quit : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }

    private void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(QuitGame);
    }
}
