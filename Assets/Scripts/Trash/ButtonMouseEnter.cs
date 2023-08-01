using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Security.Cryptography;

public class ButtonMouseEnter : MonoBehaviour
{
    private Button butt;
    private Text text;

    private ColorBlock ButtonNormal;
    private ColorBlock ButtonEnter;

    private Color TextNormal;
    private Color TextEnter;
    void Start()
    {
        butt = this.GetComponent<Button>();
        text = this.GetComponent<Text>();

    
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        butt.colors = ButtonEnter;
        text.color = TextEnter;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        butt.colors = ButtonNormal;
        text.color = TextNormal;
        
        
    }
}
