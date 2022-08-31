using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Algorithms
{
    private Vector3 runAwayAlgorithm(Vector3 playerPosition, Target[] targets, NavMeshAgent navMeshAgent)
    {
        float distance = 0;
        float lastdistance = 0;
        Target ansTarget = targets[0];
        for (int i = 0; i < targets.Length; i++)
        {
            distance = Vector3.Distance(playerPosition, targets[i].transform.position);

            if (distance > lastdistance && (targetNavMesh(targets[i].transform.position, navMeshAgent , navMeshAgent.path)))
            {
                lastdistance = distance;
                ansTarget = targets[i];
            }



        }
        return ansTarget.transform.position;
    }


    private bool targetNavMesh(Vector3 target, NavMeshAgent navMeshAgent, NavMeshPath path)
    {
        if (!navMeshAgent.CalculatePath(target + Vector3.forward, path))
            return false;
        if (!navMeshAgent.CalculatePath(target - Vector3.forward, path))
            return false;
        if (!navMeshAgent.CalculatePath(target + Vector3.right, path))
            return false;
        if (!navMeshAgent.CalculatePath(target - Vector3.right, path))
            return false;

        return true;
    }

}
