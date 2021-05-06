using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Scripting;
using System.Collections.Generic;


public class ShopToggle : MonoBehaviour
{
    [SerializeField] private GameObject ShopMenu;
    [SerializeField] private GameObject InventoryMenu;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject ThirdPersoneMove;

    void Start()
    {
        ShopMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B) & !InventoryMenu.activeInHierarchy)
        {
            if (!ShopMenu.activeInHierarchy)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            ShopMenu.SetActive(!ShopMenu.activeInHierarchy);
            ThirdPersoneMove.GetComponent<CameraFollow>().StopRotating();
            player.GetComponent<PersonMove>().StopAnim();
        }
    }
}
