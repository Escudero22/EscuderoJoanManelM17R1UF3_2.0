using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour, IDamageable
{
    Animator animator;
    PlayerMovement inputManager;
    PlLocomotion plLocomotion;
    public GameObject Enemy;
    public float maxHP;
    public float HP;
    public Image life;

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
        life.fillAmount = HP / maxHP;
        if (HP < 0)
        {
            SceneManager.LoadScene(1);
        }
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
        animator.SetBool("IsAttack",inputManager.a_input);
        animator.SetBool("IsBlock",inputManager.block_input);
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("enemy"))
        {
            Enemy = other.gameObject;

        }
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag("enemy"))
        {
            Enemy = other.gameObject;

        }
    }

    public void OnHurt(float damage)
    {
        HP-= damage;
    }
}
