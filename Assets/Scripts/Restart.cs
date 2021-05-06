using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void RestartGame()
    {
        PlayerPrefs.DeleteKey("Money");
        PlayerPrefs.DeleteKey("PosX");
        PlayerPrefs.DeleteKey("Speed");
        PlayerPrefs.DeleteKey("Jump");
        SceneManager.LoadScene("MainGame");
    }

    private void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(RestartGame);
    }
}
