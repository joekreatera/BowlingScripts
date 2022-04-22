using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyItself : MonoBehaviour
{
    public GameObject destroyControl;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("destroy!");
        destroyControl.SendMessage("DoPhase3");
        Destroy(this.gameObject);  
    }

}
