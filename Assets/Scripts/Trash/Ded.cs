using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ded : MonoBehaviour
{
    public Animator anim;
   
    public float time = 5;
    public float random;



    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();      
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;

        if(time < 0)
        {
            random = Random.Range(0, 5);

            if(random == 1)
            {
                anim.SetTrigger("DedFrisky");
            }

            if (random == 2)
            {
                anim.SetTrigger("DedBlink");
            }

            time = 5;
        }
    }
}
