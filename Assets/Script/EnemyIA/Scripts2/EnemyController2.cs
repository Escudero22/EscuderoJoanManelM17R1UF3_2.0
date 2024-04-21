using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController2 : StateController, IDamageable
{
    public float AttackDistance;
    public float HP;
    private float nextHurt = 0;
    public AudioSource audioSource;
    public AudioClip enemyA;
    public AudioClip enemyDeath;

    void Update()
    {
        StateTransition();
        if (currentState.action != null)
        {
            currentState.action.OnUpdate();
            Debug.Log(currentState.action);
        }
        /*if (Input.GetKey("space") && Time.time >= nextHurt)
        {
            OnHurt(10);
            nextHurt = Time.time + 0.3f;
        }*/
    }
    public void PlaySFX(string action)
    {
        switch(action.ToUpper())
        {
            case "DEATH":
                audioSource.PlayOneShot(enemyDeath); break;
            case "A":
                audioSource.PlayOneShot(enemyA); break;
        }
    }
    public void OnHurt(float damage)
    {
        HP -= damage;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            target = collision.gameObject;

        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            target = null;

        }
    }
}
