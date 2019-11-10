using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
    public float rotationSpeed = 4;

    void Update()
    {
        transform.localEulerAngles += transform.up * rotationSpeed * Time.deltaTime;
    }
}
