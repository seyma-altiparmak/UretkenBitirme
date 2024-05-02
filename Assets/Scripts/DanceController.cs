using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceController : MonoBehaviour
{
    public Animator characterAnimator;


    public void DanceStatementControls(int _state)
    {
        if (characterAnimator != null)
        {
            print("Dans Degisti." + $"Dancing{_state}");
            characterAnimator.SetTrigger($"Dancing{_state}");
        }
        else
        {
            Debug.LogError("Character Animator is not assigned!");
        }
    }

}
