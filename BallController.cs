using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody body;
    public AudioSource audio;
    
    // Start is called before the first frame update
    void Start()
    {
        body = this.GetComponent<Rigidbody>();
        audio = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot(Vector3 dir, float force, float torque) {

        body.AddForce(dir*force, ForceMode.Force);
        body.AddTorque(Vector3.up * torque+ Vector3.forward * torque, ForceMode.Force);
        audio.Play();
    }

}
