using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public class PatrollerRegular : AnimationController,PatrollerInterface
{
    [Header("PatrollerFields")]
    [Tooltip("A game object whose children have a Target component. Each child represents a target.")]
    [SerializeField] private Transform targetFolder = null;

    [Tooltip("set patroll random")]
    [SerializeField] protected bool random;

    [Tooltip("Minimum time to wait at target between running to the next target")]
    [SerializeField] private float minWaitAtTarget = 7f;

    [Tooltip("Maximum time to wait at target between running to the next target")]
    [SerializeField] private float maxWaitAtTarget = 15f;

    [SerializeField] private float timeToWaitAtTarget = 0;

    [SerializeField] private float WalkingSpeed = 3;

    [SerializeField] private float faceDirection;

    [SerializeField] private float rotationSpeed = 5f;

    [Header("For debugging")]
    [SerializeField] private Target[] allTargets = null;

    [Header("For debugging")]
    [SerializeField] private Target currentTargetDebug;

    private Target currentTarget = null;

    private NavMeshAgent navMeshAgent;

    private int counter = 0;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        allTargets = targetFolder.GetComponentsInChildren<Target>(false); // false = get components in active children only
    }

    private void OnEnable()
    {
        navMeshAgent.speed = 3;
        base.Start();
    }

    private void Start()
    {
        debugs();
        //base.Start();
        SelectNewTarget(random);
    }

    private void Update()
    {
       
      

        if (navMeshAgent.hasPath)
        {
            FaceDestination();
        }
        else
        {   // we are at the target
            //base.stopAnimator();
            timeToWaitAtTarget -= Time.deltaTime;
            if (timeToWaitAtTarget <= 0)
                SelectNewTarget(random);
        }
    }

    public void FaceDestination()
    {
        Vector3 directionToDestination = (navMeshAgent.destination - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(directionToDestination.x + faceDirection, 0, directionToDestination.z));
        transform.rotation = lookRotation; // Immediate rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed); // Gradual rotation
    }

    public void SelectNewTarget(bool random)
    {
        if(random)
        {
            currentTarget = allTargets[Random.Range(0, allTargets.Length - 1)];

            //Debug.Log("New target: " + currentTarget.name);
            //navMeshAgent.speed = walkingSpeedAnimation;

        }
        else
        {
            if (allTargets.Length <= counter)
            {
                counter = 0;
                this.enabled = false;
                return;
            }
            if (counter < allTargets.Length)
                currentTargetDebug = currentTarget = allTargets[counter++];
        }

        //base.playAnimator();

        navMeshAgent.SetDestination(currentTarget.transform.position);

        navMeshAgent.speed = WalkingSpeed;
        timeToWaitAtTarget = Random.Range(minWaitAtTarget, maxWaitAtTarget);


    }


    private void debugs()
    {
        if (targetFolder == null)
            Debug.Log("Forgot to set target folder to patroller");

    }
}
