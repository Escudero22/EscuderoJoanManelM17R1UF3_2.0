using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ScriptableAttack", menuName =
    "ScriptableObjects2/ScriptableAction/ScriptableAttack", order = 1)]
public class ScriptableAttack : ScriptableAction
{
    public override void OnFinishedState()
    {
        //GameManager.gm.UpdateText("va te perdono");
    }

    public override void OnSetState(StateController sc)
    {
        base.OnSetState(sc);
        animator = sc.GetComponent<Animator>();
        animator.Play("Attack");
        // GameManager.gm.UpdateText("a q te meto");
    }

    public override void OnUpdate()
    {
        //GameManager.gm.UpdateText("que te meto asin");
    }
}
