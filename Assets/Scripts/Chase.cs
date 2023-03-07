using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chase : MonoBehaviour
{
   // public Rigidbody2D rb;
    public Transform player;
    private NavMeshAgent agent;


    void Start()
    {
        // anim = GetComponent<Animator>();
        // rb = GetComponent<Rigidbody2D>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateUpAxis = false;
        agent.updateRotation = false;
        
    }
    void Awake()
    {
       //player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }


    void FixedUpdate()
    {
        //transform.position = Vector2.MoveTowards(transform.position, player.position, speed);
        agent.SetDestination(player.position);


        //rb.MovePosition(rb.position + moveVolecity * Time.fixedDeltaTime);

        //float movex = Input.GetAxis("Horizontal");
       // anim.SetFloat("SpeedX", Mathf.Abs(movex));

        //float movey = Input.GetAxis("Vertical");
        //anim.SetFloat("SpeedY", Mathf.Abs(movey));

       // if (speed > 0 && !isFacingRight)
            //отражаем персонажа вправо
         //   Flip();
        //обратная ситуация. отражаем персонажа влево
        //else if (speed < 0 && isFacingRight)
        //    Flip();
    }

   
}

