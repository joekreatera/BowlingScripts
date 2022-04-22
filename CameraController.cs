using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public bool shake;
    private float timer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void DoShake() {
        shake =true;
    }

    // Update is called once per frame
    void Update()
    {
        if (shake)
        {
            timer += Time.deltaTime;
            Vector3 rot = this.transform.eulerAngles;
            rot.z = -10 + 20 * Mathf.Sin(timer * 50);
            this.transform.eulerAngles = rot ;
            if (timer >= 2.0f)
            {
                shake = false;
            }
        }
        else {
            Vector3 rot = this.transform.eulerAngles;
            rot.z = 0;
            this.transform.eulerAngles = rot;
        }
        
    }
}
