using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlLocomotion : MonoBehaviour
{
    PlayerMovement inputManager;
    Vector3 moveDir;
    Transform cameraObject;
    Rigidbody plRigidBody;

    public float speed = 8;
    public float rotationSpeed = 10;
    private void Awake()
    {
        inputManager = GetComponent<PlayerMovement>();
        plRigidBody = GetComponent<Rigidbody>();
        cameraObject = Camera.main.transform;
    }

    public void AllMovement()
    {
        Movement();
        Rotation();
    }
    private void Movement()
    {
        moveDir = cameraObject.forward * inputManager.verticalI;
        moveDir = moveDir + cameraObject.right * inputManager.horizontalI;
        moveDir.Normalize();
        moveDir.y = 0;
        moveDir = moveDir * speed;

        Vector3 moveVelocity = moveDir;
        plRigidBody.velocity = moveVelocity;
    }

    private void Rotation()
    {
        Vector3 targetDir = Vector3.zero;

        targetDir = cameraObject.forward * inputManager.verticalI;
        targetDir = targetDir + cameraObject.right * inputManager.horizontalI;
        targetDir.Normalize();
        targetDir.y = 0;

        if(targetDir == Vector3.zero)
            targetDir = transform.forward;

        Quaternion targetRotation = Quaternion.LookRotation(targetDir);
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        transform.rotation = playerRotation;
    }
}
