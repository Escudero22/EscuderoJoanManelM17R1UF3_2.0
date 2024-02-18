using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public PlayerInput _pl;
    private Animator _animator;

    // Awake is called before Start
    void Awake()
    {
        _pl = GetComponent<PlayerInput>();
        _animator = GetComponent<Animator>();

        if (_animator == null)
        {
            Debug.LogError("Animator component not found on the GameObject.");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _pl.actions["Dance"].performed += ctx => Dance();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = _pl.actions["Move"].ReadValue<Vector2>();
        // Add your movement logic here
    }

    void Dance()
    {
        if (_animator != null)
        {
            _animator.SetTrigger("dance");
        }
    }
}
