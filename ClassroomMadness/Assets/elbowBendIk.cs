using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elbowBendIk : MonoBehaviour
{
    Animator anim;

    public float ikWeight = 1;

    [Header("hands")]
    public Transform IKTargetRHand;
    public Transform IKTargetLhand;

    [Header("body")]
    public float lookIKweight;
    public float bodyWeight;

    public float clampweight;

    public Transform lookPos;

    // Use this for initialization
    void Start()
    {

        anim = GetComponent<Animator>();

    }


    void OnAnimatorIK()
    {
        anim.SetLookAtWeight(lookIKweight, bodyWeight, clampweight);
        anim.SetLookAtPosition(lookPos.position);

        anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, ikWeight);
        anim.SetIKPositionWeight(AvatarIKGoal.RightHand, ikWeight);

        anim.SetIKPosition(AvatarIKGoal.RightHand, IKTargetRHand.position);
        anim.SetIKPosition(AvatarIKGoal.LeftHand, IKTargetLhand.position);
    }
}
