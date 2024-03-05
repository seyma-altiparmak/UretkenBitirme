using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    [Header("Lights")]
    public GameObject[] lights;
    [Header("Animators")]
    public Animator[] lightAnimators;

    private WaitForSeconds delay = new WaitForSeconds(1f);

    void Start()
    {
        StartCoroutine(ChangeColors());
    }

    IEnumerator ChangeColors()
    {
        while (true)
        {
            ClearAllLights();

            yield return delay;

            int randomIndex = Random.Range(0, lights.Length);

            lights[randomIndex].SetActive(true);
            yield return new WaitForSeconds(2f);
         
            AllIsUp();

            yield return new WaitForSeconds(3f);
           
            AllIsDownExceptSelected(randomIndex);

            yield return new WaitForSeconds(3f);
        }
    }

    void ClearAllLights()
    {
        foreach (var light in lights)
        {
            light.SetActive(false);
        }
    }

    void AllIsDownExceptSelected(int selectedIndex)
    {
        for (int i = 0; i < lightAnimators.Length; i++)
        {
            if (i != selectedIndex)
            {
                lightAnimators[i].SetBool("IsDown", true);
            }
        }
    }

    void AllIsUp()
    {
        foreach (var animator in lightAnimators)
        {
            animator.SetBool("IsDown", false);
        }
    }
}
