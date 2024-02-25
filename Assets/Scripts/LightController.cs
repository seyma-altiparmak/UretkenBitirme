using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    private Light _light;
    private Color pink, green, white, yellow;
    private Animator pinkAnim, greenAnim, whiteAnim, yellowAnim;
    private Color currentState;
    public float intensity = 1.0f; // Adjust this value as needed

    private void Start()
    {
        _light = GameObject.Find("Light").GetComponent<Light>();
        pink = Color.HSVToRGB(320f / 360f, 1f, 1f); 
        green = Color.green;
        white = Color.blue;
        yellow = Color.yellow;
        pinkAnim = GameObject.Find("Pink").GetComponent<Animator>();
        greenAnim = GameObject.Find("Green").GetComponent<Animator>();
        whiteAnim = GameObject.Find("White").GetComponent<Animator>();
        yellowAnim = GameObject.Find("Yellow").GetComponent<Animator>();

        StartCoroutine(ChangeColors());
    }

    IEnumerator ChangeColors()
    {
        currentState = pink;
        _light.color = pink;
        _light.intensity = intensity; // Set the intensity
        Platform_PinkUP();
        yield return StartCoroutine(WaitForAnimation(pinkAnim));

        _light.color = white;
        AllIs_UP();
        yield return new WaitForSeconds(3f);

        currentState = green;
        _light.color = green;
        _light.intensity = intensity; // Set the intensity
        Platform_GreenUP();
        yield return StartCoroutine(WaitForAnimation(greenAnim));

        _light.color = white;
        AllIs_UP();
        yield return new WaitForSeconds(3f);

        currentState = yellow;
        _light.color = yellow;
        _light.intensity = intensity; // Set the intensity
        Platform_YellowUP();
        yield return StartCoroutine(WaitForAnimation(yellowAnim));

        _light.color = white;
        AllIs_UP();
        yield return new WaitForSeconds(3f);

        currentState = white;
        _light.color = white;
        _light.intensity = intensity; // Set the intensity
        Platform_WhiteUP();
        yield return StartCoroutine(WaitForAnimation(whiteAnim));

        _light.color = white;
        AllIs_UP();
        yield return new WaitForSeconds(3f);
    }


    IEnumerator WaitForAnimation(Animator anim)
    {
        while (anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
        {
            yield return null;
        }
    }

    void Platform_PinkUP()
    {
        pinkAnim.SetBool("pinkDown", false);
        greenAnim.SetBool("greenDown", true);
        whiteAnim.SetBool("whiteDown", true);
        yellowAnim.SetBool("yellowDown", true);
    }
    void Platform_GreenUP()
    {
        pinkAnim.SetBool("pinkDown", true);
        greenAnim.SetBool("greenDown", false);
        whiteAnim.SetBool("whiteDown", true);
        yellowAnim.SetBool("yellowDown", true);
    }
    void Platform_WhiteUP()
    {
        pinkAnim.SetBool("pinkDown", true);
        greenAnim.SetBool("greenDown", true);
        whiteAnim.SetBool("whiteDown", false);
        yellowAnim.SetBool("yellowDown", true);
    }
    void Platform_YellowUP()
    {
        pinkAnim.SetBool("pinkDown", true);
        greenAnim.SetBool("greenDown", true);
        whiteAnim.SetBool("whiteDown", true);
        yellowAnim.SetBool("yellowDown", false);
    }

    void AllIs_UP()
    {
        pinkAnim.SetBool("pinkDown", false);
        greenAnim.SetBool("greenDown", false);
        whiteAnim.SetBool("whiteDown", false);
        yellowAnim.SetBool("yellowDown", false);
    }
}
