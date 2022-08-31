using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimationController : MonoBehaviour
{
    [Header("Animation Fields")]
    [SerializeField] private bool activeAnimation;

    [SerializeField] private string typeFloat;
    [SerializeField] private float valueFloat;
    [SerializeField] private bool floatInStart;

    [SerializeField] private string typeInt;
    [SerializeField] private int valueInt;
    [SerializeField] private bool intInStart;


    [SerializeField] private string typeBool;
    [SerializeField] private bool valueBool;
    [SerializeField] private bool boolInStart;


    [SerializeField] private bool floatInPatrollAnimator;

    [SerializeField] private bool intInPatrollAnimator;

    [SerializeField] private bool boolInPatrollAnimator;

    [SerializeField] private bool floatInPatrollAnimatorStop;

    [SerializeField] private bool intInPatrollAnimatorStop;

    [SerializeField] private bool boolInPatrollAnimatorStop;



    private Animator animator;



    protected void Start()
    {
        if (activeAnimation)
            animator = GetComponent<Animator>();
        if (floatInStart)
            animator.SetFloat(typeFloat, valueFloat);
        if(intInStart)
            animator.SetInteger(typeInt, valueInt);
        if(boolInStart)
            animator.SetBool(typeBool, valueBool);

       
        
    }




    protected void playAnimator()
    {
        if (floatInPatrollAnimator)
            animator.SetFloat(typeFloat, valueFloat);
        if (intInPatrollAnimator)
            animator.SetInteger(typeInt, valueInt);
        if (boolInPatrollAnimator)
            animator.SetBool(typeBool, valueBool);
    }

    protected void stopAnimator()
    {
        if (floatInPatrollAnimatorStop)
            animator.SetFloat(typeFloat, 0);
        if (intInPatrollAnimatorStop)
            animator.SetInteger(typeInt, 0);
        if (boolInPatrollAnimatorStop)
            animator.SetBool(typeBool, false);
    }


}
