using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FishPatroller : MonoBehaviour
{
    [Tooltip("Minimum time to wait at target between running to the next target")]
    [SerializeField] private float minWaitAtTarget = 7f;

    [Tooltip("Maximum time to wait at target between running to the next target")]
    [SerializeField] private float maxWaitAtTarget = 15f;


    [Tooltip("A game object whose children have a Target component. Each child represents a target.")]
    [SerializeField] private Transform targetFolder = null;
    private Target[] allTargets = null;

    [Header("For debugging")]
    [SerializeField] private Target currentTarget = null;
    [SerializeField] private float timeToWaitAtTarget = 0;
    [SerializeField] private float WalkingSpeed;

    private const float walkingSpeedAnimation = 0.33f;
    private Animator animator;
    private NavMeshAgent navMeshAgent;
    private float rotationSpeed = 5f;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();


        allTargets = targetFolder.GetComponentsInChildren<Target>(false); // false = get components in active children only
        Debug.Log("Found " + allTargets.Length + " active targets.");
        SelectNewTarget();

    }

    private void SelectNewTarget()
    {
        currentTarget = allTargets[Random.Range(0, allTargets.Length)];
        //Debug.Log("New target: " + currentTarget.name);
        navMeshAgent.speed = walkingSpeedAnimation;

        navMeshAgent.SetDestination(currentTarget.transform.position);

        
        navMeshAgent.speed = WalkingSpeed;
        timeToWaitAtTarget = Random.Range(minWaitAtTarget, maxWaitAtTarget);
    }


    private void Update()
    {
        if (OptionsGamePlay.menuIsActive)
        {
            navMeshAgent.speed = 0;

        }
        else if (navMeshAgent.speed != WalkingSpeed && !OptionsGamePlay.menuIsActive)
        {
            navMeshAgent.speed = WalkingSpeed;
        }

        if (navMeshAgent.hasPath)
        {
            FaceDestination();
        }
        else
        {   // we are at the target


            timeToWaitAtTarget -= Time.deltaTime;
            if (timeToWaitAtTarget <= 0)
                SelectNewTarget();
        }
    }

    private void FixedUpdate()
    {
        //animator.SetBool("Grounded", true);
    }

    private void FaceDestination()
    {
        Vector3 directionToDestination = (navMeshAgent.destination - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(directionToDestination.x, 0, directionToDestination.z));
        transform.rotation = lookRotation; // Immediate rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed); // Gradual rotation
    }
}
