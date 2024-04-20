using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableDie", menuName = "ScriptableObjects2/ScriptableAction/ScriptableDie", order = 2)]
public class ScriptableDie : ScriptableAction
{
    public float shrinkSpeed = 0.5f; // Velocidad a la que el enemigo se encoge
    private Animator animator;
    public Transform enemy;

    public override void OnFinishedState()
    {
        //GameManager.gm.UpdateText("me mori");
    }

    public override void OnSetState(StateController sc)
    {
        base.OnSetState(sc);
        animator = sc.GetComponent<Animator>();
        enemy = sc.transform;
        animator.Play("Die");
        //GameManager.gm.UpdateText("me estoy muriendo");
    }

    public override void OnUpdate()
    {
        //GameManager.gm.UpdateText("toma mis monedas");
        ShrinkEnemy(enemy);

    }

    // Método para reducir gradualmente la escala del enemigo
    private void ShrinkEnemy(Transform enemyTransform)
    {
        enemyTransform.localScale -= Vector3.one * shrinkSpeed * Time.deltaTime;

        // Si la escala es menor o igual a cero, destruir el objeto
        if (enemyTransform.localScale.x <= 0)
        {
            Destroy(enemyTransform.gameObject);
        }
    }

}
