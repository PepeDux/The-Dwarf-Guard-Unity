using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Security.Cryptography;


public class Teleport : MonoBehaviour
{
    public Transform Teleport_Point;
    public Text text;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            text.text = "press e to enter";
        }
    }
    

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {

            text.text = "press e to enter";

            if (Input.GetKeyDown("e"))
            {
                other.transform.position = Teleport_Point.transform.position;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {

            text.text = " ";
        }
    }
}
