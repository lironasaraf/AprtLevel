using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

/**
 * This component patrols between given points, chases a given target object when it sees it, and rotates from time to time.
 */
[RequireComponent(typeof(PatrollerRegular))]
[RequireComponent(typeof(Runner))]
[RequireComponent(typeof(Rotator))]
public class EnemyController3: MonoBehaviour {
    [SerializeField] float radiusToWatch = 5f;
    [SerializeField] float probabilityToRotate = 0.2f;
    [SerializeField] float probabilityToStopRotating = 0.2f;

    
    //private bool talkWithChild;
    private Runner runner;
    private PatrollerRegular patroller;
    private Rotator rotator;



    private void Chase() {


        runner.enabled = true;
        patroller.enabled = rotator.enabled = false;
        //navMeshAgent.speed = runSpeedChaser;
        //animator.SetFloat("MoveSpeed", runSpeedChaser);
       
        


    }

    private void Patrol() {
        patroller.enabled = true;
        runner.enabled = rotator.enabled = false;
        //animator.SetFloat("MoveSpeed", slowWalkSpeedPatroller);
        //navMeshAgent.speed = walkSpeedPatroller;
    }

    private void Rotate() {
        rotator.enabled = true;
        runner.enabled = patroller.enabled = false;
    }

    private void Start() {

        runner = GetComponent<Runner>();
        patroller = GetComponent<PatrollerRegular>();
        rotator = GetComponent<Rotator>();
        Patrol();
    }

    private void Update() {
        float distanceToTarget = Vector3.Distance(transform.position, runner.TargetObjectPosition());
        //Debug.Log("distanceToTarget = " + distanceToTarget);

        if (!runner.enabled && distanceToTarget <= radiusToWatch) {
            Chase();
        } else if (rotator.enabled) {
            if (Random.Range(0f,1f) < probabilityToStopRotating*Time.deltaTime) {
                Patrol();
            }
        } else if (patroller.enabled) {
            if (Random.Range(0f, 1f) < probabilityToRotate * Time.deltaTime) {
                Rotate();
            }
        } else if (runner.enabled) {
            if (distanceToTarget > radiusToWatch) {
                Patrol();
            } 
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radiusToWatch);
    }
}
 