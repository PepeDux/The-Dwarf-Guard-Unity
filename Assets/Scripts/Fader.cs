using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    private SpriteRenderer fader;
    private Color color;
    [SerializeField] private float fadeSpeed = 1f;

    private void OnEnable()
    {
        GameOver.gameOvered += StartFadeOn;
    }

    private void OnDisable()
    {
        GameOver.gameOvered -= StartFadeOn;
    }

    void Start()
    {
        fader = GetComponent<SpriteRenderer>();
        color = fader.color;
    }


    IEnumerator FadeOn()
    {
        while (fader.color.a < 256f)
        {
            color.a += fadeSpeed * Time.deltaTime;
            fader.color = color;

            yield return null;
        }
    }

    IEnumerator FadeOff()
    {
        while (fader.color.a > 0f)
        {
            color.a -= fadeSpeed * Time.deltaTime;
            fader.color = color;

            yield return null;
        }
    }

    private void StartFadeOn()
    {
        StartCoroutine("FadeOn");
    }

    private void StartFadeOff()
    {
        StartCoroutine("FadeOff");
    }
}

