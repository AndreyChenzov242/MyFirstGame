using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PersonMove : MonoBehaviour
{

    [SerializeField] private AudioClip jumpSound;

    private float speed = 4.0f;
    private float sprintSpeed = 2.0f;
    private float jumpSpeed = 5.0f;
    private float gravity = 20.0f;
    private float rotateSpeed = 3f;
    private float rotation;
    private Vector3 moveDirection = Vector3.zero;
    private bool flg = true;
    private Animator anim;
    private CharacterController controller;
    private Vector3 warpToPosition = Vector3.zero;


  
    void Start()
    {
        if (!PlayerPrefs.HasKey("Speed"))
            PlayerPrefs.SetFloat("Speed", 4.0f);

        if (!PlayerPrefs.HasKey("Jump"))
            PlayerPrefs.SetFloat("Jump", 5.0f);

        if (PlayerPrefs.HasKey("PosX"))
            warpToPosition = new Vector3(PlayerPrefs.GetFloat("PosX"), PlayerPrefs.GetFloat("PosY"), PlayerPrefs.GetFloat("PosZ"));

        Cursor.lockState = CursorLockMode.Locked;

        anim = GetComponent<Animator>();

        controller = GetComponent<CharacterController>();

    }

    

    public void StopAnim()
    {
        anim.enabled = !flg;
        flg = !flg;
    }

    void Update()
    {   
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= PlayerPrefs.GetFloat("Speed");

            anim.SetFloat("speed", PlayerPrefs.GetFloat("Speed") / 4f);

            if (Input.GetKey(KeyCode.W))
            {
                anim.SetBool("isWalk", true);
            }
            else
            {
                anim.SetBool("isWalk", false);
            }


            if (Input.GetButton("Jump"))
            {
                GetComponent<AudioSource>().clip = jumpSound;
                GetComponent<AudioSource>().Play();
                anim.SetTrigger("jump");
                moveDirection.y = PlayerPrefs.GetFloat("Jump");
            }
                

            if(Input.GetKey("left shift") & Input.GetKey(KeyCode.W))
            {
                anim.SetBool("isRun", true);
                moveDirection *= sprintSpeed ;
            }
            else
            {
                anim.SetBool("isRun", false);
            }

            if (Input.GetKey(KeyCode.S))
            {
                anim.SetBool("isBackWalk", true);
            }
            else
            {
                anim.SetBool("isBackWalk", false);
            }

            if (GetComponent<CharacterController>().velocity.z == 0.0f && Input.GetKey(KeyCode.D))
            {
                anim.SetBool("isRotateRight", true);
            }
            else
            {
                anim.SetBool("isRotateRight", false);
            }

            if (GetComponent<CharacterController>().velocity.z == 0.0f && Input.GetKey(KeyCode.A))
            {
                anim.SetBool("isRotateLeft", true);
            }
            else
            {
                anim.SetBool("isRotateLeft", false);
            }
        }

        rotation = Input.GetAxis("Horizontal") * rotateSpeed;
        transform.Rotate(new Vector3(0, rotation, 0));

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        PlayerPrefs.SetFloat("PosX", controller.gameObject.transform.position.x);
        PlayerPrefs.SetFloat("PosY", controller.gameObject.transform.position.y);
        PlayerPrefs.SetFloat("PosZ", controller.gameObject.transform.position.z);

        

        if (warpToPosition != Vector3.zero)
        {
            controller.transform.position = warpToPosition;
            warpToPosition = Vector3.zero;
        }
    }
    
}
