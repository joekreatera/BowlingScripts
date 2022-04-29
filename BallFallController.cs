using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFallController : MonoBehaviour
{
    public GameObject gameController;
    
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter ball " + other.gameObject);
        gameController.SendMessage("BallHasFallen", SendMessageOptions.DontRequireReceiver);    
    }
}
