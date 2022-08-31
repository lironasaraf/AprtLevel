using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(FishPatroller))]
[RequireComponent(typeof(FishChaser))]
[RequireComponent(typeof(Rotator))]
public class FishController : MonoBehaviour
{
    [SerializeField] float radiusToWatch = 5f;
    [SerializeField] float probabilityToRotate = 0.2f;
    [SerializeField] float probabilityToStopRotating = 0.2f;

    [SerializeField] private float runSpeedChaser;
    [SerializeField] private float walkSpeedPatroller;
    [SerializeField] private float slowWalkSpeedPatroller;

    //private bool talkWithChild;
    private FishChaser chaser;
    private FishPatroller patroller;
    private Rotator rotator;

    private NavMeshAgent navMeshAgent;
    private Animator animator;

    private void Chase()
    {


        chaser.enabled = true;
        patroller.enabled = rotator.enabled = false;




    }

    private void Patrol()
    {
        patroller.enabled = true;
        chaser.enabled = rotator.enabled = false;
    }

    private void Rotate()
    {
        rotator.enabled = true;
        chaser.enabled = patroller.enabled = false;
    }

    private void Start()
    {

        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        chaser = GetComponent<FishChaser>();
        patroller = GetComponent<FishPatroller>();
        rotator = GetComponent<Rotator>();
        Patrol();
    }

    private void Update()
    {
        float distanceToTarget = Vector3.Distance(transform.position, chaser.TargetObjectPosition());
        //Debug.Log("distanceToTarget = " + distanceToTarget);

        if (!chaser.enabled && distanceToTarget <= radiusToWatch)
        {
            Chase();
        }
        else if (rotator.enabled)
        {
            if (Random.Range(0f, 1f) < probabilityToStopRotating * Time.deltaTime)
            {
                Patrol();
            }
        }
        else if (patroller.enabled)
        {
            if (Random.Range(0f, 1f) < probabilityToRotate * Time.deltaTime)
            {
                Rotate();
            }
        }
        else if (chaser.enabled)
        {
            if (distanceToTarget > radiusToWatch)
            {
                Patrol();
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radiusToWatch);
    }
}
