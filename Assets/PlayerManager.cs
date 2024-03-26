using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    PlayerMovement inputManager;
    PlLocomotion plLocomotion;

    private void Awake()
    {
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
}
