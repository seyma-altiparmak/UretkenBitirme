using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundColorController : MonoBehaviour
{
    //Take it on a "Camera"
    private Camera _camera;

    private void Start()
    {
        _camera = GetComponent<Camera>();
        StartCoroutine(ChangeBackgroundColor());
    }
    IEnumerator ChangeBackgroundColor()
    {
        while (true)
        {
            Color randomColor = new Color(Random.value, Random.value, Random.value);
            _camera.backgroundColor = randomColor;
            yield return new WaitForSeconds(5f);
        }
    }
}
