using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryToggle : MonoBehaviour
{
    [SerializeField] private GameObject InventoryMenu;
    [SerializeField] private GameObject ShopMenu;

    private Canvas canvas;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject ThirdPersoneMove;

    void Start()
    {
        InventoryMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) & !ShopMenu.activeInHierarchy)
        {
            if (!InventoryMenu.activeInHierarchy)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            InventoryMenu.SetActive(!InventoryMenu.activeInHierarchy);
            ThirdPersoneMove.GetComponent<CameraFollow>().StopRotating();
            player.GetComponent<PersonMove>().StopAnim();
        }
    }
}
