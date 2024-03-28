using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    Animator animator;
    PlayerMovement inputManager;
    PlLocomotion plLocomotion;

    public bool isInteract;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        inputManager = GetComponent<PlayerMovement>();
        plLocomotion = GetComponent<PlLocomotion>();
    }
    private void Update()
    {
        inputManager.HandleAllInputs();
    }
    private void FixedUpdate()
    {
        plLocomotion.AllMovement();
    }
    private void LateUpdate()
    {
        isInteract = animator.GetBool("isInteracting");
        plLocomotion.isJumping = animator.GetBool("IsJumping");
        animator.SetBool("IsGrounded",plLocomotion.isGrounded);
    }
}
