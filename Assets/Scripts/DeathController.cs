using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathController : MonoBehaviour
{
    private GameObject controller;
    private TimeController tc = new TimeController();
    [SerializeField]
    protected GameObject tryAgainScene;
    public Animator characterAnimator;

    private void Start()
    {
        controller = GameObject.Find("Controller");
        tc = controller.GetComponent<TimeController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out PlayerBody pmsc))
        {
            characterAnimator.SetTrigger("isLoose");
            StartCoroutine(WaitUntilAnimationEnd());
            Time.timeScale = 0;
            tryAgainScene.SetActive(true);
            SavePlayerProgress();
        }
    }

    IEnumerator WaitUntilAnimationEnd()
    {
        yield return new WaitForSeconds(200f);
    }

    private void SavePlayerProgress()
    {
        int score = Convert.ToInt32(Math.Round(tc.timeCounter));
        PlayerPrefs.SetInt("LastScore", score);
        PlayerPrefs.Save();
    }
}
