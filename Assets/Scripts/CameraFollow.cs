using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;

    [SerializeField] private GameObject InventoryMenu;
    [SerializeField] private GameObject shopMenu;
    [SerializeField] private GameObject player;

    private bool flag = true;

    float rotation;
    
    private void Rotating()
    {
        transform.position = target.transform.position;
        rotation += Input.GetAxis("Mouse X") * 6.0f;
        transform.rotation = Quaternion.Euler(0, rotation, 0);
    }

    public void StopRotating()
    {
        flag = !flag;
    }
    
    void Update()
    {
        if (flag)
        {
            Rotating();
        }
        
        if (Input.GetKeyDown("escape"))
        {
            if (InventoryMenu.activeInHierarchy || shopMenu.activeInHierarchy)
            {
                Cursor.lockState = CursorLockMode.Locked;
                InventoryMenu.SetActive(false);
                shopMenu.SetActive(false);
                enabled = true;
                player.GetComponent<PersonMove>().StopAnim();
                flag = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                SceneManager.LoadScene("Menu");
            }
        }
    }
}
