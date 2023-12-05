using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBobbing : MonoBehaviour
{
    float bobbingCounter = 0f;
    float bobbingMagnitude = .01f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float addAmount = Mathf.Sin(0.01f * bobbingCounter) * bobbingMagnitude * Time.deltaTime;
        transform.localPosition += Vector3.up * addAmount;
        bobbingCounter++;
    }
}
