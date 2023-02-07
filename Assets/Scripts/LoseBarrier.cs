using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;

public class LoseBarrier : MonoBehaviour
{
    public bool playerTouch;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerTouch = true;
            Debug.Log("Player Touch");
        }
    }
}
