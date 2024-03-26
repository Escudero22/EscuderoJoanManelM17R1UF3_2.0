using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimarionManager : MonoBehaviour
{
    Animator animator;
    int horizontal;
    int vertical;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        horizontal = Animator.StringToHash("Horizontal");
        vertical = Animator.StringToHash("Vertical");
    }
    public void UpdateAnimatorValues(float horizontalM, float verticalM)
    {
        float snappedHorizontal;
        float snappedVertical;

        #region Snapped Horizontal
        if (horizontalM > 0 && horizontalM < 0.55f)
        {
            snappedHorizontal = 0.5f;
        }
        else if (horizontalM > 0.55f)
        {
            snappedHorizontal = 1;

        }
        else if (horizontalM < 0 && horizontalM > -0.55f)
        {
            snappedHorizontal = -0.5f;
        }
        else if (horizontalM < -0.55f)
        {
            snappedHorizontal = -1;
        }
        else
        {
            snappedHorizontal = 0;
        }
        #endregion
        #region Snapped Vertical
        if (verticalM > 0 && verticalM < 0.55f)
        {
            snappedVertical = 0.5f;
        }
        else if (verticalM > 0.55f)
        {
            snappedVertical = 1;

        }
        else if (verticalM < 0 && verticalM > -0.55f)
        {
            snappedVertical = -0.5f;
        }
        else if (verticalM < -0.55f)
        {
            snappedVertical = -1;
        }
        else
        {
            snappedVertical = 0;
        }

        #endregion


        animator.SetFloat(horizontal, horizontalM, 0.1f, Time.deltaTime);
        animator.SetFloat(vertical, verticalM, 0.1f, Time.deltaTime);
    }
}
