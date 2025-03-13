using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIControl : MonoBehaviour {

    public GameObject[] goals;
    NavMeshAgent agent;
    Animator anim;
    float detectionRadius = 25;
    float fleeRadius = 10;

    void Start() {

        agent = GetComponent<NavMeshAgent>();
        goals = GameObject.FindGameObjectsWithTag("Goal");
        agent.SetDestination(goals[Random.Range(0, goals.Length)].transform.position);
        anim = GetComponent<Animator>();
        anim.SetFloat("speed", Random.Range(0, 1));
        float sm = Random.Range(0.5f, 1.2f);
        anim.SetFloat("speedMult", sm);
        agent.speed *= sm;
        anim.SetTrigger("isWalking");
    }

    void ResetAgent()
    {
        anim.SetFloat("speed", Random.Range(0, 1));
        float sm = Random.Range(0.5f, 1.2f);
        anim.SetFloat("speedMult", sm);
        agent.speed *= sm;
        agent.angularSpeed = 120;
        anim.SetTrigger("isWalking");
        anim.SetBool("isRunning", false);

        agent.ResetPath();
    }
    void Update() {
        if (agent.remainingDistance < 1)
        {
            ResetAgent();
            agent.SetDestination(goals[Random.Range(0, goals.Length)].transform.position);

        }

    }

    public void DetectNewObstacle(Vector3 position)
    {
        if (Vector3.Distance(position, transform.position) < detectionRadius)
        {
            Vector3 fleeDirection = (transform.position - position).normalized;
            Vector3 newgoal = transform.position + fleeDirection  * fleeRadius;

            NavMeshPath path = new NavMeshPath();
            agent.CalculatePath(newgoal, path);
            if (path.status != NavMeshPathStatus.PathInvalid)
            {
                agent.SetDestination(path.corners[path.corners.Length - 1]);
                anim.SetTrigger("isRunning");
                anim.SetBool("isWalking", false);

                agent.speed = 8;
                agent.angularSpeed = 500;

                
            }
        }
    }
}