using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
[CreateAssetMenu(fileName = "ScriptableFollow", menuName = "ScriptableObjects2/ScriptableAction/ScriptableFollow")]

public class ScriptableFollow : ScriptableAction
{
    private ChaseBehaviour _chaseBehaviour;
    private EnemyController2 _enemyController;
    private NavMeshAgent agent;

    public override void OnFinishedState()
    {
        _chaseBehaviour.StopChasing();
    }

    public override void OnSetState(StateController sc)
    {
        base.OnSetState(sc);
        //GameManager.gm.UpdateText("Te persigo");
        _chaseBehaviour = sc.GetComponent<ChaseBehaviour>();
        _enemyController = (EnemyController2)sc;
        animator = sc.GetComponent<Animator>();
        animator.Play("Walk");
    }

    public override void OnUpdate()
    {
        //_chaseBehaviour.Chase(_enemyController.target.transform, sc.transform);
        agent = sc.GetComponent<NavMeshAgent>();
        agent.destination = _enemyController.target.transform.position;
    }
}
