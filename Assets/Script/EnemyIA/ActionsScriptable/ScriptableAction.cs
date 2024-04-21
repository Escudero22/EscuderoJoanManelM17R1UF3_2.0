using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ScriptableAction : ScriptableObject
{
    protected StateController sc;
    protected Animator animator;
    public abstract void OnFinishedState();

    public virtual void OnSetState(StateController sc) {
        this.sc = sc;
    }

    public abstract void OnUpdate();
}
