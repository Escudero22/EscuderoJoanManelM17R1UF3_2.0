using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController2 : StateController
{
    public float AttackDistance;
    public float HP;
    private float nextHurt = 0;

    void Update()
    {
        StateTransition();
        if (currentState.action != null)
        {
            currentState.action.OnUpdate();
            Debug.Log(currentState.action);
        }
        if (Input.GetKey("space") && Time.time >= nextHurt)
        {
            OnHurt(1);
            nextHurt = Time.time + 0.3f;
        }
    }

    public void OnHurt(float damage)
    {
        HP -= damage;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag
            ("Player"))
        {
            target = collision.gameObject;

        }
    }
    private void OnTriggerExit(Collider collision)
    {
        target = null;
    }
}
