using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MainObject
{
    public Transform player;
    public GameObject enemy;
    private NavMeshAgent agent;

    private Vector3 enemyLastPosition; 

    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        agent.updateUpAxis = false;
        agent.updateRotation = false;

        HP = maxHP;

        
    }

    void FixedUpdate() 
    {
        agent.SetDestination(player.position);      

        if(transform.position != enemyLastPosition)
        {
            anim.SetBool("Walk", true);
            anim.SetBool("Idle", false);
            
        }
        else
        {
            anim.SetBool("Walk", false);
            anim.SetBool("Idle", true);
            
        }

        enemyLastPosition = transform.position;

        if(player.position.x < transform.position.x)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }

        else if(player.position.x > transform.position.x)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

    }

    


}
