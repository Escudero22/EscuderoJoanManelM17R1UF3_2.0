using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Follow", menuName = "ScriptableNodes/ScriptableConditions/Follow")]
public class CheckFollowDistance : ScriptableCondition
{
 public override bool Check(StateController sc)
    {
        var ec = (EnemyController2)sc;
        try { 
            return (sc.target.transform.position - sc.transform.position).magnitude > ec.AttackDistance -0.1f;
        }
        catch
        {
            return false;
        }
    }
}
