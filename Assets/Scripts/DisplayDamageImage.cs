using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamageImage : MonoBehaviour
{
    [SerializeField] Canvas damageCanvas;
    [SerializeField] float onScreenDelay = 0.3f;


    void Start() { damageCanvas.enabled = false; }

    public void ShowDamageImpact() { StartCoroutine(EnableDamageCanvas()); }

    IEnumerator EnableDamageCanvas()
    {
        damageCanvas.enabled = true;
        yield return new WaitForSeconds(onScreenDelay);
        damageCanvas.enabled = false;
    }
}
