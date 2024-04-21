using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ScriptableAttack", menuName =
    "ScriptableObjects2/ScriptableAction/ScriptableAttack", order = 1)]
public class ScriptableAttack : ScriptableAction
{

    private float nextHurt = 0;
    public GameObject player;
    public override void OnFinishedState()
    {
        //GameManager.gm.UpdateText("va te perdono");
        var temp = player.gameObject.GetComponent<PlayerManager>() as IDamageable;
        if (temp != null && Time.time >= nextHurt)
        {
            temp.OnHurt(5);
            nextHurt = Time.time + 0.3f;
        }
    }

    public override void OnSetState(StateController sc)
    {
        base.OnSetState(sc);
        animator = sc.GetComponent<Animator>();
        animator.Play("Attack");


        player = GameObject.Find("Player");
        
        // GameManager.gm.UpdateText("a q te meto");
    }

    public override void OnUpdate()
    {
        //GameManager.gm.UpdateText("que te meto asin");
    }
}
