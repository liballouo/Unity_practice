using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash = Animator.StringToHash("isWalking");
    int isRunningHash = Animator.StringToHash("isRunning");
    int isJumpingHash = Animator.StringToHash("isJumping");
    public GameObject parentGameObject;
    void Start()
    {
        animator = GetComponent<Animator>();
        parentGameObject = gameObject.transform.parent.gameObject;
    }

    void Update()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isRunning = animator.GetBool(isRunningHash);
        bool isJumping = animator.GetBool(isJumpingHash);
        bool forwardPressed = Input.GetKey("w");
        bool runPress = Input.GetKey("z");
        bool jumpPress = Input.GetKey("space");
        PlayerMovement movementSettings = parentGameObject.GetComponent<PlayerMovement>();
        // Start walking
        if(!isWalking && forwardPressed)
        {
            animator.SetBool(isWalkingHash, true);
        }
        // Stop walking
        if(isWalking && !forwardPressed)
        {
            animator.SetBool(isWalkingHash, false);
        }
        // Start running 
        if(!isRunning && (forwardPressed && runPress))
        {
            animator.SetBool(isRunningHash, true);
            movementSettings.moveSpeed += 2;
        }
        // Stop running 
        if(isRunning && (!forwardPressed || !runPress))
        {
            animator.SetBool(isRunningHash, false);
            movementSettings.moveSpeed -= 2;    
        }
        // Start Jumping
        if(!isJumping && jumpPress)
        {
            animator.SetBool(isJumpingHash, true);
        }
        // Stop Jumping
        if(isJumping && !jumpPress)
        {
            animator.SetBool(isJumpingHash, false);
        }
    }
}
