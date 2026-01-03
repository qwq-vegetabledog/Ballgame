using UnityEngine;
using System.Collections; 
using System.Collections.Generic;

public class Playercontrols : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] CharacterController controller;
    [SerializeField] Vector3 playerVelocity;
    [SerializeField] bool groundedPlayer;
    [SerializeField] float playerSpeed;
    [SerializeField] float gravityValue;
    [SerializeField] GameObject activeChar;
    [SerializeField] float moveVertical;
    [SerializeField] float speed;
    [SerializeField] float rotateSpeed = 100;
    [SerializeField] float jumpHeight = 1.2f;
    [SerializeField] bool isJumping;
    void Start()
    {
        speed = 4f;
        playerSpeed = 4;
        gravityValue = -20;
    }

    // Update is called once per frame
    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if(groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
            isJumping = false;
        }
        
        transform.Rotate(0, Input.GetAxis("Horizontal")* rotateSpeed*Time.deltaTime, 0);

        Vector3 moveDirection = transform.forward* Input.GetAxis("Vertical")*speed;
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            isJumping = true;
            activeChar.GetComponent<Animator>().Play("Jump");
            playerVelocity.y += 10;
            StartCoroutine(ResetJump());
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move((moveDirection + new Vector3(0, playerVelocity.y, 0))* Time.deltaTime);

        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
           controller.minMoveDistance = 0.001f;
           if(isJumping == false)
           {
               activeChar.GetComponent<Animator>().Play("Standard Run");
           }
        }

        else
        {
            controller.minMoveDistance = 0.0901f;
            if(isJumping == false)
            {
                activeChar.GetComponent<Animator>().Play("Idle");
            }
        }
    }

    IEnumerator ResetJump()
    {
        yield return new WaitForSeconds(0.9f);
        isJumping = false;
    }
}
