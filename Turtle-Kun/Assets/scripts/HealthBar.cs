using System.Collections;
using System.Collections.Generic;
using System;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Kevin Rumboldt
/// The class is for measuring and setting the size of the health bar
/// </summary>
public class HealthBar : MonoBehaviour
{
    public static HealthBar instance { get; private set; }
    public Image mask;
    float originalSize;
    public float timeRamining = 10;
    private float change = 2f;
    void Awake()
    {
        Debug.Log("SHit");
        instance = this;
        // Timer mytimer = new Timer(2000);
        // mytimer.Elapsed += (sender, e) => SetValue(change);
        // mytimer.Enabled = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("HEre");
        Debug.Log(mask);
        originalSize = mask.rectTransform.rect.width;
        //Timer mytimer = new Timer(2000);
        //mytimer.Elapsed += (sender, e) => SetValue(change);
        //mytimer.Enabled = true;
    }

    public void SetValue(float value)
    {
        Debug.Log("FUck");
        Debug.Log(value);
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * value);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(timeRamining < 0)
        {
            timer();
        }*/
        
    }
    public float timer()
    {
        return 0.1f;
    }
}
