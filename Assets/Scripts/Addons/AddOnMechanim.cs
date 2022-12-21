using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddOnMechanim : MonoBehaviour
{
    private Animator animator;
    private Transform parentTransform;
    
    // Start is called before the first frame update
    private void Start()
    {
        animator = GetComponent<Animator>();
        parentTransform = transform.parent;
    }

    private void OnAnimatorIK()
    {
        Debug.Log("Called");
        /*animator.SetIKPositionWeight(AvatarIKGoal.LeftHand,1);
        animator.SetIKRotationWeight(AvatarIKGoal.LeftHand,1);  
        animator.SetIKPosition(AvatarIKGoal.LeftHand,parentTransform.position);
        animator.SetIKRotation(AvatarIKGoal.LeftHand,parentTransform.rotation);
        
        animator.SetLookAtWeight(1f);
        animator.SetLookAtPosition(parentTransform.position);*/
    }
}
