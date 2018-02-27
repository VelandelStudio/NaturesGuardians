using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.AI;

public class FoxBehaviour : MonoBehaviour {

    [SerializeField] private Animator anim;
    [SerializeField] private NavMeshAgent navAgent;

    private float moveSpeed;
    private Vector3 nextDestination;
    private float remainingDistance;
    private int seed;

    private void Start()
    {
        UnityEngine.Random.InitState((int)DateTime.Now.Ticks);
        Invoke("Move", UnityEngine.Random.Range(5f, 8f));
    }

    private void Update()
    {
        remainingDistance = navAgent.remainingDistance;
        if (   remainingDistance != Mathf.Infinity 
            && navAgent.pathStatus == NavMeshPathStatus.PathComplete
            && navAgent.remainingDistance == 0
            || navAgent.pathStatus == NavMeshPathStatus.PathInvalid)
        {
            moveSpeed = 0;
            anim.SetBool("Moving", false);
        }
    }

    public void Move()
    {
        moveSpeed = UnityEngine.Random.Range(0f, 1f);
        Vector3 newPosition = UnityEngine.Random.insideUnitCircle.normalized * 3;
        nextDestination = new Vector3(transform.position.x + newPosition.x, transform.position.y, transform.position.z + newPosition.y)  ;
        anim.SetFloat("MoveSpeed", moveSpeed);
        anim.SetBool("Moving", true);
        navAgent.SetDestination(nextDestination);
        Invoke("Move", UnityEngine.Random.Range(8f, 10f));
    }
}
