using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCamera : MonoBehaviour
{
    float moveSpeed = 2f;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * moveSpeed * Time.deltaTime); 
    }
}
