using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "ScriptablePatrol", menuName = "ScriptableObjects2/ScriptableAction/ScriptablePatrol", order = 4)]
public class ScriptablePatrol : ScriptableAction
{
    public float patrolRadius = 10f; // Radio de patrulla

    private NavMeshAgent agent;
    private Vector3 currentDestination;
    private bool isPatrolling = false;
    private ChaseBehaviour _chaseBehaviour;
    private EnemyController2 _enemyController;

    public override void OnFinishedState()
    {
        // Detener la patrulla si el estado ha terminado
        StopPatrolling();
        _chaseBehaviour.StopChasing();

    }

    public override void OnSetState(StateController sc)
    {
        base.OnSetState(sc);
        _chaseBehaviour = sc.GetComponent<ChaseBehaviour>();
        _enemyController = (EnemyController2)sc;
        // Iniciar la patrulla cuando se establezca el estado
        agent = sc.GetComponent<NavMeshAgent>();
        SetRandomDestination(); // Establecer el primer destino aleatorio
        isPatrolling = true;
        animator = sc.GetComponent<Animator>();
        animator.Play("Walk");
    }

    public override void OnUpdate()
    {
        // Si está patrullando, asegúrate de que el agente se esté moviendo hacia el destino
        if (isPatrolling && agent != null && !agent.pathPending && agent.remainingDistance < 0.1f)
        {
            SetRandomDestination(); // Establecer un nuevo destino aleatorio cuando el agente llegue al destino actual
        }
    }

    // Función para iniciar la patrulla
  

    // Función para detener la patrulla
    private void StopPatrolling()
    {
        agent = null;
        isPatrolling = false;
    }

    // Función para establecer un destino aleatorio dentro del rango de patrulla
    private void SetRandomDestination()
    {
        // Generar un punto aleatorio dentro de un radio alrededor del agente
        Vector3 randomDirection = Random.insideUnitSphere * patrolRadius;
        randomDirection += agent.transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, patrolRadius, 1);
        currentDestination = hit.position;

        // Establecer el destino para el agente
        agent.SetDestination(currentDestination);
    }

}
