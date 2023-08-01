using UnityEngine;
using System.Collections;
using UnityEditor;

public class CameraFollow : MonoBehaviour
{

    public GameObject DwarfGuard; // тут объект игрока
    private Vector3 offset;
    [SerializeField] private float speed = 1f;

    void Start()
    {
        offset = transform.position - DwarfGuard.transform.position;
    }

    private void LateUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 positionToGo = DwarfGuard.transform.position + offset; //Target position of the camera
        Vector3 smoothPosition = Vector3.Lerp(a: transform.position, b: positionToGo, t: Time.deltaTime * speed);
        transform.position = smoothPosition;
    }
}