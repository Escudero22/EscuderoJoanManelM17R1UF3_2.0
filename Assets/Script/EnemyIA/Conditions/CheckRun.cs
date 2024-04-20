using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Run", menuName = "ScriptableNodes/ScriptableConditions/Run")]

public class CheckRun : ScriptableCondition
{
    public override bool Check(StateController sc)
    { 
        var ec = (EnemyController2)sc;
        return ec.HP < 33;
    }
}

