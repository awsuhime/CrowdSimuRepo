using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIControl : MonoBehaviour {

    public GameObject[] goals;
    NavMeshAgent agent;
    Animator anim;

    void Start() {

        agent = GetComponent<NavMeshAgent>();
        goals = GameObject.FindGameObjectsWithTag("Goal");
        agent.SetDestination(goals[Random.Range(0, goals.Length)].transform.position);
        anim = GetComponent<Animator>();
        anim.SetFloat("speed", Random.Range(0, 1));
        float sm = Random.Range(0.5f, 3f);
        anim.SetFloat("speedMult", sm);
        agent.speed *= sm;
        anim.SetTrigger("isWalking");
    }


    void Update() {
        if (agent.remainingDistance < 1)
        {
            agent.SetDestination(goals[Random.Range(0, goals.Length)].transform.position);

        }

    }
}