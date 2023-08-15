using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using MinAttribute = UnityEngine.MinAttribute;

[CreateAssetMenu(fileName = "New Status", menuName = "Status", order = 51)]
public class StatusData : CharacteristicData
{
    [Header("Префаб еффекта")]
    //Префаб еффекта(необязательно)
    [SerializeField] public GameObject prefab;
    public GameObject Prefab { get => prefab; }
 
}
