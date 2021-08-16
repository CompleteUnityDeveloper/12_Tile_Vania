using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Overlay : MonoBehaviour
{

    private float alpha = 0f;

    // Use this for initialization
    void Start()
    {
        // Start off with the canvas being transparent
        gameObject.GetComponent<Image>().color = new UnityEngine.Color(0f, 0f, 0f, alpha);
    }

    public void FadeOut(float time)
    {
        // Interpolate from transparent to dark over a set period of time
        alpha = Mathf.Lerp(0f, 1f, time);
        gameObject.GetComponent<Image>().color = new UnityEngine.Color(0f, 0f, 0f, alpha);
    }

}
