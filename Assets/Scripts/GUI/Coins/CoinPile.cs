﻿using System;
using System.Collections;
using UnityEngine;

public class CoinPile : MonoBehaviour
{
    public RectTransform backgroundGlow;
    private static Vector3 currentSize = Vector3.zero;

    private void Start()
    {
        if (currentSize != Vector3.zero) 
            transform.localScale = currentSize;
    }

    public void ShowFlashing()
    {
        StartCoroutine(showFlashing());
    }

    public void IncreaseScale(Vector3 value)
    {
        transform.localScale += value;
        backgroundGlow.localScale += value;
    }

    public void DecreaseScale(Vector3 value)
    {
        transform.localScale -= value;
        backgroundGlow.localScale -= value;
    }

    private IEnumerator showFlashing()
    {
        backgroundGlow.GetComponent<Animator>().SetTrigger("Flash");
        yield return new WaitForSeconds(1.5f);
        backgroundGlow.GetComponent<Animator>().SetTrigger("Off");
    }

    public void UpdateCurrentSize()
    {
        currentSize = transform.localScale;
    }
}