using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolOfBlood : MonoBehaviour
{
    public GameObject[] blood;

    public GameObject player;

    public void Create()
    {
        int randomBlood = UnityEngine.Random.Range(0, blood.Length);

        Instantiate(blood[randomBlood], player.transform.position, transform.rotation);
    }
}
