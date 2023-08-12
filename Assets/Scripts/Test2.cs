using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2 : MonoBehaviour
{
    private void OnEnable()
    {
        Test.action += Do;
    }

    private void OnDisable()
    {
        Test.action -= Do;
    }

    public void Do()
    {
        Debug.Log("asfasfasf");
    }
}
