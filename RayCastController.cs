using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Vector3 dir = this.transform.TransformDirection(Vector3.forward);
        bool c = Physics.Raycast(this.transform.position, dir, out hit, 2);
        if (c)
        {
            Debug.Log(hit.collider.gameObject);
        }
    }
}
