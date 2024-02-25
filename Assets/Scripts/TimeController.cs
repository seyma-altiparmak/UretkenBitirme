using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;


public class TimeController : MonoBehaviour
{
    [HideInInspector]
    public float timeCounter;
    [SerializeField]
    TextMeshProUGUI timerCounterText;

    private void Awake()
    {
        timeCounter = 0;
        timerCounterText.text = "START GAME";

    }

    private void Update()
    {
        StartCoroutine(TimeSync());

    }
    IEnumerator TimeSync()
    {
        timeCounter = timeCounter + Time.deltaTime;
        timerCounterText.text = ("Timer : " + Math.Round(timeCounter, 2));
        yield return new WaitForSeconds(.2f);
    }
}
