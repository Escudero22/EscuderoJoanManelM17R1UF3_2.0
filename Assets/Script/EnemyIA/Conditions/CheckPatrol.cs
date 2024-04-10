using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Patrol", menuName = "ScriptableNodes/ScriptableConditions/Patrol")]
public class CheckPatrol : ScriptableCondition
{
    public override bool Check(StateController sc)
    {
        return sc.target == null;
    }
}
