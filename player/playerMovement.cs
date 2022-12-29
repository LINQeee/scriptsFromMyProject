using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(CharacterController))]

public class playerMovement : MonoBehaviour
{
    public static bool isMovementBlocked = false;
    [SerializeField] private float speed = 3;
    [SerializeField] GameObject player;
    private Animator animator;
    private Vector3 moveDefaultValue;
    private Vector3 move;
    private bool isShifting = false;


    private CharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {   
        if (isMovementBlocked) return;
        Vector3 currentPos = transform.position;
        //tracking shift input
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isShifting = true;
            speed = 6;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isShifting = false;
            speed = 3;
        }

        //moving player 
        moveDefaultValue = new Vector3(0, -speed, 0);
        float posX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        float posZ = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        move = new Vector3(posX, -speed, posZ);

        move = Vector3.ClampMagnitude(move, speed);

        move = transform.TransformDirection(move);

        characterController.Move(move);

        

        if (move != moveDefaultValue && currentPos != transform.position)
        {//if player didn't move
            if (isShifting)
            {//make animations faster if player is running
                animator.SetFloat("animSpeed", 1.3f);
            }
            else animator.SetFloat("animSpeed", 1f);
        }

    }
}
